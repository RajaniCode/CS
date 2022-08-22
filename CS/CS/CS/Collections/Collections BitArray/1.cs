// BitArray


using System;
using System.Collections;

class MainClass
{

    static void ShowBits(string str, BitArray ba)
    {
        Console.Write(str);
        
        for(int i=0; i<ba.Count; i++)
        {
            Console.Write("{0, -6}", ba[i]);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        byte[] b = {100};

        // BitArray ba1 = new BitArray(b);

        BitArray ba1 = new BitArray(8); // Note: 8 Bits in a Byte 	

        BitArray ba2 = new BitArray(b);

        ShowBits("ba1                : ", ba1);

        ba1 = ba1.Not();

        ShowBits("ba1 = ba1.Not()    : ", ba1);

        ShowBits("BitArray ba2       : ", ba2);

        ba2 =  ba1.Xor(ba2);

        ShowBits("ba2 =  ba1.Xor(ba2): ", ba2);

    }  

}
