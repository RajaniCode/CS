// instance method in instance method in the same class

using System;

class MyClass
{
    void myInstanceMethod1()
    {
        Console.WriteLine("Instance Method 1");
    }

    public void myInstanceMethod2()
    {
        myInstanceMethod1();
        Console.WriteLine("Instance Method 2");
    }
}

class MainClass
{
    static void Main()
    {
       MyClass mc = new MyClass();
       mc.myInstanceMethod2();
    }
}
    