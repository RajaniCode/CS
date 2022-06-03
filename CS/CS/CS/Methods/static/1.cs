// static // Also: static public


using System;

class MyClass
{
    public static int x = 100;

    public static int myMethod()
    {  
        // return x = x / 2; // x assigned
        return x/2;  // x unassigned // Note: the difference 
    }
}

class MainClass
{
    public static void Main()
    {
        Console.WriteLine("Value of x = {0}", MyClass.x);
      
        MyClass.x = 8;

        Console.WriteLine("Value of x = {0}", MyClass.myMethod());

        Console.WriteLine("Value of x = {0}", MyClass.x); //
    }
}