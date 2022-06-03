// 1.cs and 1a.cs executed as a single assembly


using System;

class AssemblyClass               // internal
{
    internal static void staticMethod() // internal
    {
        Console.WriteLine("\nstaticMethod() in AssemblyClass\n");
    }

    internal void instanceMethod()      // internal
    {
        Console.WriteLine("\ninstanceMethod() in AssemblyClass\n");
    }     
} 


//>>csc 1.cs 1a.cs

//>>1