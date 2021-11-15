using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generators
{
    public class DefaultGenerator : Generator
    {
        public DefaultGenerator()
        {
            _random = new Random();
        }
        private string _alphabet = "abcdefghijklmnopqrstuvwxyz";
        private string _numbers = "1234567890";
        private string _symbols = "~@#$%^&*()_+-=?";

        private readonly Random _random;
        public override IEnumerable<string> Generate(bool useUpperCase, bool useNumbers, bool useSymbols, int passwordLength, int passwordsListLength)
        {
            var _passwordListing = new List<string>();
            var _passwordChars = new List<string>()
            {
                _alphabet
            };
            if (useUpperCase)
                _passwordChars.Add(_alphabet.ToUpper());
            if (useNumbers)
                _passwordChars.Add(_numbers);
            if (useSymbols)
                _passwordChars.Add(_symbols);
            string passwordSet = string.Join("", _passwordChars);
            int minimumCountOfChars = passwordLength / _passwordChars.Count;
            int remainder = passwordLength % _passwordChars.Count;
            string generatedPassword = string.Empty;
            for (int i = 0; i < passwordsListLength; i++)
            {
                foreach (var item in _passwordChars)
                {
                    for (int j = 0; j < minimumCountOfChars; j++)
                    {
                        generatedPassword += item[_random.Next(item.Length)];
                    }
                }

                for (int k = 0; k < remainder; k++)
                {
                    generatedPassword += passwordSet[_random.Next(passwordSet.Length)];
                }

                _passwordListing.Add(generatedPassword.Shuffle());
                generatedPassword = "";
            }

            return _passwordListing;
            
        }
    }

    public static class Extensions
    {
        public static string Shuffle(this string s)
        {
            char[] charArray = s.ToCharArray();
            Random rng = new Random();
            int n = charArray.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = charArray[k];
                charArray[k] = charArray[n];
                charArray[n] = value;
            }
            return new string(charArray);
        }
    }
}
