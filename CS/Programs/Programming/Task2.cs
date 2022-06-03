using System;

class A
{
    internal virtual void Method()
    {
        Console.WriteLine("Virtual in A");
    }
}

class B : A
{ 
    internal override void Method()
    {
        Console.WriteLine("Override in B");
    }
}

class C : B
{
    internal override void Method()
    {
        Console.WriteLine("Override in C");
    }
}

class Program
{
    static void Main()
    {
        A a = new A();
        B b = new B();
        C c = new C();

        a.Method();
        b.Method();
        c.Method();

        Console.WriteLine("Hello, World!");
    }
}