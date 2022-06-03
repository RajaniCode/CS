// operator overloading in abstract class // conversion operator int // implicit conversion from object to int 

// Note: Either implicit or explicit should be done


using System;

abstract class BaseClass 
{
    int x;
    int y;
    int z;

    public BaseClass()
    {
        x = 0;
        y = 0;
        z = 0;
    }

    public BaseClass(int a , int b, int c)
    {
        x = a;
        y = b;
        z = c;
    }

    public static implicit operator int(BaseClass op1) // Note: return type implicit 
    {
        return op1.x * op1.y * op1.z; // Note
    }

    public void myMethod()
    {
        Console.WriteLine("x = {0}, y = {1}, z = {2}", x, y, z);
    }
}

class DerivedClass : BaseClass    
{
    public DerivedClass()
    {

    }

    public DerivedClass(int a, int b, int c) : base(a, b, c)
    {

    }            
}

class MainClass
{
    static void Main()
    {
        DerivedClass dc1 = new DerivedClass(1, 2, 3);
        DerivedClass dc2 = new DerivedClass(10, 10, 10);
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
        Console.WriteLine("Showing implicit conversion of object to int: i = dc1: {0} \n", i);  // Note: print

        i = dc1 * 2 - dc2;
        Console.WriteLine("Showing implicit conversion of object to int: i = dc1 * 2 - dc2: {0} \n", i);  // Note: print

        i = dc1 + dc2; // Note: Not adding objects 
        Console.WriteLine("Showing implicit conversion of object to int: i = dc1 + dc2: {0} \n", i);  // Note: print         
    }  
}