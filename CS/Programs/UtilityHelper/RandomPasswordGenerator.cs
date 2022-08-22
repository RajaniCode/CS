using System;
using System.Collections.Generic;
using System.Linq;

namespace Utility
{
    /// <summary>
    /// Helper utility for generating a random password.
    /// </summary>
    public static class RandomPasswordGenerator
    {
        /// <summary>
        /// Generates a random password.
        /// <returns>A random password.</returns>
        public static string GenerateRandomPassword()
        {
            const int RequiredLength = 8;
            const int RequiredUniqueCharacters = 4;
            const bool RequireUppercase = true;
            const bool RequireLowercase = true;
            const bool RequireDigit = true;
            const bool RequireNonAlphanumeric = true;

            string upperCase = string.Join("", Enumerable.Range('A', 'Z' - 'A' + 1).Select(x => ((char)x).ToString()));
            string lowerCase = string.Join("", Enumerable.Range('a', 'z' - 'a' + 1).Select(x => ((char)x).ToString()));
            string digits = string.Join("", Enumerable.Range(0, 10).Select(x => x.ToString()));
            string nonAlphanumeric = string.Join("", Enumerable.Range(32, 127).Where(x => x >= 32 && x <= 47 || x >= 58 && x <= 64 || x >= 91 && x <= 96 || x >= 123 && x <= 126).Select(x => ((char)x).ToString()));

            var ascii = new string[]
            {
                upperCase,
                lowerCase,
                digits,
                nonAlphanumeric
            };

            var randomNumber = new Random(Environment.TickCount);
            var characters = new List<char>();

            if (RequireUppercase)
            {
                characters.Insert(randomNumber.Next(0, characters.Count), ascii[0][randomNumber.Next(0, ascii[0].Length)]);
            }

            if (RequireLowercase)
            {
                characters.Insert(randomNumber.Next(0, characters.Count), ascii[1][randomNumber.Next(0, ascii[1].Length)]);
            }

            if (RequireDigit)
            {
                characters.Insert(randomNumber.Next(0, characters.Count), ascii[2][randomNumber.Next(0, ascii[2].Length)]);
            }

            if (RequireNonAlphanumeric)
            {
                characters.Insert(randomNumber.Next(0, characters.Count), ascii[3][randomNumber.Next(0, ascii[3].Length)]);
            }

            for (int index = characters.Count; index < RequiredLength || characters.Distinct().Count() < RequiredUniqueCharacters; index++)
            {
                string sequence = ascii[randomNumber.Next(0, ascii.Length)];
                characters.Insert(randomNumber.Next(0, characters.Count), sequence[randomNumber.Next(0, sequence.Length)]);
            }

            return new string(characters.ToArray());
        }
    }
}
