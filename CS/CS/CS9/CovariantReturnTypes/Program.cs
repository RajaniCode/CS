using System;

class A 
{ 
    public virtual A VirtualMethodA() => new();
}

class B : A 
{ 
    // C# 9.0 Covariant return types
    /*
     C# 9.0 Overridden virtual function can return a type derived from the return type declared in the base class method
    */
    public override B VirtualMethodA() => new();
    // public override C VirtualMethodA() => new();
}

class C : B { }

class Program
{
    static void Main()
    {
        B b = new();
        b.VirtualMethodA();
        Console.WriteLine("Hello, World!");
    }
}


// Console
/*
$ dotnet --version
5.0.100-rc.2.20479.15

$ dotnet run
Hello, World!
*/