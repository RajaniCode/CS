// operator overloading in struct // for nybble, a four-bit quantity // conversionoperator struct, int // implicit conversion of object to int and int to object

// Note: Either implicit or explicit should be done


using System;

struct MyStruct
{
    int x;

   

    public MyStruct(int a) : this()
    {
        x = a;
        x = x & 0xF; // Note: nybble
    }

    public static MyStruct operator +(MyStruct op1, MyStruct op2)
    {
        MyStruct ms = new MyStruct();
   
        ms.x = op1.x + op2.x;

        ms.x = ms.x & 0xF; // Note: nybble
        
        return ms;
    }

    public static MyStruct operator -(MyStruct op1, MyStruct op2)
    {
        MyStruct ms = new MyStruct();
   
        ms.x = op1.x - op2.x;

        ms.x = ms.x & 0xF; // Note: nybble
        
        return ms;
    }

    public static MyStruct operator +(MyStruct op1, int op2)
    {
        MyStruct ms = new MyStruct();
   
        ms.x = op1.x + op2;
        
        ms.x = ms.x & 0xF; // Note: nybble

        return ms;
    }
  
    public static MyStruct operator +(int op1, MyStruct op2)
    {
        MyStruct ms = new MyStruct();
   
        ms.x = op1 + op2.x;

        ms.x = ms.x & 0xF; // Note: nybble
        
        return ms;
    }

    public static MyStruct operator -(MyStruct op1, int op2)
    {
        MyStruct ms = new MyStruct();
   
        ms.x = op1.x - op2;
        
        ms.x = ms.x & 0xF;// Note: nybble

        return ms;
    }

    public static MyStruct operator -(int op1, MyStruct op2)
    {
        MyStruct ms = new MyStruct();
   
        ms.x = op1 - op2.x;

        ms.x = ms.x & 0xF; // Note: nybble
        
        return ms;
    }

    public static MyStruct operator ++(MyStruct op1)
    { 
        op1.x++;

        op1.x = op1.x & 0xF; // Note: nybble
        
        return op1;
    }

    public static MyStruct operator --(MyStruct op1)
    { 
        op1.x--;
        
        op1.x = op1.x & 0xF; // Note: nybble
        
        return op1;
    }

    public static bool operator <(MyStruct op1, MyStruct op2)
    {
        if(op1.x < op2.x)       
            return true;
        else
            return false;
    }

    public static bool operator >(MyStruct op1, MyStruct op2)
    {
        if(op1.x > op2.x)       
            return true;
        else
            return false;
    }
    
    public static implicit operator int(MyStruct op1)
    {
        return op1.x;
    }

    public static implicit operator MyStruct(int op1)
    {
        return new MyStruct(op1);
    }

    public void myMethod()
    {
        Console.WriteLine("x = {0}", x);
    }
}

struct MainStruct
{
    static void Main()
    {
        MyStruct ms1 = new MyStruct(2);
        MyStruct ms2 = new MyStruct(1);
        MyStruct ms3 = new MyStruct();

        Console.WriteLine("Showing ms1");
        ms1.myMethod();
        Console.WriteLine();

        Console.WriteLine("Showing ms2");
        ms2.myMethod();
        Console.WriteLine();

        Console.WriteLine("Showing ms3");
        ms3.myMethod();
        Console.WriteLine();

        ms3 = ms1 + ms2;
        Console.WriteLine("Showing ms3 = ms1 + ms2");
        ms3.myMethod();
        Console.WriteLine();
    
        ms3 = ms1 - ms2;
        Console.WriteLine("Showing ms3 = ms1 - ms2");
        ms3.myMethod();
        Console.WriteLine();

        ms3 = ms1 + 3;
        Console.WriteLine("Showing ms3 = ms1 + 3");
        ms3.myMethod();
        Console.WriteLine();

        ms3 = 4 + ms1;
        Console.WriteLine("Showing ms3 = 4 + ms1");
        ms3.myMethod();
        Console.WriteLine();

        ms3 = ms1 - 1;
        Console.WriteLine("Showing ms3 = ms1 - 1");
        ms3.myMethod();
        Console.WriteLine();
         
        ms3 = 10 - ms1;
        Console.WriteLine("Showing ms3 = 10 - ms1");
        ms3.myMethod();
        Console.WriteLine();

        ms1++;
        Console.WriteLine("Showing ms1++");
        ms1.myMethod();
        Console.WriteLine();

        ms1--;
        Console.WriteLine("Showing ms1--");
        ms1.myMethod();
        Console.WriteLine();

        int i;
        i = ms1;
        Console.WriteLine("Showing implicit conversion of object to int: i = ms1: {0}", i);
        Console.WriteLine();

        ms3 = i;
        Console.WriteLine("Showing implicit conversion of int to object: ms3 = i: ");  
        ms3.myMethod();
        Console.WriteLine();

        ms3 = 15;
        Console.WriteLine("Showing implicit conversion of int to object: ms3 = 15: ");  
        ms3.myMethod();
        Console.WriteLine();

        Console.WriteLine("use ms1 nybble to control a loop"); // ONLY IN CASE OF IMPLICIT CONVERSION
        for(ms1=0; ms1<15; ms1++) // Note: < 15 
            Console.WriteLine((int)ms1); // Note: (int)ms1
    } 
}