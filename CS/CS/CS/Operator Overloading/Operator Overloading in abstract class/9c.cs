// operator overloading in abstract class // for nybble // conversionoperator class, int // explicit conversion of object to int and int to object

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
        x = x & 0xF; // Note
    }

    public static DerivedClass operator +(BaseClass op1, BaseClass op2)
    {
        DerivedClass dc = new DerivedClass();
   
        dc.x = ((DerivedClass)op1).x + ((DerivedClass)op2).x;

        dc.x = dc.x & 0xF; // Note: nybble
        
        return dc;
    }

    public static DerivedClass operator -(BaseClass op1, BaseClass op2)
    {
        DerivedClass dc = new DerivedClass();
   
        dc.x = ((DerivedClass)op1).x - ((DerivedClass)op2).x;

        dc.x = dc.x & 0xF; // Note: nybble
        
        return dc;
    }

    public static DerivedClass operator +(BaseClass op1, int op2)
    {
        DerivedClass dc = new DerivedClass();
   
        dc.x = ((DerivedClass)op1).x + op2;
        
        dc.x = dc.x & 0xF; // Note: nybble

        return dc;
    }
  
    public static DerivedClass operator +(int op1, BaseClass op2)
    {
        DerivedClass dc = new DerivedClass();
   
        dc.x = op1 + ((DerivedClass)op2).x;

        dc.x = dc.x & 0xF; // Note: nybble
        
        return dc;
    }

    public static DerivedClass operator -(BaseClass op1, int op2)
    {
        DerivedClass dc = new DerivedClass();
   
        dc.x = ((DerivedClass)op1).x - op2;
        
        dc.x = dc.x & 0xF;// Note: nybble

        return dc;
    }

    public static DerivedClass operator -(int op1, BaseClass op2)
    {
        DerivedClass dc = new DerivedClass();
   
        dc.x = op1 - ((DerivedClass)op2).x;

        dc.x = dc.x & 0xF; // Note: nybble
        
        return dc;
    }

    public static DerivedClass operator ++(BaseClass op1)
    { 
        ((DerivedClass)op1).x++;

        ((DerivedClass)op1).x = ((DerivedClass)op1).x & 0xF; // Note: nybble
        
        return (DerivedClass)op1;
    }

    public static DerivedClass operator --(BaseClass op1)
    { 
        ((DerivedClass)op1).x--;
        
        ((DerivedClass)op1).x = ((DerivedClass)op1).x & 0xF; // Note: nybble
        
        return (DerivedClass)op1;
    }

    public static bool operator <(BaseClass op1, BaseClass op2)
    {
        if(op1.x < op2.x)       
            return true;
        else
            return false;
    }

    public static bool operator >(BaseClass op1, BaseClass op2)
    {
        if(op1.x > op2.x)       
            return true;
        else
            return false;
    }
    
    public static explicit operator int(BaseClass op1)
    {
        return op1.x;
    }

    public static explicit operator BaseClass(int op1)
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
        DerivedClass dc2 = new DerivedClass(14);
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
    
        dc3 = dc1 - dc2;
        Console.WriteLine("Showing dc3 = dc1 - dc2");
        dc3.myMethod();
        Console.WriteLine();

        dc3 = dc1 + 3;
        Console.WriteLine("Showing dc3 = dc1 + 3");
        dc3.myMethod();
        Console.WriteLine();

        dc3 = 4 + dc1;
        Console.WriteLine("Showing dc3 = 4 + dc1");
        dc3.myMethod();
        Console.WriteLine();

        dc3 = dc1 -1 ;
        Console.WriteLine("Showing dc3 = dc1 - 1");
        dc3.myMethod();
        Console.WriteLine();
         
        dc3 = 10 - dc1;
        Console.WriteLine("Showing dc3 = 10 - dc1");
        dc3.myMethod();
        Console.WriteLine();

        dc1++;
        Console.WriteLine("Showing dc1++");
        dc1.myMethod();
        Console.WriteLine();

        dc1--;
        Console.WriteLine("Showing dc1--");
        dc1.myMethod();
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