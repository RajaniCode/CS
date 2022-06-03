// assembly


using System;

class MyClass
{
    int x;
    int y;
    
    public MyClass(int k)
    {
        x = y = k;
    }

    public MyClass(int k, int l)
    {
        x = k;
        y = l;
    }
    
    public int additionMethod()
    {
        return x + y;
    }

    public bool isBetweenMethod(int a)
    {
        if((x<a) && (a<y))
            return true;
        else
            return false;
    }

    public void setMethod(int a, int b)
    {
        Console.Write("Inside setMethod(int a, int b): ");
        x = a;
        y = b;
        printMethod();
    }

    public void setMethod(double a, double b)
    {
        Console.Write("Inside setMethod(double a, double b): ");
        x = (int)a;
        y = (int)b;
        printMethod();
    }

    public void printMethod()
    {
        Console.WriteLine("x = {0}, y = {1}", x, y);
    }
}

class AnotherClass
{
    string remark;

    public AnotherClass(string s)
    {
        remark = s;
    }

    public void printMethod()
    {
        Console.WriteLine("remake = {0}", remark);
    }
}

class MainClass
{
    static void Main()
    {
        Console.WriteLine("This is a placeholder.");
    }
}