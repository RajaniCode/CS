// value types passed by value 

// instance method // passing by value // copy of the variable is passed


using System;

class MyClass
{
    public void swapMethod(int ap, int bp)
    {
        int t;
        
        t = ap;
        ap = bp;
        bp = t;
    }
}

class MainClass
{ 
    static void Main()
    {
        int a = 10;
        int b = 20;

        Console.WriteLine("Before call by reference: a = {0}, b = {1}", a, b);
        
        MyClass mc = new MyClass();        
        mc.swapMethod(a, b); // Note: Will not swap

        Console.WriteLine("After call by reference: a = {0}, b = {1}", a, b);
    }
}

       