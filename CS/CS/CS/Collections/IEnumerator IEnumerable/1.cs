// IEnumerator // IEnumerable


using System;
using System.Collections;

class ExampleClass : IEnumerator, IEnumerable
{
    char[] chrs = {'A', 'B', 'C', 'D'};

    int idx = -1;

    public IEnumerator GetEnumerator() // Must be public
    {
        return this;
    }

    public object Current // Must be public
    {
        get
        {
            return chrs[idx];
        }
    
    }
    
    public bool MoveNext() // Must be public
    {
        if(idx == chrs.Length-1)
        {
            Reset();
            return false;   
        }
        idx++;
        return true;
    }

    public void Reset() // Must be public
    {  
        idx = -1;
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