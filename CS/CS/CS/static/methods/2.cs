// static method in static method in the same class

using System;

class MyClass
{
    static void myStaticMethod1()
    {
        Console.WriteLine("Static Method 1");
    }

    public static void myStaticMethod2()
    {
        myStaticMethod1();
        Console.WriteLine("Static Method 2");
    }
}

class MainClass
{
    static void Main()
    {
        MyClass.myStaticMethod2();
    }
}
    