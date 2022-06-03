// operator overloading in abstract class // conversion operator class, int // explicit conversion from int to object and from object to int

// Note: Either implicit or explicit should be done


using System;

abstract class BaseClass
{
    int x;    

    public BaseClass()
    {
        x = 0;        
    }

    public BaseClass(int a)
    {
        x = a;        
    }

    public static explicit operator int(BaseClass op1) // Note: return type explicit 
    {
        return op1.x;
    }

    public static explicit operator BaseClass(int op1) // Note: return type explicit 
    {
        return new DerivedClass(op1);
    }

    public void myMethod()
    {
        Console.WriteLine("x = {0}", x);
    }
}

class DerivedClass : BaseClass    
{
    public DerivedClass()
    {

    }

    public DerivedClass(int a) : base(a)
    {

    }            
}

class MainClass
{
    static void Main()
    {
        DerivedClass dc1 = new DerivedClass(1);
        DerivedClass dc2 = new DerivedClass(10);
        DerivedClass dc3 = new DerivedClass();

        Console.WriteLine("Showing dc1");
        dc1.myMethod();
        Console.WriteLine();

        Console.WriteLine("Showing dc2");
        dc2.myMethod();
        Console.WriteLine();

        Console.WriteLine("Showing dc3");
        dc3.myMethod();
        Console.WriteLine();

        int i;
        i = (int)dc1; 
        Console.WriteLine("Showing explicit conversion of object to int: i = (int)dc1: {0}", i);
        Console.WriteLine();

        dc3 = (DerivedClass)i; 
        Console.WriteLine("Showing explicit conversion of int to object: dc3 = (DerivedClass)i: ");
        dc3.myMethod();
        Console.WriteLine();

        dc3 = (DerivedClass)15; 
        Console.WriteLine("Showing explicit conversion of int to object: dc3 = (DerivedClass)15: ");
        dc3.myMethod();                      
    }
}