// operator overloading in abstract class // overloading true and false, must be in pair // do-while loop // also: while, if and for loops


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

    public static bool operator true(BaseClass op1) // an object is true
    {
        if((((DerivedClass)op1).x != 0) && (((DerivedClass)op1).y != 0) && (((DerivedClass)op1).z != 0))
            return true;
        else
            return false;
    }

    public static bool operator false(BaseClass op1) // an object is false
    {
        if((((DerivedClass)op1).x == 0) && (((DerivedClass)op1).y == 0) && (((DerivedClass)op1).z == 0))
            return true;
        else
            return false;
    }

    public static DerivedClass operator --(BaseClass op1)
    {
        ((DerivedClass)op1).x--;
        ((DerivedClass)op1).y--;
        ((DerivedClass)op1).z--;
        
        return (DerivedClass)op1;        
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

        if(dc1)
            Console.WriteLine("dc1 is true \n");
        else
            Console.WriteLine("dc1 is false \n");

        if(dc2)
            Console.WriteLine("dc2 is true \n");
        else
            Console.WriteLine("dc2 is false \n");
  
        if(dc3)
            Console.WriteLine("dc3 is true \n");
        else
            Console.WriteLine("dc3 is false \n");
  
        do                  // Note
        {   dc2.myMethod();  
            dc2--;
        }while(dc2);  

    }
}

 