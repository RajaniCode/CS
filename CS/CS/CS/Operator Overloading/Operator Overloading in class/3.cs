// operator overloading in class // relational operator // Note: relational operators must be overloaded in pairs < and >, == and !=, <= and >=


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

    public static bool operator <(MyClass op1, MyClass op2) // Comparing objects
    {
        if((op1.x < op2.x) && (op1.y < op2.y) && (op1.z < op2.z))
            return true;
        else
            return false;
    }

    public static bool operator >(MyClass op1, MyClass op2) // Comparing objects
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

        if(mc1 < mc2) 
            Console.WriteLine("mc1 < mc2 is true \n");
        else
            Console.WriteLine("mc1 < mc2 is false \n");

        if(mc1 < mc3) 
            Console.WriteLine("mc1 < mc3 is true \n");
        else
            Console.WriteLine("mc1 < mc3 is false \n");

        if(mc1 > mc2) 
            Console.WriteLine("mc1 > mc2 is true \n");
        else
            Console.WriteLine("mc1 > mc2 is false \n");

        if(mc1 > mc3) 
            Console.WriteLine("mc1 > mc3 is true \n");
        else
            Console.WriteLine("mc1 > mc3 is false \n"); 
    }
}        