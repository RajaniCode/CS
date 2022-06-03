using System;

class C
{
    public int x;
}

struct S
{
    public int x;
}

class Program
{
    private void PrintC()
    {
        C a = new C();
        C b = new C();
        a.x = 1;
        b.x = 2;
        Console.WriteLine("Class Before a = b: a.x = {0}, b.x = {1}\n", a.x, b.x); // 1, 2

        a = b;
        a.x = 3;
        Console.WriteLine("Class After a = b and a.x = 3: a.x = {0}, b.x = {1}\n", a.x, b.x); // 3, 3
    }

    private void PrintS()
    {
        S a = new S();
        S b = new S();
        a.x = 1;
        b.x = 2;
        Console.WriteLine("Structure Before a = b a.x = {0}, b.x = {1}\n", a.x, b.x); // 1, 2

        a = b;
        a.x = 3;
        Console.WriteLine("Structure After a = b and a.x = 3: a.x = {0}, b.x = {1}\n", a.x, b.x); // 3, 2
    }

    static void Main()
    {
        Program p = new Program();
        p.PrintC();
        p.PrintS();

        Console.WriteLine("Hello, World!");
    }
}