using System;

class WorksInJavaNotInCS 
{
    static void Main()
    {
        A a = new A();
	B b = new B();
	a.Method(b);
    } 
}

public class A 
{
    public void Method(B b) 
    { 
        Console.WriteLine("Hola!");
    }
}

// public // To work in CS // unlike Java
public class B { }