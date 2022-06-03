// string[] args

using System;

class MainClass
{
    static void Main(string[] args) // String[] args
    {
       try
       {
           Console.WriteLine("Hello, {0} and {1}!", args[0], args[1]);
           Console.WriteLine("Welcome to C#!");
       }
       catch(Exception)
       {

       }
    }       
} 


// >csc 2.cs

// >2 USA UK
