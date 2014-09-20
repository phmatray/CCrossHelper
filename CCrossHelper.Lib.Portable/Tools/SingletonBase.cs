/* Author:
 * Boris Brock
 * 
 * Link:
 * http://www.codeproject.com/Articles/572263/A-Reusable-Base-Class-for-the-Singleton-Pattern-in
 */

using System;

namespace CCrossHelper.Lib.Portable.Tools
{
    /// <summary>
    ///     A base class for the singleton design pattern.
    /// </summary>
    /// <typeparam name="T">Class type of the singleton</typeparam>
    public abstract class SingletonBase<T> where T : class
    {
        #region Members

        /// <summary>
        ///     Static instance. Needs to use lambda expression
        ///     to construct an instance (since constructor is private).
        /// </summary>
        private static readonly Lazy<T> StaticInstance = new Lazy<T>(CreateInstanceOfT);

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the instance of this singleton.
        /// </summary>
        public static T Instance
        {
            get { return StaticInstance.Value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Creates an instance of T via reflection since T's constructor is expected to be private.
        /// </summary>
        private static T CreateInstanceOfT()
        {
            return Activator.CreateInstance(typeof(T), true) as T;
        }

        #endregion
    }
}