// enum // named constants can only be alphanumeric (should start with alphabet), should be unique and should not be in quotation

// Using the FlagsAttribute on enumerations.


using System;

[Flags] // Note // Check without this
public enum CarOptions
{
    SunRoof = 0x01,      // hexadecimal //2^n // 2^0 = 1 = 00000001 // binay 
    Spoiler = 0x02,                     //2^n // 2^1 = 2 = 00000010  
    FogLights = 0x04,                   //2^n // 2^2 = 4 = 00000100 
    TintedWindows = 0x08,               //2^n // 2^3 = 8 = 00001000
}

class FlagTest
{
    static void Main()
    {
        CarOptions options = CarOptions.SunRoof | CarOptions.FogLights;
        // 00000001 
        // Flagging with the bitwise operator OR: '|'
        // 00000100 
        // 00000101 is what you get whose corresponding decimal value is 5


        Console.WriteLine(options);

        Console.WriteLine((int)options); // Hence 5
    }
}


/*
Some simple bitwise operations include:

The AND operation, only returns 1 if both are true

Code: ( text )
1 & 0 = 0
0 & 1 = 0
1 & 1 = 1
0 & 0 = 0


The OR operation, returns 1 if either are true
1 | 0 = 1
0 | 1 = 1
1 | 1 = 1
0 | 0 = 0


The NOT operation returns 1 if the bit is 0
~1 = 0
~0 = 1


The XOR operation returns 1 if the bits are different
1 ^ 0 = 1
0 ^ 1 = 1
1 ^ 1 = 0
0 ^ 0 = 0
*/