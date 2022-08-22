using System;
using CipherLibrary;

class MainClass
{
    static void Main()
    {
        CipherComponent cc = new CipherComponent();

        string text = "This is a test";

        string encodetext = cc.Encode(text);

        Console.WriteLine("The encoded text is = {0}", encodetext);

        string decodedtext = cc.Decode(encodetext);

        Console.WriteLine("The decoded text is = {0}",decodedtext);  

        cc.Dispose(); // free resources
    }
}
        