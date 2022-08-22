// static method in instance method in different class

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
    public void myInstanceMethodB()
    {
        A.myStaticMethodA();
        Console.WriteLine("Instance Method B");
    }
}

class MainClass
{
    static void Main()
    {
        B b = new B();
        b.myInstanceMethodB();
    }
}
    