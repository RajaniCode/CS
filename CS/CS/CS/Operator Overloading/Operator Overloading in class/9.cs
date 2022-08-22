// operator overloading in class // for nybble, a four-bit quantity // conversionoperator class, int // implicit conversion of object to int and int to object

// Note: Either implicit or explicit should be done


using System;

class MyClass
{
    int x;

    public MyClass()
    {
        x = 0;
    }

    public MyClass(int a)
    {
        x = a;
        x = x & 0xF; // Note: nybble
    }

    public static MyClass operator +(MyClass op1, MyClass op2)
    {
        MyClass mc = new MyClass();
   
        mc.x = op1.x + op2.x;

        mc.x = mc.x & 0xF; // Note: nybble
        
        return mc;
    }

    public static MyClass operator -(MyClass op1, MyClass op2)
    {
        MyClass mc = new MyClass();
   
        mc.x = op1.x - op2.x;

        mc.x = mc.x & 0xF; // Note: nybble
        
        return mc;
    }

    public static MyClass operator +(MyClass op1, int op2)
    {
        MyClass mc = new MyClass();
   
        mc.x = op1.x + op2;
        
        mc.x = mc.x & 0xF; // Note: nybble

        return mc;
    }
  
    public static MyClass operator +(int op1, MyClass op2)
    {
        MyClass mc = new MyClass();
   
        mc.x = op1 + op2.x;

        mc.x = mc.x & 0xF; // Note: nybble
        
        return mc;
    }

    public static MyClass operator -(MyClass op1, int op2)
    {
        MyClass mc = new MyClass();
   
        mc.x = op1.x - op2;
        
        mc.x = mc.x & 0xF;// Note: nybble

        return mc;
    }

    public static MyClass operator -(int op1, MyClass op2)
    {
        MyClass mc = new MyClass();
   
        mc.x = op1 - op2.x;

        mc.x = mc.x & 0xF; // Note: nybble
        
        return mc;
    }

    public static MyClass operator ++(MyClass op1)
    { 
        op1.x++;

        op1.x = op1.x & 0xF; // Note: nybble
        
        return op1;
    }

    public static MyClass operator --(MyClass op1)
    { 
        op1.x--;
        
        op1.x = op1.x & 0xF; // Note: nybble
        
        return op1;
    }

    public static bool operator <(MyClass op1, MyClass op2)
    {
        if(op1.x < op2.x)       
            return true;
        else
            return false;
    }

    public static bool operator >(MyClass op1, MyClass op2)
    {
        if(op1.x > op2.x)       
            return true;
        else
            return false;
    }
    
    public static implicit operator int(MyClass op1)
    {
        return op1.x;
    }

    public static implicit operator MyClass(int op1)
    {
        return new MyClass(op1);
    }

    public void myMethod()
    {
        Console.WriteLine("x = {0}", x);
    }
}

class MainClass
{
    static void Main()
    {
        MyClass mc1 = new MyClass(2);
        MyClass mc2 = new MyClass(1);
        MyClass mc3 = new MyClass();

        Console.WriteLine("Showing mc1");
        mc1.myMethod();
        Console.WriteLine();

        Console.WriteLine("Showing mc2");
        mc2.myMethod();
        Console.WriteLine();

        Console.WriteLine("Showing mc3");
        mc3.myMethod();
        Console.WriteLine();

        mc3 = mc1 + mc2;
        Console.WriteLine("Showing mc3 = mc1 + mc2");
        mc3.myMethod();
        Console.WriteLine();
    
        mc3 = mc1 - mc2;
        Console.WriteLine("Showing mc3 = mc1 - mc2");
        mc3.myMethod();
        Console.WriteLine();

        mc3 = mc1 + 3;
        Console.WriteLine("Showing mc3 = mc1 + 3");
        mc3.myMethod();
        Console.WriteLine();

        mc3 = 4 + mc1;
        Console.WriteLine("Showing mc3 = 4 + mc1");
        mc3.myMethod();
        Console.WriteLine();

        mc3 = mc1 - 1;
        Console.WriteLine("Showing mc3 = mc1 - 1");
        mc3.myMethod();
        Console.WriteLine();
         
        mc3 = 10 - mc1;
        Console.WriteLine("Showing mc3 = 10 - mc1");
        mc3.myMethod();
        Console.WriteLine();

        mc1++;
        Console.WriteLine("Showing mc1++");
        mc1.myMethod();
        Console.WriteLine();

        mc1--;
        Console.WriteLine("Showing mc1--");
        mc1.myMethod();
        Console.WriteLine();

        int i;
        i = mc1;
        Console.WriteLine("Showing implicit conversion of object to int: i = mc1: {0}", i);
        Console.WriteLine();

        mc3 = i;
        Console.WriteLine("Showing implicit conversion of int to object: mc3 = i: ");  
        mc3.myMethod();
        Console.WriteLine();

        mc3 = 15;
        Console.WriteLine("Showing implicit conversion of int to object: mc3 = 15: ");  
        mc3.myMethod();
        Console.WriteLine();

        Console.WriteLine("use mc1 nybble to control a loop"); // ONLY IN CASE OF IMPLICIT CONVERSION
        for(mc1=0; mc1<15; mc1++) // Note: < 15 
            Console.WriteLine((int)mc1); // Note: (int)mc1
    } 
}