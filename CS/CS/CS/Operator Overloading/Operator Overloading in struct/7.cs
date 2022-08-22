// operator overloading // conversion operator int // implicit conversion from object to int 

// Note: Either implicit or explicit should be done

// struct cannot contain explicit parameterless constructors


using System;

struct MyStruct
{
    int x;
    int y;
    int z;

   


    public MyStruct(int a , int b, int c)
    {
        x = a;
        y = b;
        z = c;
    }

    public static implicit operator int(MyStruct op1) // Note: return type implicit 
    {
        return op1.x * op1.y * op1.z; // Note
    }

    public void myMethod()
    {
        Console.WriteLine("x = {0}, y = {1}, z = {2}", x, y, z);
    }
}

struct MainStruct
{
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

        int i;
        i = ms1;
        Console.WriteLine("Showing implicit conversion of object to int: i = ms1: {0} \n", i);  // Note: print

        i = ms1 * 2 - ms2;
        Console.WriteLine("Showing implicit conversion of object to int: i = ms1 * 2 - ms2: {0} \n", i);  // Note: print

        i = ms1 + ms2; // Note: Not adding objects 
        Console.WriteLine("Showing implicit conversion of object to int: i = ms1 + ms2: {0} \n", i);  // Note: print         
    }  
}