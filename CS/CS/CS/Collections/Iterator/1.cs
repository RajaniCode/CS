// Iterator


using System;
using System.Collections;

class ExampleClass
{
    char[] chrs = {'A', 'B', 'C', 'D'};

    public IEnumerator GetEnumerator() // Must be public
    {
        foreach(Char chr in chrs)
            yield return chr;
    }
}

class MainClass
{
    static void Main()
    {
        ExampleClass ec = new ExampleClass();


        foreach(Char chr in ec)
            Console.Write(chr + " ");

        Console.WriteLine();

         foreach(Char chr in ec)
            Console.Write(chr + " ");

        Console.WriteLine();
    }
}