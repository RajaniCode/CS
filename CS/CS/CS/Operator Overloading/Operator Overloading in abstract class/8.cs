// operator overloading in abstract class // conversion operator int // explicit conversion of object to int

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

    public static explicit operator int(BaseClass op1) // Note: return type explicit 
    {
        return op1.x * op1.y * op1.z;
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
        i = (int)dc1; 
        Console.WriteLine("Showing explicit conversion of object to int: i = (int)dc1: {0} \n", i);

        i = (int)dc1 * 2 - (int)dc2; 
        Console.WriteLine("Showing explicit conversion of object to int: i = (int)dc1 * 2 - (int)dc2: {0} \n", i); 

        i = (int)dc1 + (int)dc2; // Note
        Console.WriteLine("Showing explicit conversion of object to int: i = (int)dc1 + (int)dc2: {0} \n", i);          
    }
}