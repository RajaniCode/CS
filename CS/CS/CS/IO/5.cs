// I/O // Console.Out.WriteLine() // Console.Error.WriteLine(

using System;

class MyClass
{
    static void Main()
    {
        int a = 10;
        int b = 0;
        int c;  
      
        Console.Out.WriteLine("This will generate an exception");
 
        try
        {
            c = a/b;
        }
        catch(DivideByZeroException e)
        {
            Console.Error.WriteLine(e.Message);
        }
    }
}            