// params modifier // used to declare array parameter // variable length parameter // along with normal parameter

// value type, no constructor

using System;

class MyClass
{
    public void printMethod(string s, params int[] args)
    {
        Console.WriteLine("Message: {0}", s);
    
        foreach(int i in args)
            Console.Write(i + " ");

        Console.WriteLine("\n");
    }
}

class MainClass
{
    static void Main()
    {
        MyClass mc = new MyClass();
        
        mc.printMethod("Here are some integers", 4, 5, 6, 7, 8);
 
        mc.printMethod("Here are two integers", 45, 67);
    }
}