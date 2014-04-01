/* Author : 
 * Philippe Matray
 * 
 * Date:
 * 2014-03-26
 */

using System;
using System.Net;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

namespace CCrossHelper.Lib.Store.Helpers
{
    public static class ConnectionHelper
    {
        /// <summary>
        ///     Determines whether [is internet available].
        /// </summary>
        /// <returns></returns>
        public static bool IsInternetAvailable()
        {
            return IsInternetAvailable(GetNetworkConnectivityLevel());
        }

        /// <summary>
        ///     Determines whether [is internet available] by a [specified network connectivity level].
        /// </summary>
        /// <param name="networkConnectivityLevel">The network connectivity level.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">networkConnectivityLevel</exception>
        public static bool IsInternetAvailable(this NetworkConnectivityLevel networkConnectivityLevel)
        {
            switch (networkConnectivityLevel)
            {
                case NetworkConnectivityLevel.None:
                    return false;
                case NetworkConnectivityLevel.LocalAccess:
                    return false;
                case NetworkConnectivityLevel.ConstrainedInternetAccess:
                    return true;
                case NetworkConnectivityLevel.InternetAccess:
                    return true;
                default:
                    throw new ArgumentOutOfRangeException("networkConnectivityLevel");
            }
        }

        /// <summary>
        ///     Gets the network connectivity level.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NullReferenceException">internetConnectionProfile cannot be null</exception>
        public static NetworkConnectivityLevel GetNetworkConnectivityLevel()
        {
            try
            {
                if (NetworkInformation.GetInternetConnectionProfile() == null)
                    throw new NullReferenceException("InternetConnectionProfile cannot be null");

                return NetworkInformation.GetInternetConnectionProfile().GetNetworkConnectivityLevel();
            }
            catch (Exception)
            {
                return NetworkConnectivityLevel.None;
            }
        }

        /// <summary>
        ///     Determines whether [is internet available] asynchronously.
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> IsInternetAvailableAsync()
        {
            try
            {
                // Si l'utilisateur a accès à internet, 
                // nous vérifions que c'est effectivement le cas en tentant une requête.
                return GetNetworkConnectivityLevel().IsInternetAvailable() &&
                       await GetInternetStatusAsync();
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        ///     Gets the internet status asynchronously.
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> GetInternetStatusAsync()
        {
            return await GetInternetStatusAsync(new Uri("http://www.msn.be"));
        }

        /// <summary>
        ///     Gets the internet status asynchronously.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">url</exception>
        public static async Task<bool> GetInternetStatusAsync(Uri url)
        {
            if (url == null)
                throw new ArgumentNullException("url");

            var request = (HttpWebRequest) WebRequest.Create(url);
            try
            {
                using (await request.GetResponseAsync())
                {
                    request.Abort();
                    request = null;
                }
                return true;
            }
            catch (Exception)
            {
                if (request != null)
                    request.Abort();

                return false;
            }
        }
    }
}