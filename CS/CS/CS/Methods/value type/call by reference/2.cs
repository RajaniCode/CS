// value types also passed by reference using 'ref' keyword

// static method // passing by reference // using 'ref' keyword // memory address of the variable is passed


using System;

class MyClass
{
    public static void changeMethod(ref int ap, ref int bp)
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
       
        Console.WriteLine("Before calling by reference : a = {0}, b = {1} \n", a, b);

        MyClass.changeMethod(ref a, ref b);
       
        Console.WriteLine("After calling by reference: a = {0}, b = {1} \n", a, b);
     }
}