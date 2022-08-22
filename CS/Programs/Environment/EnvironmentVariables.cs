using System;

class Program
{
    private void Print()
    {
        Console.WriteLine("Environment Variables");        
        foreach (System.Collections.DictionaryEntry de in Environment.GetEnvironmentVariables())
        {
            Console.WriteLine($"{de.Key} = {de.Value}");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Program prgm = new Program();
        prgm.Print();
    }
}

