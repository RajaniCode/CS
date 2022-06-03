// Method Overloading // ref and out //  cannot define overloaded methods that differ only on ref and out

// static method


using System;

class MyClass
{
    
    public static void myMethod(ref int ap)
    {  
        ap = -ap;            
    }

    public static void myMethod(int ap, out int bp) 
    {  
        ap = 10; // Note: no effect
        bp = 10; // Note: should be assigned, not unassigned like bp = - bp;           
    }
} 


class MainClass
{
    static void Main()
    {
        int a = 5;
        int b = 6;
 
        Console.WriteLine("Before passing: a = {0}, b = {1}", a, b);

        MyClass.myMethod(ref a);        
   
        Console.WriteLine("After passing (ref a): a = {0}", a);

        MyClass.myMethod(a, out b);

        Console.WriteLine("After passing (a, out b) a = {0}, b = {1}", a, b);
    }
}
    
