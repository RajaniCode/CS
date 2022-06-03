// operator overloading in class // logical operators &, |, ! 

// although the logical operators short circuit &&,|| cannot be overloaded, their benefits can still be obtained by following certain rules


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

    public static bool operator &(MyClass op1, MyClass op2)
    {
        if(((op1.x != 0) && (op1.y != 0) && (op1.z != 0)) & ((op2.x != 0) && (op2.y != 0) && (op2.z != 0)))
            return true;
        else
            return false;
    }

    public static bool operator |(MyClass op1, MyClass op2)
    {
        if(((op1.x != 0) || (op1.y != 0) || (op1.z != 0)) | ((op2.x != 0) || (op2.y != 0) || (op2.z != 0)))
            return true;
        else
            return false;
    }

    // **Note: Nothing to do with overloading &, | 
    public static bool operator !(MyClass op1) 
    {
        
        if((op1.x != 0) || (op1.y != 0) || (op1.z != 0)) // also: if((op1.x != 0) | (op1.y != 0) | (op1.z != 0))  // check using &&, &
            return false; // Note
        else
            return true;
    }   

    public void myMethod()
    {
        Console.WriteLine("x = {0}, y = {1}, z = {2}", x, y, z);
    }

    static void Main()
    {
        MyClass mc1 = new MyClass(1, 1, 1);
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

        if(mc1 & mc2)
            Console.WriteLine("mc1 & mc2 is true");
        else
            Console.WriteLine("mc1 & mc2 is flase");
 
        if(mc1 & mc3)
            Console.WriteLine("mc1 & mc3 is true");
        else
            Console.WriteLine("mc1 & mc3 is flase");

        if(mc1 | mc2)
            Console.WriteLine("mc1 | mc2 is true");
        else
            Console.WriteLine("mc1 | mc2 is flase");

        if(mc1 | mc3)
            Console.WriteLine("mc1 | mc3 is true");
        else
            Console.WriteLine("mc1 | mc3 is flase");

        if(!mc1) // Note
            Console.WriteLine("mc1 is false"); // Note
        else 
            Console.WriteLine("mc1 is true");

        if(!mc2) // Note
            Console.WriteLine("mc2 is false"); // Note
        else 
            Console.WriteLine("mc2 is true");

        if(!mc3) // Note
            Console.WriteLine("mc3 is false"); // Note
        else 
            Console.WriteLine("mc3 is true"); 
    }
}   