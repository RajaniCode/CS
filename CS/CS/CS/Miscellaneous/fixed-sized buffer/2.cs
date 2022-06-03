// fixed-sized buffer // only for struct and unsafe // cannot be static // can only be integral type (built-in struct)

// with static variables // using System.Runtime.InteropServices;

// Marshal.SizeOf() // for integral types for InteropServices // using System.Runtime.InteropServices; 


using System;
using System.Runtime.InteropServices;

unsafe struct MyStruct // only for unsafe struct
{
    public fixed byte name[80]; // fixed-sized buffer // cannot be static  // 1 X 80 bytes
    public static double balance;                                          // 8 bytes 
    public static long ID;                                                 // 8 bytes 
}

struct MainStruct
{
    unsafe static void Main() // unsafe
    {   
        MyStruct ms = new MyStruct();
        ms.name[100] = 255;
                
        MyStruct.balance = 1000D;
        MyStruct.ID = 1234567890L;
        Console.WriteLine("\nms.name[100]: {0}, MyStruct.balance: {1}, MyStruct.ID: {2}\n", ms.name[100], MyStruct.balance, MyStruct.ID);
        Console.WriteLine("\nSize of struct (only instance members) is: {0}\n", sizeof(MyStruct)); // 80 bytes
        Console.WriteLine("\nSize of static balance: {0}\n", Marshal.SizeOf(MyStruct.balance));    // 8 bytes
        Console.WriteLine("\nSize of static ID is: {0}\n", Marshal.SizeOf(MyStruct.ID));           // 8 bytes
              
    }
}


// Compiling unsafe:

// >csc 1.cs /unsafe

// >1
   

// Visual Studio:

// Open the project's Properties page. For details, see How to: Set Project Properties (C#, J#).

// Click the Build property page.

// Select the Allow Unsafe Code check box.
