// built-in attribute 

// Obsolete


using System;

class MainClass
{
    [Obsolete("Use myMethod2, instead")] // Note: generates compilation warning
    int myMethod(int a, int b)
    {
        return a/b;
    }

    int myMethod2(int a, int b)
    {
        return b == 0 ? 0 : a/b;
    }

    static void Main()
    {
        MainClass mc = new MainClass();

        Console.WriteLine("Result is : {0}", mc.myMethod(10, 2));

        Console.WriteLine("Result is : {0}", mc.myMethod2(20, 2));
    }
}