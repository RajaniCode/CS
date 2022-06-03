// operator overloading in abstract class // relational operator // Note: relational operators must be overloaded in pairs < and >, == and !=, <= and >=


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

    public static bool operator <(BaseClass op1, BaseClass op2) // Comparing objects
    {
        if((((DerivedClass)op1).x < ((DerivedClass)op2).x) && (((DerivedClass)op1).y < ((DerivedClass)op2).y) && (((DerivedClass)op1).z < ((DerivedClass)op2).z))
            return true;
        else
            return false;
    }

    public static bool operator >(BaseClass op1, BaseClass op2) // Comparing objects
    {
        if((((DerivedClass)op1).x > ((DerivedClass)op2).x) && (((DerivedClass)op1).y > ((DerivedClass)op2).y) && (((DerivedClass)op1).z > ((DerivedClass)op2).z))
            return true;
        else
            return false;
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

class MainClass //
{ //
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

        if(dc1 < dc2) 
            Console.WriteLine("dc1 < dc2 is true \n");
        else
            Console.WriteLine("dc1 < dc2 is false \n");

        if(dc1 < dc3) 
            Console.WriteLine("dc1 < dc3 is true \n");
        else
            Console.WriteLine("dc1 < dc3 is false \n");

        if(dc1 > dc2) 
            Console.WriteLine("dc1 > dc2 is true \n");
        else
            Console.WriteLine("dc1 > dc2 is false \n");

        if(dc1 > dc3) 
            Console.WriteLine("dc1 > dc3 is true \n");
        else
            Console.WriteLine("dc1 > dc3 is false \n"); 
    }
}        