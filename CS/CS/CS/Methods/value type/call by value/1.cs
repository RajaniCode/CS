// value types passed by value

// instance method // passing by value // copy of the variable is passed


using System;

class MyClass
{
    public void noChangeMethod(int ap , int bp)
    {
        ap = ap + bp;
        bp = -bp;        
    }
}

class MainClass
{
    static void Main()
    {
        int a = 5;
        int b = 6;
       
        Console.WriteLine("Before calling by value: a = {0}, b = {1} \n", a, b);

        MyClass mc = new MyClass();
        mc.noChangeMethod(a, b);
       
        Console.WriteLine("After calling by value: a = {0}, b = {1} \n", a, b);
     }
}