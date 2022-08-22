// operator overloading in abstract class // *Note: enabling the short-circuit operators &&, || 

// **Note: && checks the first operand for 'false' and || checks the first operand for 'true'

// #Note

using System;

abstract class BaseClass
{
    int x;
    int y;
    int z;
 
    public BaseClass()
    {
        x = 0;
        y = 0;
        z = 0;
    }


    public BaseClass(int a, int b, int c)
    {
        x = a;
        y = b;
        z = b;
    }


    //*Note: In order to be applicable as a short circuit operator a user-defined logical operator 
    // ('BaseClass.operator &(BaseClass, BaseClass)') must have the same return type as the type of its 2 parameters

    public static BaseClass operator &(BaseClass op1, BaseClass op2) // #Note
    {
        if(((((DerivedClass)op1).x != 0) && (((DerivedClass)op1).y  != 0) && (((DerivedClass)op1).z  != 0)) & ((((DerivedClass)op2).x  != 0) && (((DerivedClass)op2).y  != 0) && (((DerivedClass)op2).z  != 0)))
            return  new DerivedClass(1, 1, 1); // Note
        else 
            return new DerivedClass(0, 0, 0); // Note
    }

    //*Note: In order to be applicable as a short circuit operator a user-defined logical operator 
    // ('BaseClass.operator |(BaseClass, BaseClass)') must have the same return type as the type of its 2 parameters

    public static BaseClass operator |(BaseClass op1, BaseClass op2) // #Note
    {
        if(((((DerivedClass)op1).x != 0) || (((DerivedClass)op1).y  != 0) || (((DerivedClass)op1).z  != 0)) | ((((DerivedClass)op2).x  != 0) || (((DerivedClass)op2).y  != 0) || (((DerivedClass)op2).z  != 0)))
            return  new DerivedClass(1, 1, 1); // Note
        else 
            return new DerivedClass(0, 0, 0); // Note
    }

    // **Note: Nothing to do with &&, ||, &, | 
    public static bool operator !(BaseClass op1)
    {
        if(op1) // Because of overloading false and true (pair) //Also: if((((DerivedClass)op1).x != 0) || (((DerivedClass)op1).y  != 0) || (((DerivedClass)op1).z  != 0)) // if((((DerivedClass)op1).x != 0) | (((DerivedClass)op1).y  != 0) | (((DerivedClass)op1).z  != 0))           
            return false; // Note                                
        else                                                              
            return true;                                                     
    }                                                                            
       
    // **Note: For overloading &&, || // Also: for overloading &, | as they return new                                                                                           
    public static bool operator true(BaseClass op1)                   
    {                                                                      
        if((((DerivedClass)op1).x != 0) || (((DerivedClass)op1).y  != 0) || (((DerivedClass)op1).z  != 0))        //Also: if((((DerivedClass)op1).x != 0) | (((DerivedClass)op1).y  != 0) | (((DerivedClass)op1).z  != 0))       
            return true;                                                               
        else                                                                
            return false;                                                 
    }                                                                              
        
    // **Note: For overloading &&, || // Also: for overloading &, | as they return new                                                      
    public static bool operator false(BaseClass op1)                     
    {                                                                                                                             
        if((((DerivedClass)op1).x == 0) && (((DerivedClass)op1).y  == 0) && (((DerivedClass)op1).z  == 0))        // Also: if((((DerivedClass)op1).x == 0) & (((DerivedClass)op1).y  == 0) & (((DerivedClass)op1).z  == 0))    
            return true; // Note
        else
            return false;
    }

    public void myMethod()
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
        DerivedClass dc1 = new DerivedClass(1, 2, 3);
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

       if(dc1)
           Console.WriteLine("dc1 is true");
       else
           Console.WriteLine("dc1 is false");

       if(dc2)
           Console.WriteLine("dc2 is true");
       else
           Console.WriteLine("dc2 is false");

       if(dc3)
           Console.WriteLine("dc3 is true");
       else
           Console.WriteLine("dc3 is false");

       if(!dc1)
           Console.WriteLine("dc1 is false");
       else
           Console.WriteLine("dc1 is true");

       if(!dc2)
           Console.WriteLine("dc2 is false");
       else
           Console.WriteLine("dc2 is true");

       if(!dc3)
          Console.WriteLine("dc3 is false");
       else
           Console.WriteLine("dc3 is true"); 

       if(dc1 & dc2)
          Console.WriteLine("dc1 & dc2 is true");
       else
          Console.WriteLine("dc1 & dc2 is false");

       if(dc1 & dc3)
          Console.WriteLine("dc1 & dc3 is true");
       else
          Console.WriteLine("dc1 & dc3 is false");

       if(dc1 | dc2)
          Console.WriteLine("dc1 | dc2 is true");
       else
          Console.WriteLine("dc1 | dc2 is false");

       if(dc1 | dc3)
          Console.WriteLine("dc1 | dc3 is true");
       else
          Console.WriteLine("dc1 | dc3 is false");

       if(dc1 && dc2)
          Console.WriteLine("dc1 && dc2 is true");
       else
          Console.WriteLine("dc1 && dc2 is false");

       if(dc1 && dc3)
          Console.WriteLine("dc1 && dc3 is true");
       else
          Console.WriteLine("dc1 && dc3 is false");

       if(dc1 || dc2)
          Console.WriteLine("dc1 || dc2 is true");
       else
          Console.WriteLine("dc1 || dc2 is false");

       if(dc1 || dc3)
          Console.WriteLine("dc1 || dc3 is true");
       else
          Console.WriteLine("dc1 || dc3 is false");
    }
}
