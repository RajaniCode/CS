// copy a struct VS copy a class

using System;

class MyClass
{
    public int n;
}

class MainClass
{
    static void Main()
    {
        MyClass mc1 = new MyClass(); // Note
        MyClass mc2 = new MyClass(); // Note

        mc1.n = 10;
        mc2.n = 20;

        Console.WriteLine("mc1.n = {0}, mc2.n = {1}", mc1.n, mc2.n);

        mc1 = mc2; // Note: copies reference
     
        mc2.n = 30; // Also same result if mc1.n = 30;
   
        Console.WriteLine("mc1.n = {0}, mc2.n = {1}", mc1.n, mc2.n);
    }
}