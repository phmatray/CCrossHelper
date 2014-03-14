/* Author : 
 * Wouter Devinck
 * 
 * Mail :
 * wouter.devinck@gmail.com
 * 
 * Based on :
 * https://dev.twitter.com/docs/oauth/xauth
 */

using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using CCrossHelper.Lib.Store.Helpers;

namespace CCrossHelper.Lib.Store.OAuth
{
    public sealed class XAuth
    {
        public XAuth(string consumerkey, string consumersecret, string xauthurl)
        {
            ConsumerKey = consumerkey;
            ConsumerSecret = consumersecret;
            XAuthUrl = xauthurl;
        }

        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string XAuthUrl { get; set; }

        public IAsyncOperation<OAuth> SignInAsync(string username, string password)
        {
            return SignInAsyncTask(username, password).AsAsyncOperation();
        }

        private async Task<OAuth> SignInAsyncTask(string username, string password)
        {
            var o = new OAuth(ConsumerKey, ConsumerSecret);
            var uri = new Uri(XAuthUrl);
            string xauth = string.Format("x_auth_mode=client_auth&x_auth_password={0}&x_auth_username={1}",
                password.UrlEncode(), username.UrlEncode());
            uri = o.SignUri(uri, extraSignature: xauth, httpmethod: "POST");
            string result = await uri.HttpPost(xauth);

            if (result == null)
                return null;

            string token = "";
            string tokensecret = "";
            foreach (var val in result.Split('&').Select(item => item.Split('=')))
            {
                switch (val[0])
                {
                    case "oauth_token":
                        token = val[1];
                        break;
                    case "oauth_token_secret":
                        tokensecret = val[1];
                        break;
                }
            }
            o.Token = token;
            o.TokenSecret = tokensecret;
            return o;
        }
    }
}