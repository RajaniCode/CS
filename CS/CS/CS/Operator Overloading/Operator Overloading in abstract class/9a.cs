// operator overloading in abstract class // conversion operators class, int // implicit conversion from int to object and from object to int

// Note: Either implicit or explicit should be done

// #Note


using System;

abstract class BaseClass
{
    public int x;  // #Note
    
    public BaseClass()
    {
        x = 0;                
    }

    public BaseClass(int a)
    {
        x = a;               
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

    public static implicit operator int(DerivedClass op1) // #Note
    {
        return op1.x;
    }

    public static implicit operator DerivedClass(int op1) // #Note
    {
        return new DerivedClass(op1);
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
        i = dc1; 
        Console.WriteLine("Showing implicit conversion of object to int: i = dc1: {0}", i);
        Console.WriteLine();

        dc3 = i; 
        Console.WriteLine("Showing implicit conversion of int to object: dc3 = i: ");
        dc3.myMethod();
        Console.WriteLine();

        dc3 = 15; 
        Console.WriteLine("Showing implicit conversion of int to object: dc3 = 15: ");
        dc3.myMethod();                            
    }
}