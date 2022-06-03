// SortedList


using System;
using System.Collections;

class MainClass
{
    static void Main()
    {
        SortedList sl = new SortedList();

        sl.Add("USA", 1);
        sl.Add("UK", "London");

        sl["Germany"] = true;

        ICollection ic = sl.Keys;

        foreach(string str in ic)
             Console.WriteLine(str + ": " + sl[str]);

        Console.WriteLine();

        for (int i = 0; i < sl.Count; i++ )
            Console.WriteLine(sl.GetByIndex(i));

        Console.WriteLine();

        foreach (string str in ic)
            Console.WriteLine(str + ": " + sl.IndexOfKey(str));

        Console.WriteLine();
    }
}