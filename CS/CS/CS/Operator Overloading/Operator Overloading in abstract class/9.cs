// operator overloading in abstract class // for nybble, a four-bit quantity // conversionoperator class, int // implicit conversion of object to int and int to object

// Note: Either implicit or explicit should be done

// #Note

using System;

abstract class BaseClass
{
    public int x; // #Note

    public BaseClass()
    {
        x = 0;
    }

    public BaseClass(int a)
    {
        x = a;
        x = x & 0xF; // Note: nybble
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

    public static DerivedClass operator +(DerivedClass op1, DerivedClass op2) // #Note
    {
        DerivedClass dc = new DerivedClass();
   
        dc.x = op1.x + op2.x;

        dc.x = dc.x & 0xF; // Note: nybble
        
        return dc;
    }

    public static DerivedClass operator -(DerivedClass op1, DerivedClass op2) // #Note
    {
        DerivedClass dc = new DerivedClass();
   
        dc.x = op1.x - op2.x;

        dc.x = dc.x & 0xF; // Note: nybble
        
        return dc;
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
        DerivedClass dc1 = new DerivedClass(2);
        DerivedClass dc2 = new DerivedClass(1);
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

        dc3 = dc1 - 1;
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
        Console.WriteLine();

        Console.WriteLine("use dc1 nybble to control a loop"); // ONLY IN CASE OF IMPLICIT CONVERSION
        for(dc1=0; dc1<15; dc1++) // Note: < 15 
            Console.WriteLine((int)dc1); // Note: (int)dc1
    } 
}