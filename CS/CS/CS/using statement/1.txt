// using statement

using System;
using System.IO; // NOTE

class MainClass
{
    static void Main()
    {
        StreamReader sr = new StreamReader("1.txt");
        
        using(sr)
        {
            Console.WriteLine(sr.ReadLine());
            sr.Close();
        }

        using(StreamReader sr2 = new StreamReader("1.txt"))  
        {
            Console.WriteLine(sr2.ReadLine());
            sr.Close();
        }
    }
}