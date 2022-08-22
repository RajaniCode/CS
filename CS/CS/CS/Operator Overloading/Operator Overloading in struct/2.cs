// operator overloading in struct // handling built-in types int

// struct cannot contain explicit parameterless constructors


using System;

struct MyStruct
{
    int x;
    int y;
    int z;

   


    public MyStruct(int a, int b, int c)
    {
        x = a;
        y = b;
        z = c;
    }

    public static MyStruct operator +(MyStruct op1, MyStruct op2)
    {
        MyStruct ms = new MyStruct();
  
        ms.x = op1.x + op2.x;
        ms.y = op1.y + op2.x;
        ms.z = op1.z + op2.x;

        return ms;
    }

    public static MyStruct operator -(MyStruct op1, MyStruct op2)
    {
        MyStruct ms = new MyStruct();
  
        ms.x = op1.x - op2.x;
        ms.y = op1.y - op2.x;
        ms.z = op1.z - op2.x;

        return ms;
    }

    public static MyStruct operator +(MyStruct op1, int op2) // adding int to object
    {
        MyStruct ms = new MyStruct();
  
        ms.x = op1.x + op2;
        ms.y = op1.y + op2;
        ms.z = op1.z + op2;

        return ms;
    }

    public static MyStruct operator +(int op1, MyStruct op2) // adding object to int
    {
        MyStruct ms = new MyStruct();
  
        ms.x = op1 + op2.x;
        ms.y = op1 + op2.y;
        ms.z = op1 + op2.z;

        return ms;
    }

    public static MyStruct operator -(MyStruct op1, int op2) //  subtracting int from object // Note: the order of parameters as per the subtraction
    {
        MyStruct ms = new MyStruct();
  
        ms.x = op1.x - op2;
        ms.y = op1.y - op2;
        ms.z = op1.z - op2;

        return ms;
    }

    public static MyStruct operator -(int op1, MyStruct op2) //  subtracting object from int // Note: the order of parameters as per the subtraction
    {
        MyStruct ms = new MyStruct();
  
        ms.x = op1 - op2.x;
        ms.y = op1 - op2.y;
        ms.z = op1 - op2.z;

        return ms;
    }

    public void myMethod()
    {
        Console.WriteLine("x = {0}, y = {1}, z = {2}", x,y,z);
    }
} // 

struct MainStruct //
{ //
    static void Main()
    {
        MyStruct ms1 = new MyStruct(1, 2, 3);
        MyStruct ms2 = new MyStruct(10, 10, 10);
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

        ms3 = ms2 - ms1;
        Console.WriteLine("Showing ms3 = ms2 - ms1");
        ms1.myMethod();
        Console.WriteLine();

        ms3 = ms1 + ms2;
        Console.WriteLine("Showing ms3 = ms1 + ms2");
        ms3.myMethod();
        Console.WriteLine();

        ms3 = ms1 + 100; // Note: assignment operator should be used, otherwise it becomes an increment
        Console.WriteLine("Showing ms3 = ms1 + 100");
        ms3.myMethod();
        Console.WriteLine();

        ms3 = 100 + ms1; // Note: assignment operator should be used, otherwise it becomes an increment
        Console.WriteLine("Showing ms3 = 100 + ms1");
        ms3.myMethod();
        Console.WriteLine();
    
        ms3 = ms1 - 10; // Note: assignment operator should be used, otherwise it becomes a decrement
        Console.WriteLine("Showing ms3 = ms1 - 10");
        ms3.myMethod();
        Console.WriteLine();

        ms3 = 10 - ms1; // Note: assignment operator should be used, otherwise it becomes a decrement
        Console.WriteLine("Showing ms3 = 10 - ms1");
        ms3.myMethod();
        Console.WriteLine();
    }
}
         
         

