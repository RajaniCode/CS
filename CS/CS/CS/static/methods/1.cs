// static method in instance method in the same class

using System;

class MyClass
{
    static void myStaticMethod()
    {
        Console.WriteLine("Static Method");
    }

    public void myInstanceMethod()
    {
        myStaticMethod();
        Console.WriteLine("Instance Method");
    }
}

class MainClass
{
    static void Main()
    {
        MyClass mc = new MyClass();
        mc.myInstanceMethod();
    }
}
    