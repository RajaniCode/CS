// operator overloading in class // binary operators +, - // unary operator -, ++


using System;

class MyClass
{
    int x; // cannot be static as you are dealing with objects,  as also values are assigned using constructor
    int y; // cannot be static as you are dealing with objects,  as also values are assigned using constructor
    int z; // cannot be static as you are dealing with objects,  as also values are assigned using constructor

    public MyClass() // Must
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

    public static MyClass operator +(MyClass op1, MyClass op2) // adding objects
    {
        MyClass mc = new MyClass();
         
        mc.x = op1.x + op2.x;
        mc.y = op1.y + op2.y;
        mc.z = op1.z + op2.z;
    
        return mc;
    }

    public static MyClass operator -(MyClass op1, MyClass op2) // subtracting objects
    {
        MyClass mc = new MyClass();
         
        mc.x = op1.x - op2.x;
        mc.y = op1.y - op2.y;
        mc.z = op1.z - op2.z;
    
        return mc;
    }

    public static MyClass operator -(MyClass op1) // receiving negation of object
    {
        MyClass mc = new MyClass();
         
        mc.x = - op1.x;
        mc.y = - op1.y;
        mc.z = - op1.z;
    
        return mc;
    }

    public static MyClass operator ++(MyClass op1) // incrementing object
    {
        // MyClass mc = new MyClass();
         
        op1.x++; // also : ++op1.x
        op1.y++;
        op1.z++;
    
        return op1; // Note:
    }    

    public static MyClass operator --(MyClass op1) // decrementing object
    {
        // MyClass mc = new MyClass();
         
        op1.x--; // no assignment operator // also : --op1.x 
        op1.y--; // no assignment operator // also : --op1.y 
        op1.z--; // no assignment operator // also : --op1.z
    
        return op1; // Note 
    }  


    public void myMethod() // Cannot be static as the method uses instance variables
    {
        Console.WriteLine("x = {0}, y = {1}, z = {2}", x, y, z);
    }
} //

class MainClass //
{ //
    static void Main()
    {
        MyClass mc1 = new MyClass(127, 2, 3);
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

        mc3 = mc1 + mc2; // adding objects
        Console.WriteLine("Showing mc3 = mc1 + mc2");
        mc3.myMethod();   
        Console.WriteLine();

        mc3 = mc1 + mc2 + mc3; // adding objects
        Console.WriteLine("Showing mc3 = mc1 + mc2 + mc3");
        mc3.myMethod();   
        Console.WriteLine();
    
        mc3 = mc3 - mc1; // subtracting objects
        Console.WriteLine("Showing mc3 = mc3 - mc1");
        mc3.myMethod();   
        Console.WriteLine();

        mc3 = mc3 - mc2; // subtracting objects
        Console.WriteLine("Showing mc3 = mc3 - mc2");
        mc3.myMethod();   
        Console.WriteLine(); 

        
        mc3 = -mc1; // receiving negation of object
        Console.WriteLine("Showing mc3 = -mc1");
        mc2.myMethod();   
        Console.WriteLine(); 

        mc1++; // so : ++mc1 // incrementing object
        Console.WriteLine("Showing mc1++");
        mc1.myMethod();   
        Console.WriteLine();

        mc1--; // so : --mc1 // decrementing object
        Console.WriteLine("Showing mc1--");
        mc1.myMethod();   
        Console.WriteLine();            
    }
}    