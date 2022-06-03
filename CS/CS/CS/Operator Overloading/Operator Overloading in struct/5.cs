// overloading operator in struct // logical operators &, |, ! 

// although the logical operators short circuit &&,|| cannot be overloaded, their benefits can still be obtained by following certain rules

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

    public static bool operator &(MyStruct op1, MyStruct op2)
    {
        if(((op1.x != 0) && (op1.y != 0) && (op1.z != 0)) & ((op2.x != 0) && (op2.y != 0) && (op2.z != 0)))
            return true;
        else
            return false;
    }

    public static bool operator |(MyStruct op1, MyStruct op2)
    {
        if(((op1.x != 0) || (op1.y != 0) || (op1.z != 0)) | ((op2.x != 0) || (op2.y != 0) || (op2.z != 0)))
            return true;
        else
            return false;
    }

    // **Note: Nothing to do with overloading &, | 
    public static bool operator !(MyStruct op1) 
    {
        
        if((op1.x != 0) || (op1.y != 0) || (op1.z != 0)) // also: if((op1.x != 0) | (op1.y != 0) | (op1.z != 0))  // check using &&, &
            return false; // Note
        else
            return true;
    }   

    public void myMethod()
    {
        Console.WriteLine("x = {0}, y = {1}, z = {2}", x, y, z);
    }

    static void Main()
    {
        MyStruct ms1 = new MyStruct(1, 1, 1);
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

        if(ms1 & ms2)
            Console.WriteLine("ms1 & ms2 is true");
        else
            Console.WriteLine("ms1 & ms2 is flase");
 
        if(ms1 & ms3)
            Console.WriteLine("ms1 & ms3 is true");
        else
            Console.WriteLine("ms1 & ms3 is flase");

        if(ms1 | ms2)
            Console.WriteLine("ms1 | ms2 is true");
        else
            Console.WriteLine("ms1 | ms2 is flase");

        if(ms1 | ms3)
            Console.WriteLine("ms1 | ms3 is true");
        else
            Console.WriteLine("ms1 | ms3 is flase");

        if(!ms1) // Note
            Console.WriteLine("ms1 is false"); // Note
        else 
            Console.WriteLine("ms1 is true");

        if(!ms2) // Note
            Console.WriteLine("ms2 is false"); // Note
        else 
            Console.WriteLine("ms2 is true");

        if(!ms3) // Note
            Console.WriteLine("ms3 is false"); // Note
        else 
            Console.WriteLine("ms3 is true"); 
    }
}   