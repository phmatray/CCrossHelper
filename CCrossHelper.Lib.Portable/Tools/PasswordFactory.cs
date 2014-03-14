/* Author : 
 * Philippe Matray
 *
 * Date :
 * 2014-02-20
 */

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
        private readonly Random _rnd;

        public Regex Pattern { get; private set; }


        /// <summary>
        ///     Initializes a new instance of the <see cref="PasswordFactory" /> class.
        /// </summary>
        /// <param name="passwordLength">Length of the password.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">passwordLength;cannot be smaller than 4</exception>
        public PasswordFactory(int passwordLength = 8)
        {
            if (passwordLength < 4)
                throw new ArgumentOutOfRangeException("passwordLength", "cannot be smaller than 4");

            _passwordLength = passwordLength;
            _rnd = new Random();

            Pattern = new Regex(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])" +
                                @"(?=.*[\~\!\@\#\$\%\^\&\*\(\)\.\<\>\?\{\}\[\]]).{8,}$");
        }

        /// <summary>
        ///     Generates a password.
        /// </summary>
        /// <param name="isVerified">if set to <c>true</c> the password is verified.</param>
        /// <returns></returns>
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

        /// <summary>
        ///     Checks the password.
        /// </summary>
        /// <param name="password">The password.</param>
        public bool CheckPassword(string password)
        {
            return Pattern.IsMatch(password);
        }

        /// <summary>
        ///     Gets the errors of the password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public List<Exception> GetErrors(string password)
        {
            var retval = new List<Exception>();

            if (string.IsNullOrWhiteSpace(password))
            {
                retval.Add(new ArgumentException("Your password cannot be empty."));
                return retval;
            }

            if (password.Length < 8)
                retval.Add(new ArgumentException(
                    string.Format("Your password must be at least {0} characters.", _passwordLength)));

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