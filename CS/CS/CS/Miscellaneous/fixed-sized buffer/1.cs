// fixed-sized buffer // only for struct and unsafe // cannot be static // can only be integral type (built-in struct)


using System;

unsafe struct MyStruct // only for unsafe struct
{
    public fixed byte name[80]; // fixed-sized buffer // cannot be static  // 1 X 80 bytes
    public double balance;                                                 // 8 bytes 
    public long ID;                                                        // 8 bytes    
}

struct MainStruct
{
    unsafe static void Main() // unsafe
    {   
        MyStruct ms = new MyStruct();
        ms.name[100] = 255;
                
        ms.balance = 1000D;
        ms.ID = 1234567890L;
        Console.WriteLine("\nms.name[100]: {0}, ms.balance: {1}, ms.ID: {2}\n", ms.name[100], ms.balance, ms.ID);
        Console.WriteLine("\nSize of struct (only instance members) is: {0}\n", sizeof(MyStruct)); // 80 + 8 + 8 = 96 bytes
    }
}


// Compiling unsafe:

// >csc 1.cs /unsafe

// >1
   

// Visual Studio:

// Open the project's Properties page. For details, see How to: Set Project Properties (C#, J#).

// Click the Build property page.

// Select the Allow Unsafe Code check box.
