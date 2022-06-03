// Assembly shared with friend assembly


using System;
using System.Runtime.CompilerServices;  // NOTE
                                          
[assembly:InternalsVisibleTo("1")]      // declaring friend assembly
struct AssemblyStruct               // internal (default)
{                                       
    internal static void staticMethod() // internal
    {                                    
        Console.WriteLine("\nstaticMethod() shared with friend assembly\n");
    }                                   
                                         
    internal void instanceMethod()      // internal
    {
        Console.WriteLine("\ninstanceMethod() shared with friend assembly\n");
    }  

    static void Main() // Note
    {

    }   
} 


//>csc 1a.cs

//>csc /r:1a.exe /out:1.exe 1.cs

//>1