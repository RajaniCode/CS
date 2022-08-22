// instance method in instance method in different class

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
    public void myInstanceMethodB(A ap)
    {        
        ap.myInstanceMethodA();
        Console.WriteLine("Instance Method B");
    }
}

class MainClass
{
    static void Main()
    {
        A a = new A();
        B b = new B();
        b.myInstanceMethodB(a);
    }
}
    