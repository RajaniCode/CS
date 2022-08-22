// Hashtable


using System;
using System.Collections;

class MainClass
{
    static void Main()
    {
        Hashtable ht = new Hashtable();


        ht.Add("USA", 1);
        ht.Add("UK", "London");

        ht["Germany"] = true;

        ICollection ic = ht.Keys;

        foreach(string str in ic)
             Console.WriteLine(str + ": " + ht[str]);
    }
}