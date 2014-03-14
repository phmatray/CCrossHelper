/* Author : 
 * Philippe Matray
 * 
 * Date:
 * 2014-02-28
 */

using System.Threading.Tasks;
using Windows.Storage;

namespace CCrossHelper.Lib.Store.Helpers
{
    public class Credentials
    {
        private static ApplicationDataContainer _settingsRoaming;

        #region login

        private const string HandleLogin = "login";

        public static string LoadLogin()
        {
            if (_settingsRoaming == null)
                _settingsRoaming = ApplicationData.Current.RoamingSettings;
            if (_settingsRoaming.Values[HandleLogin] != null)
                return _settingsRoaming.Values[HandleLogin].ToString();

            return string.Empty;
        }

        public static void SaveLogin(string login)
        {
            if (_settingsRoaming == null)
                _settingsRoaming = ApplicationData.Current.RoamingSettings;
            _settingsRoaming.Values[HandleLogin] = login;
        }

        #endregion

        #region password

        private const string HandlePassword = "password";

        public static string LoadPassword()
        {
            if (_settingsRoaming == null)
                _settingsRoaming = ApplicationData.Current.RoamingSettings;
            if (_settingsRoaming.Values[HandlePassword] != null)
                return _settingsRoaming.Values[HandlePassword].ToString();

            return string.Empty;
        }

        public static void SavePassword(string password)
        {
            if (_settingsRoaming == null)
                _settingsRoaming = ApplicationData.Current.RoamingSettings;
            _settingsRoaming.Values[HandlePassword] = password;
        }

        #endregion

        #region credentials

        public static async Task<Credentials> LoadCredentials()
        {
            string login = LoadLogin();
            string password = LoadPassword();

            return new Credentials(login, password);
        }

        public static void SaveCredentials(Credentials credentials)
        {
            SaveLogin(credentials.Login);
            SavePassword(credentials.Password);
        }

        #endregion

        public Credentials()
        {

        }

        public Credentials(string login = "", string password = "")
        {
            Login = login;
            Password = password;
        }

        public string Login { get; private set; }

        public string Password { get; private set; }
    }
}