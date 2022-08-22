// static method in static method in different class

using System;

class A
{
    public static void myStaticMethodA()
    {
        Console.WriteLine("Static Method A");
    }    
}

class B
{
    public static void myStaticMethodB()
    {
        A.myStaticMethodA();
        Console.WriteLine("Static Method B");
    }
}

class MainClass
{
    static void Main()
    {
        B.myStaticMethodB();
    }
}
    