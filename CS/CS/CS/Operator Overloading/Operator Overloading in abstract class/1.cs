// operator overloading in abstract class // binary operators +, - // unary operator -, ++


using System;

abstract class BaseClass
{
    int x; // cannot be static as you are dealing with objects,  as also values are assigned using constructor
    int y; // cannot be static as you are dealing with objects,  as also values are assigned using constructor
    int z; // cannot be static as you are dealing with objects,  as also values are assigned using constructor

    public BaseClass() // Must
    {
        x = 0;
        y = 0;
        z =0;
    }

    public BaseClass(int a, int b, int c)
    {
        x = a;
        y = b;
        z = c;
    }

    public static DerivedClass operator +(BaseClass op1, BaseClass op2) // adding objects
    {
        DerivedClass dc = new DerivedClass();
         
        dc.x = (( DerivedClass)op1).x + (( DerivedClass)op2).x;
        dc.y = (( DerivedClass)op1).y + (( DerivedClass)op2).y;
        dc.z = (( DerivedClass)op1).z + (( DerivedClass)op2).z;
    
        return dc;
    }

    public static DerivedClass operator -(BaseClass op1, BaseClass op2) // subtracting objects
    {
        DerivedClass dc = new DerivedClass();
         
        dc.x = (( DerivedClass)op1).x - (( DerivedClass)op2).x;
        dc.y = (( DerivedClass)op1).y - (( DerivedClass)op2).y;
        dc.z = (( DerivedClass)op1).z - (( DerivedClass)op2).z;
    
        return dc;
    }

    public static DerivedClass operator -(BaseClass op1) // receiving negation of object
    {
        DerivedClass dc = new DerivedClass();
         
        dc.x = - (( DerivedClass)op1).x;
        dc.y = - (( DerivedClass)op1).y;
        dc.z = - (( DerivedClass)op1).z;
    
        return dc;
    }

    public static DerivedClass operator ++(BaseClass op1) // incrementing object
    {
        // DerivedClass dc = new DerivedClass();
         
        (( DerivedClass)op1).x++; // also : ++(( DerivedClass)op1).x
        (( DerivedClass)op1).y++;
        (( DerivedClass)op1).z++;
    
        return (DerivedClass)op1; // Note:
    }    

    public static DerivedClass operator --(BaseClass op1) // decrementing object
    {
        // DerivedClass dc = new DerivedClass();
         
        (( DerivedClass)op1).x--; // no assignment operator // also : --(( DerivedClass)op1).x 
        (( DerivedClass)op1).y--; // no assignment operator // also : --(( DerivedClass)op1).y 
        (( DerivedClass)op1).z--; // no assignment operator // also : --(( DerivedClass)op1).z
    
        return (DerivedClass)op1; // Note 
    }  


    public void myMethod() // Cannot be static as the method uses instance variables
    {
        Console.WriteLine("x = {0}, y = {1}, z = {2}", x, y, z);
    }
} 

class DerivedClass : BaseClass    
{
    public DerivedClass()
    {

    }

    public DerivedClass(int a, int b, int c) : base(a, b, c)
    {

    }            
}

class MainClass 
{ 
    static void Main()
    {
        DerivedClass dc1 = new DerivedClass(127, 2, 3);
        DerivedClass dc2 = new DerivedClass(10, 10, 10);
        DerivedClass dc3 = new DerivedClass();

        Console.WriteLine("Showing dc1");
        dc1.myMethod();   
        Console.WriteLine();
   
        Console.WriteLine("Showing dc2");
        dc2.myMethod();   
        Console.WriteLine();

        Console.WriteLine("Showing dc3");
        dc3.myMethod();   
        Console.WriteLine();    

        dc3 = dc1 + dc2; // adding objects
        Console.WriteLine("Showing dc3 = dc1 + dc2");
        dc3.myMethod();   
        Console.WriteLine();

        dc3 = dc1 + dc2 + dc3; // adding objects
        Console.WriteLine("Showing dc3 = dc1 + dc2 + dc3");
        dc3.myMethod();   
        Console.WriteLine();
    
        dc3 = dc3 - dc1; // subtracting objects
        Console.WriteLine("Showing dc3 = dc3 - dc1");
        dc3.myMethod();   
        Console.WriteLine();

        dc3 = dc3 - dc2; // subtracting objects
        Console.WriteLine("Showing dc3 = dc3 - dc2");
        dc3.myMethod();   
        Console.WriteLine(); 

        
        dc3 = -dc1; // receiving negation of object
        Console.WriteLine("Showing dc3 = -dc1");
        dc2.myMethod();   
        Console.WriteLine(); 

        dc1++; // so : ++dc1 // incrementing object
        Console.WriteLine("Showing dc1++");
        dc1.myMethod();   
        Console.WriteLine();

        dc1--; // so : --dc1 // decrementing object
        Console.WriteLine("Showing dc1--");
        dc1.myMethod();   
        Console.WriteLine();            
    }
}    