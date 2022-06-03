// I/O // Console.Read()

using System;

class MyClass
{
    static void Main()
    {
        Console.WriteLine("Enter the char");
        char c = (char) Console.Read(); // Note: No further input
        Console.WriteLine("The char you entered is {0}", c);        
    }
}
  
     
