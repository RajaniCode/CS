// runtime type identification // typeof operator

using System;
using System.IO; // Note

class MyClass
{
    static void Main()
    {
        Type t = typeof(StreamReader); // Note: System.IO.StreamReader

        Console.WriteLine(t.FullName);
        
       if(t.IsClass)
           Console.WriteLine("StreamReader is a class");
       
       if(!t.IsAbstract)
           Console.WriteLine("StreamReader is not an abstract but a concrete class");
    }
}