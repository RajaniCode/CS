// operator overloading in struct // overloading true and false, must be in pair // do-while loop // also: while, if and for loops

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

    public static bool operator true(MyStruct op1) // an object is true
    {
        if((op1.x != 0) && (op1.y != 0) && (op1.z != 0))
            return true;
        else
            return false;
    }

    public static bool operator false(MyStruct op1) // an object is false
    {
        if((op1.x == 0) && (op1.y == 0) && (op1.z == 0))
            return true;
        else
            return false;
    }

    public static MyStruct operator --(MyStruct op1)
    {
        op1.x--;
        op1.y--;
        op1.z--;
        
        return op1;        
    }

    public void myMethod()
    {
        Console.WriteLine("x = {0}, y = {1}, z = {2}", x, y, z);
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

        if(ms1)
            Console.WriteLine("ms1 is true \n");
        else
            Console.WriteLine("ms1 is false \n");

        if(ms2)
            Console.WriteLine("ms2 is true \n");
        else
            Console.WriteLine("ms2 is false \n");
  
        if(ms3)
            Console.WriteLine("ms3 is true \n");
        else
            Console.WriteLine("ms3 is false \n");
  
        do                  // Note
        {   ms2.myMethod();  
            ms2--;
        }while(ms2);  

    }
}

 