/* Author : 
 * Jamie Thomson
 * 
 * Date:
 * 2014-02-14
 * 
 * Link:
 * http://blog.jerrynixon.com/2013/12/the-two-ways-to-handle-orientation-in.html
 */

using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.Storage.Streams;

namespace CCrossHelper.Lib.Store.Helpers
{
    public enum StorageType
    {
        Roaming,
        Local,
        Temporary
    }

    public class ObjectStorageHelper<T>
    {
        #region fields

        private readonly ApplicationData _appData;
        private readonly XmlSerializer _serializer;
        private readonly StorageType _storageType;

        #endregion

        #region ctor

        /// <summary>
        ///     Generic class to simplify the storage and retrieval of data to/from Windows.Storage.ApplicationData
        /// </summary>
        /// <param name="storageType"></param>
        public ObjectStorageHelper(StorageType storageType)
        {
            _serializer = new XmlSerializer(typeof (T));
            _storageType = storageType;
            _appData = ApplicationData.Current;
        }

        #endregion

        #region methods

        private string FileName(T obj, string handle)
        {
            /*When I first started writing this class I thought I would only be storing objects that could be serialized as XML
             and hence I put a .xml suffix on the filename. I now realise the folly of doing this as I may want to, in the future,
             store objects that cannot be serialized as XML (e.g. Media objects) and instead use some alternative method that does 
             not involve serialization. 
             I had a choice between supporting backward compatibility or dropping the .xml suffix. I opted for the latter.*/
            
            return String.Concat(handle, String.Format("{0}", obj.GetType()));
        }

        /// <summary>
        ///     Delete a stored instance of T from Windows.Storage.ApplicationData
        /// </summary>
        /// <returns></returns>
        public async Task DeleteAsync()
        {
            string fileName = FileName(Activator.CreateInstance<T>(), String.Empty);
            await DeleteAsync(fileName);
        }

        /// <summary>
        ///     Delete a stored instance of T with a specified handle from Windows.Storage.ApplicationData.
        ///     Specification of a handle supports storage and deletion of different instances of T.
        /// </summary>
        /// <param name="handle">User-defined handle for the stored object</param>
        public async Task DeleteAsync(string handle)
        {
            if (handle == null)
                throw new ArgumentNullException("handle");

            string fileName = FileName(Activator.CreateInstance<T>(), handle);
            StorageFolder folder = GetFolder(_storageType);
            StorageFile file = await GetFileIfExistsAsync(folder, fileName);
            
            if (file != null)
                await file.DeleteAsync(StorageDeleteOption.PermanentDelete);
        }

        /// <summary>
        ///     Store an instance of T to Windows.Storage.ApplicationData with a specified handle.
        ///     Specification of a handle supports storage and deletion of different instances of T.
        /// </summary>
        /// <param name="obj">Object to be saved</param>
        /// <param name="handle">User-defined handle for the stored object</param>
        public async Task SaveAsync(T obj, string handle)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            if (handle == null)
                throw new ArgumentNullException("handle");

            string fileName = FileName(Activator.CreateInstance<T>(), handle);
            StorageFolder folder = GetFolder(_storageType);
            StorageFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            IRandomAccessStream writeStream = await file.OpenAsync(FileAccessMode.ReadWrite);

            using (Stream outStream = Task.Run(() => writeStream.AsStreamForWrite()).Result)
            {
                _serializer.Serialize(outStream, obj);
                await outStream.FlushAsync();
            }
        }

        /// <summary>
        ///     Save an instance of T to Windows.Storage.ApplicationData.
        /// </summary>
        /// <param name="obj">Object to be saved</param>
        public async Task SaveAsync(T obj)
        {
            string fileName = FileName(obj, String.Empty);
            await SaveAsync(obj, fileName);
        }

        /// <summary>
        ///     Retrieve a stored instance of T with a specified handle from Windows.Storage.ApplicationData.
        ///     Specification of a handle supports storage and deletion of different instances of T.
        /// </summary>
        /// <param name="handle">User-defined handle for the stored object</param>
        public async Task<T> LoadAsync(string handle)
        {
            if (handle == null)
                throw new ArgumentNullException("handle");

            string fileName = FileName(Activator.CreateInstance<T>(), handle);
            try
            {
                StorageFolder folder = GetFolder(_storageType);
                StorageFile file = await folder.GetFileAsync(fileName);
                IRandomAccessStream readStream = await file.OpenAsync(FileAccessMode.Read);
                using (Stream inStream = Task.Run(() => readStream.AsStreamForRead()).Result)
                {
                    return (T) _serializer.Deserialize(inStream);
                }
            }
            catch (FileNotFoundException)
            {
                //file not existing is perfectly valid so simply return the default 
                return default(T);
                //Interesting thread here: How to detect if a file exists (http://social.msdn.microsoft.com/Forums/en-US/winappswithcsharp/thread/1eb71a80-c59c-4146-aeb6-fefd69f4b4bb)
                //throw;
            }
            catch (Exception)
            {
                //Unable to load contents of file
                throw;
            }
        }

        /// <summary>
        ///     Retrieve a stored instance of T from Windows.Storage.ApplicationData.
        /// </summary>
        public async Task<T> LoadAsync()
        {
            string fileName = FileName(Activator.CreateInstance<T>(), String.Empty);
            return await LoadAsync(fileName);
        }

        private StorageFolder GetFolder(StorageType storageType)
        {
            StorageFolder folder;
            switch (storageType)
            {
                case StorageType.Roaming:
                    folder = _appData.RoamingFolder;
                    break;
                case StorageType.Local:
                    folder = _appData.LocalFolder;
                    break;
                case StorageType.Temporary:
                    folder = _appData.TemporaryFolder;
                    break;
                default:
                    throw new Exception(String.Format("Unknown StorageType: {0}", storageType));
            }
            return folder;
        }

        private async Task<StorageFile> GetFileIfExistsAsync(StorageFolder folder, string fileName)
        {
            try
            {
                return await folder.GetFileAsync(fileName);
            }
            catch
            {
                return null;
            }
        }

        #endregion
    }
}