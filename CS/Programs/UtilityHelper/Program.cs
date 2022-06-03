using System;
using System.Collections.Generic;
using System.Linq;
using Utility;
using static Utility.Enums;

namespace UtilityHelper
{
    class Program
    {
        static void Main()
        {
            int start = 32;
            // IEnumerable<int> numbers(int counter) =>
            Func<int, IEnumerable<int>> numbers = counter =>           
                    from i in Enumerable.Range(start, counter)
                    where Enumerable.Range(1, 1).All(j => i >= start && i >= 32 && i <= 47 || i >= 58 && i <= 64 || i >= 91 && i <= 96 || i >= 123 && i <= 126)
                    select i;
            int count = 95;

            string n = string.Join(" ", numbers(count));
            Console.WriteLine(n);

            string s = string.Join(" ", Enumerable.Range(32, 95).Where(x => x >= 32 && x <= 47 || x >= 58 && x <= 64 || x >= 91 && x <= 96 || x >= 123 && x <= 126).Select(x => x.ToString()) );
            Console.WriteLine(s);

            string upperCase = string.Join("", Enumerable.Range('A', 'Z' - 'A' + 1).Select(x => ((char)x).ToString()));
            string lowerCase = string.Join("", Enumerable.Range('a', 'z' - 'a' + 1).Select(x => ((char)x).ToString()));
            string digits = string.Join("", Enumerable.Range(0, 10).Select(x => x.ToString()));
            string nonAlphanumeric = string.Join("", Enumerable.Range(32, 95).Where(x => x >= 32 && x <= 47 || x >= 58 && x <= 64 || x >= 91 && x <= 96 || x >= 123 && x <= 126).Select(x => ((char)x).ToString()));
           
            Console.WriteLine(upperCase);
            Console.WriteLine(lowerCase);
            Console.WriteLine(digits);
            Console.WriteLine(nonAlphanumeric);

            Console.WriteLine(Utility.RandomPasswordGenerator.GenerateRandomPassword());


            // s = string.Join(" ", Enumerable.Range(0, 255).Select(x => ((char)x).ToString()));
            // Console.WriteLine(s);

            var numeric = from ch in "Alpha01235Numeric"
                          where Char.IsDigit(ch)
                          select ch;

            Console.WriteLine(string.Join(" ", numeric));

            Console.WriteLine("Hello World!" + (char)3);

            for (int i = 0; i < Enum.GetValues(typeof(Suit)).Length; i++)
            {
                Console.WriteLine(((Suit)i).GetDescriptionAttribute<Suit>());
                Console.WriteLine(((Suit)i).GetCategoryAttribute<Suit>());
                Console.WriteLine((Suit)i);
            }

            Console.WriteLine();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                Console.WriteLine(suit.GetDescriptionAttribute<Suit>());
                Console.WriteLine(suit.GetCategoryAttribute<Suit>());
                Console.WriteLine(suit);
            }
        }
    }
}

/*
32
33
34
35
36
37
38
39
40
41
42
43
44
45
46
47

58
59
60
61
62
63
64

91
92
93
94
95
96

123
124
125
126
*/