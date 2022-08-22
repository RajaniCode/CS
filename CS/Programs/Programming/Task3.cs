using System;

class A
{
    protected void MethodA()
    {
        Console.WriteLine("Method in A");
    }
}

class B : A
{ 
    public void MethodB()
    { 
        // Call MethodA();
        Console.WriteLine("Method in B");
    }

    public static void StaticMethodB()
    { 
        // Call MethodA();
        Console.WriteLine("Static Method in B");
    }
}

class C : B
{

}

class Program
{
    static void Main()
    {
        A a = new A();
        B b = new B();
        C c = new C();

        Console.WriteLine("Hello, World!");
    }
}