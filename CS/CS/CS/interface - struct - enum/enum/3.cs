// enum // named constants can only be alphanumeric (should start with alphabet), should be unique and should not be in quotation


using System;

class MainClass
{
    enum Rainbow : byte {Violet, Indigo, Blue, Green, Yellow, Orange, Red}; // can be any integral type except char

    static void Main()
    {
        Rainbow r;

        for(r=Rainbow.Violet; r<=Rainbow.Red; r++) // for(r=0; r<=(Rainbow)6; r++)
            Console.WriteLine(r + " has value of " + (byte)r); // Note
    }
}