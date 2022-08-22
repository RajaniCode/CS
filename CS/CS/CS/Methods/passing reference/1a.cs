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

    public void copyMethod(MyClass mcp)
    {
       a = mcp.a;
       b = mcp.b;
    }

    public bool isSameMethod(MyClass mcp)
    {
        if((a==mcp.a) && (b==mcp.b))
            return true;
        else
            return false;
    }     
}

class MainClass
{
    static void Main()
    {
        MyClass mc1 = new MyClass(5, 6);
        MyClass mc2 = new MyClass(7, 8);
        
        Console.WriteLine("a = {0}, b = {1}", mc1.a, mc1.b);
        Console.WriteLine("a = {0}, b = {1}", mc2.a, mc2.b);
        mc1.printMethod();
        mc2.printMethod();

        if(mc1.isSameMethod(mc2))
            Console.WriteLine("mc1 and mc2 have same values");
        else
            Console.WriteLine("mc1 and mc2 do not have same values");

        mc1.copyMethod(mc2); // different from mc2.copyMethod(mc2);

        Console.WriteLine("a = {0}, b = {1}", mc1.a, mc1.b);
        Console.WriteLine("a = {0}, b = {1}", mc2.a, mc2.b);
        mc1.printMethod();
        mc2.printMethod();

        
        if(mc1.isSameMethod(mc2))
            Console.WriteLine("mc1 and mc2 have same values");
        else
            Console.WriteLine("mc1 and mc2 do not have same values");
    }
}