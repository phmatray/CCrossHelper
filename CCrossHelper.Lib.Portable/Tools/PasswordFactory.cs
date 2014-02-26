using System;
using System.Collections.Generic;
using System.Linq;
using CCrossHelper.Lib.Portable.Extensions;

namespace CCrossHelper.Lib.Portable.Tools
{
    public class PasswordFactory
    {
        private readonly Random _rnd;

        public PasswordFactory()
        {
            _rnd = new Random();
        }

        public string Generate(int passwordLength = 8)
        {
            if (passwordLength < 4)
                throw new ArgumentOutOfRangeException("passwordLength", "cannot be smaller than 4");

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
            int remainingChars = passwordLength - password.Count;
            for (int i = 0; i < remainingChars; i++)
            {
                string caseCollection = authorisedCases[_rnd.Next(authorisedCases.Count)];
                password.Add(caseCollection[_rnd.Next(caseCollection.Length)]);
            }

            // shake password
            password.Shuffle();

            // convert to string and return
            return password.Aggregate(string.Empty, (current, c) => current + c);
        }
    }
}