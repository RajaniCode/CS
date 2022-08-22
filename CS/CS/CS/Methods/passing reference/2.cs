// passing reference

// objects passed by reference

using System;

class MyClass
{
    public int a;
    public int b;

    public MyClass(int k, int l)
    {
        a = k;
        b = l;
    }


    public void printMethod()
    {
        Console.WriteLine("printMethod: a = {0}, b = {1}", a, b);
    }

    public void changeMethod(MyClass mcp)
    {
       mcp.a = mcp.a + mcp.b;
       mcp.b = -mcp.b;
    }
}

class MainClass
{
    static void Main()
    {
        MyClass mc1 = new MyClass(15, 20);
       
        Console.WriteLine("a = {0}, b = {1}", mc1.a, mc1.b);
        mc1.printMethod();
       
        mc1.changeMethod(mc1);

        Console.WriteLine("a = {0}, b = {1}", mc1.a, mc1.b);
        mc1.printMethod();       
    }
}