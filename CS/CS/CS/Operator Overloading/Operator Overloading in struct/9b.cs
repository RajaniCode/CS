// operator overloading in struct // conversion operator struct, int // explicit conversion from int to object and from object to int

// Note: Either implicit or explicit should be done

// struct cannot contain explicit parameterless constructors


using System;

struct MyStruct
{
    int x;    

   


    public MyStruct(int a)
    {
        x = a;        
    }

    public static explicit operator int(MyStruct op1) // Note: return type explicit 
    {
        return op1.x;
    }

    public static explicit operator MyStruct(int op1) // Note: return type explicit 
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
        MyStruct ms2 = new MyStruct(10);
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

        int i;
        i = (int)ms1; 
        Console.WriteLine("Showing explicit conversion of object to int: i = (int)ms1: {0}", i);
        Console.WriteLine(); 

        ms3 = (MyStruct)i; 
        Console.WriteLine("Showing explicit conversion of int to object: ms3 = (MyStruct)i: ");
        ms3.myMethod();
        Console.WriteLine(); 

        ms3 = (MyStruct)15; 
        Console.WriteLine("Showing explicit conversion of int to object: ms3 = (MyStruct)15: ");
        ms3.myMethod();                      
    }
}