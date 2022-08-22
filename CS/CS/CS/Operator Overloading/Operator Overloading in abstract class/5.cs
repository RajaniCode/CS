// operator overloading in abstract class // logical operators &, |, ! 

// although the logical operators short circuit &&,|| cannot be overloaded, their benefits can still be obtained by following certain rules


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

    public BaseClass(int a, int b, int c)
    {
        x = a;
        y = b;
        z = c;
    }

    public static bool operator &(BaseClass op1, BaseClass op2)
    {
        if(((((DerivedClass)op1).x != 0) && (((DerivedClass)op1).y != 0) && (((DerivedClass)op1).z != 0)) & ((((DerivedClass)op2).x != 0) && (((DerivedClass)op2).y != 0) && (((DerivedClass)op2).z != 0)))
            return true;
        else
            return false;
    }

    public static bool operator |(BaseClass op1, BaseClass op2)
    {
        if(((((DerivedClass)op1).x != 0) || (((DerivedClass)op1).y != 0) || (((DerivedClass)op1).z != 0)) | ((((DerivedClass)op2).x != 0) || (((DerivedClass)op2).y != 0) || (((DerivedClass)op2).z != 0)))
            return true;
        else
            return false;
    }

    // **Note: Nothing to do with overloading &, | 
    public static bool operator !(BaseClass op1) 
    {
        
        if((((DerivedClass)op1).x != 0) || (((DerivedClass)op1).y != 0) || (((DerivedClass)op1).z != 0)) // also: if((((DerivedClass)op1).x != 0) | (((DerivedClass)op1).y != 0) | (((DerivedClass)op1).z != 0))  // check using &&, &
            return false; // Note
        else
            return true;
    }   

    public void myMethod()
    {
        Console.WriteLine("x = {0}, y = {1}, z = {2}", x, y, z);
    }

    static void Main()
    {
        DerivedClass dc1 = new DerivedClass(1, 1, 1);
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

        if(dc1 & dc2)
            Console.WriteLine("dc1 & dc2 is true");
        else
            Console.WriteLine("dc1 & dc2 is flase");
 
        if(dc1 & dc3)
            Console.WriteLine("dc1 & dc3 is true");
        else
            Console.WriteLine("dc1 & dc3 is flase");

        if(dc1 | dc2)
            Console.WriteLine("dc1 | dc2 is true");
        else
            Console.WriteLine("dc1 | dc2 is flase");

        if(dc1 | dc3)
            Console.WriteLine("dc1 | dc3 is true");
        else
            Console.WriteLine("dc1 | dc3 is flase");

        if(!dc1) // Note
            Console.WriteLine("dc1 is false"); // Note
        else 
            Console.WriteLine("dc1 is true");

        if(!dc2) // Note
            Console.WriteLine("dc2 is false"); // Note
        else 
            Console.WriteLine("dc2 is true");

        if(!dc3) // Note
            Console.WriteLine("dc3 is false"); // Note
        else 
            Console.WriteLine("dc3 is true"); 
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