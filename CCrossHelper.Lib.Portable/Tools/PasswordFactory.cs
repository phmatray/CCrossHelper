using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CCrossHelper.Lib.Portable.Extensions;

namespace CCrossHelper.Lib.Portable.Tools
{
    public class PasswordFactory
    {
        private readonly int _passwordLength;
        private readonly Regex _pattern;
        private readonly Random _rnd;

        public PasswordFactory(int passwordLength = 8)
        {
            if (passwordLength < 4)
                throw new ArgumentOutOfRangeException("passwordLength", "cannot be smaller than 4");

            _passwordLength = passwordLength;
            _pattern = new Regex(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\~\!\@\#\$\%\^\&\*\(\)\.\<\>\?\{\}\[\]]).{8,}$");
            _rnd = new Random();
        }

        public string Generate(bool isVerified = false)
        {
            string retval;

            do
            {
                const string uppers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                const string lowers = "abcdefghijklmnopqrstuvwxyz";
                const string numbers = "0123456789";
                const string specials = "~!@#$%^&*().<>?{}[]";

                var authorisedCases = new List<string> { uppers, lowers, numbers, specials };

                // first 4 chars
                var password = new List<char>
                {
                    uppers[_rnd.Next(uppers.Length)],
                    lowers[_rnd.Next(lowers.Length)],
                    numbers[_rnd.Next(numbers.Length)],
                    specials[_rnd.Next(specials.Length)]
                };

                // last chars
                int remainingChars = _passwordLength - password.Count;
                for (int i = 0; i < remainingChars; i++)
                {
                    string caseCollection = authorisedCases[_rnd.Next(authorisedCases.Count)];
                    password.Add(caseCollection[_rnd.Next(caseCollection.Length)]);
                }

                // shake password
                password.Shuffle();

                // convert to string and return
                retval = password.Aggregate(string.Empty, (current, c) => current + c);
            } while (isVerified && !CheckPassword(retval));

            return retval;
        }

        public bool CheckPassword(string password)
        {
            return _pattern.IsMatch(password);
        }

        public List<Exception> GetErrors(string password)
        {
            var retval = new List<Exception>();

            if (password.Length == 0)
                retval.Add(new ArgumentException("Your password cannot be empty."));

            if (password.Length < 8)
                retval.Add(new ArgumentException(string.Format("Your password must be at least {0} characters.", _passwordLength)));

            var patternUppers = new Regex(@"^(?=.*[A-Z]).*$");
            if (!patternUppers.IsMatch(password))
                retval.Add(new ArgumentException("Your password should contain at least one uppercase letter."));

            var patternLowers = new Regex(@"^(?=.*[a-z]).*$");
            if (!patternLowers.IsMatch(password))
                retval.Add(new ArgumentException("Your password should contain at least one lowercase letter."));

            var patternNumbers = new Regex(@"^(?=.*[0-9]).*$");
            if (!patternNumbers.IsMatch(password))
                retval.Add(new ArgumentException("Your password should contain at least one number."));

            var patternSpecials = new Regex(@"^(?=.*[\~\!\@\#\$\%\^\&\*\(\)\.\<\>\?\{\}\[\]]).*$");
            if (!patternSpecials.IsMatch(password))
                retval.Add(new ArgumentException("Your password should contain at least one special character."));

            return retval;
        }
    }
}