// Property in interface

using System;

interface IInterface
{
    int Property { get; set; }
}

class Program : IInterface
{
    int i = 100;

    //public int Property
    int IInterface.Property // CANNOT DECLARE private
    {
        get
        {
            return i * 3;
        }
        set
        {
            i = value;
        }
    }
     
    static void Main()
    {
        Program P = new Program();

        IInterface Ii = P;

        //Console.WriteLine(P.Property);
        Console.WriteLine(Ii.Property);

        Console.ReadKey();
    }
}