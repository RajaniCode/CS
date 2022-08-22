// operator overloading in struct // binary operators +, - // unary operator -, ++

// struct cannot contain explicit parameterless constructors


using System;

struct MyStruct
{
    int x; // cannot be static as you are dealing with objects,  as also values are assigned using constructor
    int y; // cannot be static as you are dealing with objects,  as also values are assigned using constructor
    int z; // cannot be static as you are dealing with objects,  as also values are assigned using constructor

    
    public MyStruct(int a, int b, int c)
    {
        x = a;
        y = b;
        z = c;
    }

    public static MyStruct operator +(MyStruct op1, MyStruct op2) // adding objects
    {
        MyStruct ms = new MyStruct(); // Note
         
        ms.x = op1.x + op2.x;
        ms.y = op1.y + op2.y;
        ms.z = op1.z + op2.z;
    
        return ms;
    }

    public static MyStruct operator -(MyStruct op1, MyStruct op2) // subtracting objects
    {
        MyStruct ms = new MyStruct();
         
        ms.x = op1.x - op2.x;
        ms.y = op1.y - op2.y;
        ms.z = op1.z - op2.z;
    
        return ms;
    }

    public static MyStruct operator -(MyStruct op1) // receiving negation of object
    {
        MyStruct ms = new MyStruct(); // Note
         
        ms.x = - op1.x;
        ms.y = - op1.y;
        ms.z = - op1.z;
    
        return ms;
    }

    public static MyStruct operator ++(MyStruct op1) // incrementing object
    {
        op1.x++; // also : ++op1.x
        op1.y++;
        op1.z++;
    
        return op1; // Note:
    }    

    public static MyStruct operator --(MyStruct op1) // decrementing object
    {
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

struct MainClass //
{ //
    static void Main()
    {
        MyStruct ms1 = new MyStruct(127, 2, 3);
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

        ms3 = ms1 + ms2; // adding objects
        Console.WriteLine("Showing ms3 = ms1 + ms2");
        ms3.myMethod();   
        Console.WriteLine();

        ms3 = ms1 + ms2 + ms3; // adding objects
        Console.WriteLine("Showing ms3 = ms1 + ms2 + ms3");
        ms3.myMethod();   
        Console.WriteLine();
    
        ms3 = ms3 - ms1; // subtracting objects
        Console.WriteLine("Showing ms3 = ms3 - ms1");
        ms3.myMethod();   
        Console.WriteLine();

        ms3 = ms3 - ms2; // subtracting objects
        Console.WriteLine("Showing ms3 = ms3 - ms2");
        ms3.myMethod();   
        Console.WriteLine(); 

        
        ms3 = -ms1; // receiving negation of object
        Console.WriteLine("Showing ms3 = -ms1");
        ms2.myMethod();   
        Console.WriteLine(); 

        ms1++; // so : ++ms1 // incrementing object
        Console.WriteLine("Showing ms1++");
        ms1.myMethod();   
        Console.WriteLine();

        ms1--; // so : --ms1 // decrementing object
        Console.WriteLine("Showing ms1--");
        ms1.myMethod();   
        Console.WriteLine();            
    }
}    