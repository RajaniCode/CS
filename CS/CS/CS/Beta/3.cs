using System;

class R 
{
    public int i;
}


struct V
{
    public int i;
}

class MainClass
{
    static void Main()
    {
        R a = new R();
        R b = new R();

        a.i = 1;
        b.i = 2;

        a = b; // b = a;        

        a.i = 3;

        Console.WriteLine("a.i = {0}, b.i = {1}", a.i, b.i);

        V x;
        V y;

        x.i = 4;
        y.i = 5;

        x = y; // y = x;        

        x.i = 6;

        Console.WriteLine("x.i = {0}, y.i = {1}", x.i, y.i);
    }
}
         