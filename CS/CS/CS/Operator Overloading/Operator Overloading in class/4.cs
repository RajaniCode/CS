// operator overloading in class // overloading true and false, must be in pair // do-while loop // also: while, if and for loops


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

    public static bool operator true(MyClass op1) // an object is true
    {
        if((op1.x != 0) && (op1.y != 0) && (op1.z != 0))
            return true;
        else
            return false;
    }

    public static bool operator false(MyClass op1) // an object is false
    {
        if((op1.x == 0) && (op1.y == 0) && (op1.z == 0))
            return true;
        else
            return false;
    }

    public static MyClass operator --(MyClass op1)
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

        if(mc1)
            Console.WriteLine("mc1 is true \n");
        else
            Console.WriteLine("mc1 is false \n");

        if(mc2)
            Console.WriteLine("mc2 is true \n");
        else
            Console.WriteLine("mc2 is false \n");
  
        if(mc3)
            Console.WriteLine("mc3 is true \n");
        else
            Console.WriteLine("mc3 is false \n");
  
        do                  // Note
        {   mc2.myMethod();  
            mc2--;
        }while(mc2);  

    }
}

 