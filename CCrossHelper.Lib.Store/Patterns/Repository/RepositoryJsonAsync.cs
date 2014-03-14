/* Author : 
 * Philippe Matray
 * 
 * Date:
 * 2014-03-13
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using CCrossHelper.Lib.Portable.Patterns;
using CCrossHelper.Lib.Portable.Patterns.Repository;
using Newtonsoft.Json;

namespace CCrossHelper.Lib.Store.Patterns.Repository
{
    public class RepositoryJsonAsync<T> : IRepositoryAsync<T>
        where T : IModel
    {
        #region fields

        private readonly StorageFolder _folder;
        private readonly string _fileName;
        private StorageFile _file;
        private IList<T> _elements;

        #endregion

        #region ctor

        public RepositoryJsonAsync()
        {
            _folder = ApplicationData.Current.LocalFolder;
            _fileName = GetFileName();
        }

        #endregion

        #region methods

        private static string GetFileName()
        {
            string typeName = typeof(T).Name;
            if (string.IsNullOrWhiteSpace(typeName))
                typeName = "default";

            return typeName + ".json";
        }

        public async Task<IList<T>> GetAll()
        {
            try
            {
                if (_file == null)
                    _file = await _folder.CreateFileAsync(_fileName, CreationCollisionOption.OpenIfExists);
                if (_file == null)
                    throw new Exception();

                string text = await FileIO.ReadTextAsync(_file);
                _elements = JsonConvert.DeserializeObject<IList<T>>(text);
            }
            catch (Exception)
            {
            }

            return _elements ?? (_elements = new List<T>());
        }

        public async Task<T> GetById(Guid elementId)
        {
            try
            {
                if (_elements == null)
                    _elements = await GetAll();
                if (_elements == null)
                    throw new Exception();

                return _elements.FirstOrDefault(t => t.Id == elementId);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public async Task<bool> Insert(T element)
        {
            try
            {
                if (_elements == null)
                    _elements = await GetAll();
                if (_elements == null)
                    throw new Exception();

                _elements.Add(element);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(Guid elementId)
        {
            try
            {
                T tumblr = await GetById(elementId);
                _elements.Remove(tumblr);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(T element)
        {
            try
            {
                T toRemove = await GetById(element.Id);
                _elements.Remove(toRemove);
                _elements.Add(element);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Save()
        {
            try
            {
                string serializeObject = JsonConvert.SerializeObject(_elements);
                await FileIO.WriteTextAsync(_file, serializeObject);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}