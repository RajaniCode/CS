// struct


using System;

struct S
{
    public int x;
}

class MainClass
{
    static void Main()
    {
        S a = new S();
        S b = new S();

        a.x = 10;
        b.x = 20;

        Console.WriteLine(a.x + "," + b.x);

        a = b; // Different when // b = a;
        b.x = 30;

        Console.WriteLine(a.x + "," + b.x);
    }
}