// overloading operator in struct // for nybble // conversionoperator struct, int // explicit conversion of object to int and int to object

// Note: Either implicit or explicit should be done

// struct cannot contain explicit parameterless constructors


using System;

struct MyStruct
{
    int x;

   

    public MyStruct(int a)
    {
        x = a;
        x = x & 0xF; // Note
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
    
    public static explicit operator int(MyStruct op1)
    {
        return op1.x;
    }

    public static explicit operator MyStruct(int op1)
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
        MyStruct ms1 = new MyStruct(1);
        MyStruct ms2 = new MyStruct(14);
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
        i = (int)ms1;
        Console.WriteLine("Showing explicit conversion of object to int: i = (int)ms1: {0}", i);
        Console.WriteLine();

        ms3 = (MyStruct)i;
        Console.WriteLine("Showing explicit conversion of int to object: ms3 = (MyStruct)i: ");  
        ms3.myMethod();
        Console.WriteLine();

        ms3 = (MyStruct)14;
        Console.WriteLine("Showing explicit conversion of int to object: ms3 = (MyStruct)14: ");  
        ms3.myMethod();      
    } 
}