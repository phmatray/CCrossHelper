/* Author : 
 * Philippe Matray
 *
 * Date :
 * 2014-01-23
 */

////using System;
////using System.Threading.Tasks;

////namespace CCrossHelper.Lib.Portable.Helpers
////{
////    public static class WebRequestHelper
////    {
////        #region fields

////        private static readonly HttpClient Client;

////        #endregion

////        #region ctor

////        /// <summary>
////        ///     Initializes the <see cref="WebRequestHelper" /> class.
////        /// </summary>
////        static WebRequestHelper()
////        {
////            Client = new HttpClient();
////            Client.DefaultRequestHeaders.Add("user-agent",
////                "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");
////        }

////        #endregion

////        #region methods

////        /// <summary>
////        ///     Makes the web request asynchronously.
////        /// </summary>
////        /// <param name="uri">The URI.</param>
////        /// <returns></returns>
////        public static async Task<string> MakeWebRequest(Uri uri)
////        {
////            uri.ThrowIfArgumentIsNull("uri");

////            string content = await Client.GetStringAsync(uri);
////            return await Task.Run(() => content);
////        }

////        /// <summary>
////        ///     Posts the specified URI.
////        /// </summary>
////        /// <param name="uri">The URI.</param>
////        /// <param name="data">The data.</param>
////        /// <returns></returns>
////        public static async Task<string> Post(Uri uri, string data)
////        {
////            uri.ThrowIfArgumentIsNull("uri");
////            data.ThrowIfArgumentIsNullOrWhiteSpace("data");

////            HttpResponseMessage response = await Client.PostAsync(uri, new StringContent(data));
////            response.EnsureSuccessStatusCode();

////            string content = await response.Content.ReadAsStringAsync();
////            return await Task.Run(() => content);
////        }

////        /// <summary>
////        ///     Gets the specified request URI.
////        /// </summary>
////        /// <param name="requestUri">The request URI.</param>
////        /// <returns></returns>
////        public static async Task<string> Get(Uri requestUri)
////        {
////            requestUri.ThrowIfArgumentIsNull("requestUri");

////            HttpResponseMessage response = await Client.GetAsync(requestUri);
////            response.EnsureSuccessStatusCode();

////            string content = await response.Content.ReadAsStringAsync();
////            return await Task.Run(() => content);
////        }

////        /// <summary>
////        ///     Gets the content headers.
////        /// </summary>
////        /// <param name="requestUri">The request URI.</param>
////        /// <returns></returns>
////        public static async Task<HttpContentHeaders> GetContentHeaders(Uri requestUri)
////        {
////            requestUri.ThrowIfArgumentIsNull("requestUri");

////            var request = new HttpRequestMessage(HttpMethod.Head, requestUri);
////            HttpResponseMessage response = await Client.SendAsync(request);
////            response.EnsureSuccessStatusCode();

////            return response.Content.Headers;
////        }

////        /// <summary>
////        ///     Gets the length of the content by HEAD httpMethod.
////        /// </summary>
////        /// <param name="requestUri">The request URI.</param>
////        /// <returns></returns>
////        public static async Task<long?> GetContentLength(Uri requestUri)
////        {
////            requestUri.ThrowIfArgumentIsNull("requestUri");

////            var request = new HttpRequestMessage(HttpMethod.Head, requestUri);
////            HttpResponseMessage response = await Client.SendAsync(request);
////            response.EnsureSuccessStatusCode();

////            return response.Content.Headers.ContentLength;
////        }

////        /// <summary>
////        ///     Gets the type of the content by HEAD httpMethod.
////        /// </summary>
////        /// <param name="requestUri">The request URI.</param>
////        /// <returns></returns>
////        public static async Task<string> GetContentType(Uri requestUri)
////        {
////            requestUri.ThrowIfArgumentIsNull("requestUri");

////            var request = new HttpRequestMessage(HttpMethod.Head, requestUri);
////            HttpResponseMessage response = await Client.SendAsync(request);
////            response.EnsureSuccessStatusCode();

////            return response.Content.Headers.ContentType.MediaType;
////        }

////        #endregion
////    }
////}