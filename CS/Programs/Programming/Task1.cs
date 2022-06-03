using System;

class A
{
    internal virtual void Method()
    {
        Console.WriteLine("Virtual in A");
    }

    // protected
    protected void MethodA()
    {
        Console.WriteLine("Method in A");
    }
}

class B : A
{ 
    // sealed // public // int
    internal override void Method()
    {
        Console.WriteLine("Override in B");
        // return 1;
    }

    // static
    public void MethodB()
    { 
        A a = new A();
        B b = new B();
        C c = new C();

        MethodA(); // static ?
        this.MethodA(); // static ?
        base.MethodA(); // static ?
        // a.MethodA(); // protected // Unlike Java
        b.MethodA();
        c.MethodA();
        Console.WriteLine("Method B");
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

        a = b; // 
        b = (B)a; // Exception b = (B)a; // When a = b is commented out
        // b = a as B; // No Exception // When a = b is commented out // Unlike Java

        Console.WriteLine("Hello, World!");
    }
}