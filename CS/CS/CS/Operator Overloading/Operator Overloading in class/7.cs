// operator overloading in class // conversion operator int // implicit conversion from object to int 

// Note: Either implicit or explicit should be done


using System;

class MyClass
{
    int x;
    int y;
    int z;

    public MyClass()
    {
        x = 0;
        y = 0;
        z = 0;
    }

    public MyClass(int a , int b, int c)
    {
        x = a;
        y = b;
        z = c;
    }

    public static implicit operator int(MyClass op1) // Note: return type implicit 
    {
        return op1.x * op1.y * op1.z; // Note
    }

    public void myMethod()
    {
        Console.WriteLine("x = {0}, y = {1}, z = {2}", x, y, z);
    }
}

class MainClass
{
    static void Main()
    {
        MyClass mc1 = new MyClass(1, 2, 3);
        MyClass mc2 = new MyClass(10, 10, 10);
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

        int i;
        i = mc1;
        Console.WriteLine("Showing implicit conversion of object to int: i = mc1: {0} \n", i);  // Note: print

        i = mc1 * 2 - mc2;
        Console.WriteLine("Showing implicit conversion of object to int: i = mc1 * 2 - mc2: {0} \n", i);  // Note: print

        i = mc1 + mc2; // Note: Not adding objects 
        Console.WriteLine("Showing implicit conversion of object to int: i = mc1 + mc2: {0} \n", i);  // Note: print         
    }  
}