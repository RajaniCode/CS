// operator overloading in class // conversion operators class, int // implicit conversion from int to object and from object to int

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

    public static implicit operator int(MyClass op1) // Note: return type implicit 
    {
        return op1.x;
    }

    public static implicit operator MyClass(int op1) // Note: return type implicit 
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
        i = mc1; 
        Console.WriteLine("Showing implicit conversion of object to int: i = mc1: {0}", i);
        Console.WriteLine();

        mc3 = i; 
        Console.WriteLine("Showing implicit conversion of int to object: mc3 = i: ");
        mc3.myMethod();
        Console.WriteLine();

        mc3 = 15; 
        Console.WriteLine("Showing implicit conversion of int to object: mc3 = 15: ");
        mc3.myMethod();                            
    }
}