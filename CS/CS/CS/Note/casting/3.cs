// class


using System;

class C
{
    public int x;
}

class MainClass
{
    static void Main()
    {
        C a = new C();
        C b = new C();

        a.x = 10;
        b.x = 20;

        Console.WriteLine(a.x + "," + b.x);

        a = b; // Same as // b = a;
        b.x = 30;

        Console.WriteLine(a.x + "," + b.x);
    }
}