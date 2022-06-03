using System;
using System.Collections;
using System.Collections.Generic;

class Digits
{ 
    public IEnumerable<int> GetDigit()
    {
        yield return 0;
        yield return 1;
        yield return 2;
        yield return 3;
        yield return 4;
        yield return 5;
        yield return 6;
        yield return 7;
        yield return 8;
        yield return 9;
    }
}

class Greek : IEnumerable
{
    private string[] alphabet = { "alpha", "beta", "gamma", "delta", "epsilon", "zeta", "eta", "theta", "iota", "kappa", "lambda", "mu", "nu", "xi", "omicron", "pi", "rho", "sigma", "tau", "upsilon", "phi", "chi", "psi", "omega" };

    public IEnumerator GetEnumerator()
    {
        for (int index = 0; index < alphabet.Length; index++)
        {
             yield return alphabet[index];
        }
    }
}

class Characters<T> 
{
    T[] array;

    public Characters(T[] a) 
    {
        array = a;
    }

    public IEnumerator<T> GetEnumerator() 
    {
        foreach(T obj in array)
        {
           yield return obj;
        }
    }
}

class IteratorClient
{
    public void Print()
    {
        Console.WriteLine("Iterators");
        Digits digit = new Digits();
        foreach (int i in digit.GetDigit())
        {
            Console.WriteLine(i);
        }

        Greek gre = new Greek();
        IEnumerator enumerator = gre.GetEnumerator();
        while(enumerator.MoveNext())
        {
            Console.WriteLine(enumerator.Current);
        }

        int[] evenDigits = { 0, 2, 4, 6, 8 };
        Characters<int> evens = new Characters<int>(evenDigits);
        foreach(int i in evens)
        {
    	    Console.WriteLine(i);
        }

    	bool[] booleans = { true, true, false, true };
    	Characters<bool> bools = new Characters<bool>(booleans);

    	foreach(bool b in bools)
        {  
    	    Console.WriteLine(b);
        }
    }

}

class Program
{
    static void Main()
    {
        IteratorClient  iterator = new IteratorClient();
        iterator.Print();
    }
}
