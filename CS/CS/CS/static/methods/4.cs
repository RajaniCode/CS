// instance method in static method in the same class

using System;

class MyClass
{
    void myInstanceMethod()
    {
        Console.WriteLine("Instance Method");
    }

    public static void myStaticMethod(MyClass mcp)
    {        
        mcp.myInstanceMethod();
        Console.WriteLine("Static Method");
    }
}

class MainClass
{
    static void Main()
    {
       MyClass mc = new MyClass();
       MyClass.myStaticMethod(mc);
    }
}
    