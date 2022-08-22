// built-in attribute 

// Obsolete


using System;

class MainClass
{
    const bool error = true;

    [Obsolete("Use myMethod2, instead", error)] // Note: generates error, the program will not be compiled
    static int myMethod(int a, int b)
    {
        return a/b;
    }

    static int myMethod2(int a, int b)
    {
        return b == 0 ? 0 : a/b;
    }

    static void Main()
    {
        Console.WriteLine("Result is : {0}", MainClass.myMethod(10, 2));

        Console.WriteLine("Result is : {0}", MainClass.myMethod2(20, 2));
    }
}