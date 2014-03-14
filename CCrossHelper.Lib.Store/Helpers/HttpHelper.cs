/* Author : 
 * Philippe Matray
 * 
 * Date:
 * 2014-02-28
 */

using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CCrossHelper.Lib.Store.Helpers
{
    internal static class HttpHelper
    {
        public static async Task<string> HttpPost(this Uri url, string data)
        {
            try
            {
                var client = new HttpClient();
                var content = new StringContent(data);
                HttpResponseMessage result = await client.PostAsync(url, content);
                return await result.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static async Task<string> HttpGet(this Uri url)
        {
            try
            {
                var client = new HttpClient();
                HttpResponseMessage result = await client.GetAsync(url);
                return await result.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string UrlEncode(this string value)
        {
            var result = new StringBuilder();
            foreach (char symbol in value)
            {
                if ("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~".IndexOf(symbol) != -1)
                    result.Append(symbol);
                else
                    result.Append('%' + String.Format("{0:X2}", (int) symbol));
            }

            return result.ToString();
        }
    }
}