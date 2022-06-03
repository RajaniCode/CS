// Enumerator


using System;
using System.Collections;

class MainClass
{
    static void Main()
    {
        ArrayList al = new ArrayList();

        for(int i=0; i<10; i++)
        {
            al.Add(i);
        }

        IEnumerator ie = al.GetEnumerator();

        while(ie.MoveNext())   
            Console.Write(ie.Current + " ");

        Console.WriteLine();

        ie.Reset();
        while(ie.MoveNext())   
            Console.Write(ie.Current + " ");

        Console.WriteLine();      
    }
}