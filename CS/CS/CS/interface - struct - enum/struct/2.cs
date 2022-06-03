// struct // copy a struct

using System;

struct MyStruct
{
    public int n;
}

class MainClass
{
    static void Main()
    {
        MyStruct ms1;
        MyStruct ms2;

        ms1.n = 10;
        ms2.n = 20;

        Console.WriteLine("ms1.n = {0}, ms2.n = {1}", ms1.n, ms2.n);

        ms1 = ms2; // Note: copies value
     
        ms2.n = 30;
   
        Console.WriteLine("ms1.n = {0}, ms2.n = {1}", ms1.n, ms2.n);
    }
}