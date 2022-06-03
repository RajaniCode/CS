// instance method in static method in different class

using System;

class A
{
    public void myInstanceMethodA()
    {
        Console.WriteLine("Instance Method A");
    }    
}

class B
{
    public static void myStaticMethodB(A ap)
    {        
        ap.myInstanceMethodA();
        Console.WriteLine("Static Method B");
    }
}

class MainClass
{
    static void Main()
    {
        A a = new A();
        B.myStaticMethodB(a);
    }
}
    