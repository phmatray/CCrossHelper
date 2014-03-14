/* Author : 
 * Wouter Devinck
 * 
 * Mail :
 * wouter.devinck@gmail.com
 * 
 * Based on :
 * http://tools.ietf.org/pdf/rfc5849.pdf
 * 
 * Note :
 * This is not a feature-complete implementation
 * OAuth version 1.0 with a HMAC-SHA1 signature
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using CCrossHelper.Lib.Store.Helpers;

namespace CCrossHelper.Lib.Store.OAuth
{
    public class OAuth
    {
        public OAuth(string consumerkey, string consumersecret)
        {
            ConsumerKey = consumerkey;
            ConsumerSecret = consumersecret;
        }

        public int Nonce { get; set; }
        public long Timestamp { get; set; }
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string Token { get; set; }
        public string TokenSecret { get; set; }

        private static long GenerateTimeStamp()
        {
            TimeSpan timespan = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(timespan.TotalSeconds);
        }

        public string SignUri(string url)
        {
            return SignUri(new Uri(url)).ToString();
        }

        public Uri SignUri(Uri url, string callback = "oob", string httpmethod = "GET", string extraSignature = "")
        {
            Nonce = NextInt(123400, 9999999);
            Timestamp = GenerateTimeStamp();
            Dictionary<string, string> parameters = GenerateParameterList(ConsumerKey, Token, callback, url.Query);
            string normalizedurl = GenerateNormalizedUrl(url);
            string normalizedparams = NormalizeRequestParameters(parameters);
            string signaturebase = GenerateSignatureBase(httpmethod, normalizedurl,
                normalizedparams + (!string.IsNullOrEmpty(extraSignature) ? "&" + extraSignature : ""));
            string keyText = string.Format("{0}&{1}", ConsumerSecret.UrlEncode(),
                string.IsNullOrEmpty(TokenSecret) ? "" : TokenSecret.UrlEncode());
            IBuffer keyMaterial = CryptographicBuffer.ConvertStringToBinary(keyText,
                BinaryStringEncoding.Utf8);
            MacAlgorithmProvider macAlgorithmProvider = MacAlgorithmProvider.OpenAlgorithm("HMAC_SHA1");
            CryptographicKey key = macAlgorithmProvider.CreateKey(keyMaterial);
            IBuffer tbs = CryptographicBuffer.ConvertStringToBinary(signaturebase,
                BinaryStringEncoding.Utf8);
            IBuffer signatureBuffer = CryptographicEngine.Sign(key, tbs);
            string signature = CryptographicBuffer.EncodeToBase64String(signatureBuffer);
            return new Uri(normalizedurl + "?" + normalizedparams + "&oauth_signature=" + signature.UrlEncode());
        }

        private Dictionary<string, string> GenerateParameterList(string consumerKey, string token, string callback,
            string query)
        {
            string[] p = query.Split("&?".ToCharArray());
            Dictionary<string, string> parameters = p
                .Where(s => !string.IsNullOrEmpty(s) && s.Contains("="))
                .Select(s => s.Split('=')).ToDictionary(param => param[0], param => param[1]);
            
            if (!string.IsNullOrEmpty(callback))
                parameters.Add("oauth_callback", callback);
            parameters.Add("oauth_consumer_key", consumerKey);
            parameters.Add("oauth_nonce", Nonce.ToString());
            parameters.Add("oauth_signature_method", "HMAC-SHA1");
            parameters.Add("oauth_timestamp", Timestamp.ToString());
            if (!string.IsNullOrEmpty(token))
                parameters.Add("oauth_token", token);
            parameters.Add("oauth_version", "1.0");

            return parameters
                .OrderBy(entry => entry.Key)
                .ToDictionary(x => x.Key, x => x.Value);
        }

        private static string GenerateNormalizedUrl(Uri url)
        {
            string normalizedurl = string.Format("{0}://{1}", url.Scheme, url.Host);
            if (!((url.Scheme == "http" && url.Port == 80) || (url.Scheme == "https" && url.Port == 443)))
                normalizedurl += ":" + url.Port;
            normalizedurl += url.AbsolutePath;

            return normalizedurl;
        }

        private static string GenerateSignatureBase(string httpmethod, string normalizedurl, string normalizedparams)
        {
            var result = new StringBuilder();
            result.AppendFormat("{0}&", httpmethod.ToUpper());
            result.AppendFormat("{0}&", normalizedurl.UrlEncode());
            result.AppendFormat("{0}", normalizedparams.UrlEncode());
            return result.ToString();
        }

        private static string NormalizeRequestParameters(Dictionary<string, string> parameters)
        {
            var sb = new StringBuilder();
            foreach (var p in parameters)
                sb.AppendFormat("{0}={1}&", p.Key, p.Value.UrlEncode());
            string result = sb.ToString();
            
            return result.Substring(0, result.Length - 1);
        }

        private static byte[] StringToAscii(string s)
        {
            var retval = new byte[s.Length];
            for (int ix = 0; ix < s.Length; ++ix)
            {
                char ch = s[ix];
                if (ch <= 0x7f) retval[ix] = (byte) ch;
                else retval[ix] = (byte) '?';
            }
            return retval;
        }

        private static int NextInt(int min, int max)
        {
            var result = (int) CryptographicBuffer.GenerateRandomNumber();
            return new Random(result).Next(min, max);
        }
    }
}