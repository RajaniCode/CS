// operator overloading in class // handling built-in types int


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

    public MyClass(int a, int b, int c)
    {
        x = a;
        y = b;
        z = c;
    }

    public static MyClass operator +(MyClass op1, MyClass op2)
    {
        MyClass mc = new MyClass();
  
        mc.x = op1.x + op2.x;
        mc.y = op1.y + op2.x;
        mc.z = op1.z + op2.x;

        return mc;
    }

    public static MyClass operator -(MyClass op1, MyClass op2)
    {
        MyClass mc = new MyClass();
  
        mc.x = op1.x - op2.x;
        mc.y = op1.y - op2.x;
        mc.z = op1.z - op2.x;

        return mc;
    }

    public static MyClass operator +(MyClass op1, int op2) // adding int to object
    {
        MyClass mc = new MyClass();
  
        mc.x = op1.x + op2;
        mc.y = op1.y + op2;
        mc.z = op1.z + op2;

        return mc;
    }

    public static MyClass operator +(int op1, MyClass op2) // adding object to int
    {
        MyClass mc = new MyClass();
  
        mc.x = op1 + op2.x;
        mc.y = op1 + op2.y;
        mc.z = op1 + op2.z;

        return mc;
    }

    public static MyClass operator -(MyClass op1, int op2) //  subtracting int from object // Note: the order of parameters as per the subtraction
    {
        MyClass mc = new MyClass();
  
        mc.x = op1.x - op2;
        mc.y = op1.y - op2;
        mc.z = op1.z - op2;

        return mc;
    }

    public static MyClass operator -(int op1, MyClass op2) //  subtracting object from int // Note: the order of parameters as per the subtraction
    {
        MyClass mc = new MyClass();
  
        mc.x = op1 - op2.x;
        mc.y = op1 - op2.y;
        mc.z = op1 - op2.z;

        return mc;
    }

    public void myMethod()
    {
        Console.WriteLine("x = {0}, y = {1}, z = {2}", x,y,z);
    }
} // 

class MainClass //
{ //
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

        mc3 = mc1 + mc2;
        Console.WriteLine("Showing mc3 = mc1 + mc2");
        mc3.myMethod();
        Console.WriteLine();

        mc3 = mc2 - mc1;
        Console.WriteLine("Showing mc3 = mc2 - mc1");
        mc1.myMethod();
        Console.WriteLine();

        mc3 = mc1 + mc2;
        Console.WriteLine("Showing mc3 = mc1 + mc2");
        mc3.myMethod();
        Console.WriteLine();

        mc3 = mc1 + 100; // Note: assignment operator should be used, otherwise it becomes an increment
        Console.WriteLine("Showing mc3 = mc1 + 100");
        mc3.myMethod();
        Console.WriteLine();

        mc3 = 100 + mc1; // Note: assignment operator should be used, otherwise it becomes an increment
        Console.WriteLine("Showing mc3 = 100 + mc1");
        mc3.myMethod();
        Console.WriteLine();
    
        mc3 = mc1 - 10; // Note: assignment operator should be used, otherwise it becomes a decrement
        Console.WriteLine("Showing mc3 = mc1 - 10");
        mc3.myMethod();
        Console.WriteLine();

        mc3 = 10 - mc1; // Note: assignment operator should be used, otherwise it becomes a decrement
        Console.WriteLine("Showing mc3 = 10 - mc1");
        mc3.myMethod();
        Console.WriteLine();
    }
}
         
         

