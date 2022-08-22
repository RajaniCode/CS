// operator overloading in struct // conversion operator int // explicit conversion of object to int

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

    public static explicit operator int(MyStruct op1) // Note: return type explicit 
    {
        return op1.x * op1.y * op1.z;
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
        i = (int)ms1; 
        Console.WriteLine("Showing explicit conversion of object to int: i = (int)ms1: {0} \n", i);

        i = (int)ms1 * 2 - (int)ms2; 
        Console.WriteLine("Showing explicit conversion of object to int: i = (int)ms1 * 2 - (int)ms2: {0} \n", i); 

        i = (int)ms1 + (int)ms2; // Note
        Console.WriteLine("Showing explicit conversion of object to int: i = (int)ms1 + (int)ms2: {0} \n", i);          
    }
}