// value types also passed by reference using 'ref' keyword 

// instance method // passing by reference // using 'ref' keyword // memory address of the variable is passed


using System;

class MyClass
{
    public void swapMethod(ref int ap, ref int  bp)
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
        mc.swapMethod(ref a, ref b);

        Console.WriteLine("After call by reference: a = {0}, b = {1}", a, b);
    }
}

       