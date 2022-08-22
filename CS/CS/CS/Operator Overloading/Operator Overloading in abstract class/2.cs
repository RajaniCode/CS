// operator overloading in abstract class // handling built-in types int


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

    public static DerivedClass operator +(BaseClass op1, BaseClass op2)
    {
        DerivedClass dc = new DerivedClass();
  
        dc.x = ((DerivedClass)op1).x + ((DerivedClass)op2).x;
        dc.y = ((DerivedClass)op1).y + ((DerivedClass)op2).y;
        dc.z = ((DerivedClass)op1).z + ((DerivedClass)op2).z;

        return dc;
    }

    public static DerivedClass operator -(BaseClass op1, BaseClass op2)
    {
        DerivedClass dc = new DerivedClass();
  
        dc.x = ((DerivedClass)op1).x - ((DerivedClass)op2).x;
        dc.y = ((DerivedClass)op1).y - ((DerivedClass)op2).y;
        dc.z = ((DerivedClass)op1).z - ((DerivedClass)op2).z;

        return dc;
    }

    public static DerivedClass operator +(BaseClass op1, int op2) // adding int to object
    {
        DerivedClass dc = new DerivedClass();
  
        dc.x = ((DerivedClass)op1).x + op2;
        dc.y = ((DerivedClass)op1).y + op2;
        dc.z = ((DerivedClass)op1).z + op2;

        return dc;
    }

    public static DerivedClass operator +(int op1, BaseClass op2) // adding object to int
    {
        DerivedClass dc = new DerivedClass();
  
        dc.x = op1 + ((DerivedClass)op2).x;
        dc.y = op1 + ((DerivedClass)op2).y;
        dc.z = op1 + ((DerivedClass)op2).z;

        return dc;
    }

    public static DerivedClass operator -(BaseClass op1, int op2) //  subtracting int from object // Note: the order of parameters as per the subtraction
    {
        DerivedClass dc = new DerivedClass();
  
        dc.x = ((DerivedClass)op1).x - op2;
        dc.y = ((DerivedClass)op1).y - op2;
        dc.z = ((DerivedClass)op1).z - op2;

        return dc;
    }

    public static DerivedClass operator -(int op1, BaseClass op2) //  subtracting object from int // Note: the order of parameters as per the subtraction
    {
        DerivedClass dc = new DerivedClass();
  
        dc.x = op1 - ((DerivedClass)op2).x;
        dc.y = op1 - ((DerivedClass)op2).y;
        dc.z = op1 - ((DerivedClass)op2).z;

        return dc;
    }

    public void myMethod()
    {
        Console.WriteLine("x = {0}, y = {1}, z = {2}", x,y,z);
    }
} 

class DerivedClass : BaseClass
{
    public DerivedClass()
    {

    }

    public DerivedClass(int a, int b, int c)
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

        dc3 = dc1 + dc2;
        Console.WriteLine("Showing dc3 = dc1 + dc2");
        dc3.myMethod();
        Console.WriteLine();

        dc3 = dc2 - dc1;
        Console.WriteLine("Showing dc3 = dc2 - dc1");
        dc1.myMethod();
        Console.WriteLine();

        dc3 = dc1 + dc2;
        Console.WriteLine("Showing dc3 = dc1 + dc2");
        dc3.myMethod();
        Console.WriteLine();

        dc3 = dc1 + 100; // Note: assignment operator should be used, otherwise it becomes an increment
        Console.WriteLine("Showing dc3 = dc1 + 100");
        dc3.myMethod();
        Console.WriteLine();

        dc3 = 100 + dc1; // Note: assignment operator should be used, otherwise it becomes an increment
        Console.WriteLine("Showing dc3 = 100 + dc1");
        dc3.myMethod();
        Console.WriteLine();
    
        dc3 = dc1 - 10; // Note: assignment operator should be used, otherwise it becomes a decrement
        Console.WriteLine("Showing dc3 = dc1 - 10");
        dc3.myMethod();
        Console.WriteLine();

        dc3 = 10 - dc1; // Note: assignment operator should be used, otherwise it becomes a decrement
        Console.WriteLine("Showing dc3 = 10 - dc1");
        dc3.myMethod();
        Console.WriteLine();
    }
}
         
         

