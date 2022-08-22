// operator overloading in struct // relational operator // Note: relational operators must be overloaded in pairs < and >, == and !=, <= and >=

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

    public static bool operator <(MyStruct op1, MyStruct op2) // Comparing objects
    {
        if((op1.x < op2.x) && (op1.y < op2.y) && (op1.z < op2.z))
            return true;
        else
            return false;
    }

    public static bool operator >(MyStruct op1, MyStruct op2) // Comparing objects
    {
        if((op1.x > op2.x) && (op1.y > op2.y) && (op1.z > op2.z))
            return true;
        else
            return false;
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

        if(ms1 < ms2) 
            Console.WriteLine("ms1 < ms2 is true \n");
        else
            Console.WriteLine("ms1 < ms2 is false \n");

        if(ms1 < ms3) 
            Console.WriteLine("ms1 < ms3 is true \n");
        else
            Console.WriteLine("ms1 < ms3 is false \n");

        if(ms1 > ms2) 
            Console.WriteLine("ms1 > ms2 is true \n");
        else
            Console.WriteLine("ms1 > ms2 is false \n");

        if(ms1 > ms3) 
            Console.WriteLine("ms1 > ms3 is true \n");
        else
            Console.WriteLine("ms1 > ms3 is false \n"); 
    }
}        