// protected // CS // Java
using System;

class Program
{
    static void Main()
    {
        A a = new A();
        B b = new B();
        C c = new C();

        // a = b; // 
        // b = (B)a; // Exception b = (B)a; // When a = b is commented out
        b = a as B; // No Exception // When a = b is commented out // warning CS8600: Converting null literal or possible null value to non-nullable type. // No as keyword in Java

        B.MethodB();
        c.Method();
    }
}

class A
{
    // No internal access specifier in Java // default access in Java is within the same package unlike C# where default is private
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
    // No internal access specifier in Java // default access in Java is within the same package unlike C# where default is private
    // Scenarios // sealed // public // int
    internal override void Method()
    {
        Console.WriteLine("Override in B");
        // return 1;
    }

    // Scenario: static
    public static void MethodB()
    { 
        A a = new A();
        B b = new B();
        C c = new C();

        // MethodA(); // Scenario: static
        // this.MethodA(); // Scenario: static
        // base.MethodA(); // Scenario: static
        // a.MethodA(); // Note: // protected // Unlike Java where protected is accessible from derived class class in the same/different package // C# protected is accessible from derived class in same/different/friend assembly via derived class instance only
        b.MethodA();
        c.MethodA();
        Console.WriteLine("Method B");
    }
}

class C : B
{
    // No internal access specifier in Java // default access in Java is within the same package unlike C# where default is private
    internal override void Method()
    {
        Console.WriteLine("Override in C");
    }
}

// Output
/*
/Users/rajaniapple/Desktop/Mnemonics/Protected/Program.cs(14,13): warning CS8600: Converting null literal or possible null value to non-nullable type. [/Users/rajaniapple/Desktop/Mnemonics/Protected/Protected.csproj]
Method in A
Method in A
Method B
Override in C
*/