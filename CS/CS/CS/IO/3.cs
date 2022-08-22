// I/O // Console.In.ReadLine()

using System;

class MyClass
{
    static void Main()
    {
        Console.WriteLine("Enter the string");
        string s = (string) Console.In.ReadLine(); // Note: No further input
        Console.WriteLine("The string you entered is {0}", s);        
    }
}
  
     
