// operator overloading in class // conversion operator class, int // explicit conversion from int to object and from object to int

// Note: Either implicit or explicit should be done


using System;

class MyClass
{
    int x;    

    public MyClass()
    {
        x = 0;        
    }

    public MyClass(int a)
    {
        x = a;        
    }

    public static explicit operator int(MyClass op1) // Note: return type explicit 
    {
        return op1.x;
    }

    public static explicit operator MyClass(int op1) // Note: return type explicit 
    {
        return new MyClass(op1);
    }

    public void myMethod()
    {
        Console.WriteLine("x = {0}", x);
    }
}

class MainClass
{
    static void Main()
    {
        MyClass mc1 = new MyClass(1);
        MyClass mc2 = new MyClass(10);
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
        i = (int)mc1; 
        Console.WriteLine("Showing explicit conversion of object to int: i = (int)mc1: {0}", i);
        Console.WriteLine();

        mc3 = (MyClass)i; 
        Console.WriteLine("Showing explicit conversion of int to object: mc3 = (MyClass)i: ");
        mc3.myMethod();
        Console.WriteLine();

        mc3 = (MyClass)15; 
        Console.WriteLine("Showing explicit conversion of int to object: mc3 = (MyClass)15: ");
        mc3.myMethod();                      
    }
}