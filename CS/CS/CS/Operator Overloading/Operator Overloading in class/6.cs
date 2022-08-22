// operator overloading in class // *Note: enabling the short-circuit operators &&, || 

// **Note: && checks the first operand for 'false' and || checks the first operand for 'true'


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
        z = b;
    }


    //*Note: In order to be applicable as a short circuit operator a user-defined logical operator 
    // ('MyClass.operator &(MyClass, MyClass)') must have the same return type as the type of its 2 parameters

    public static MyClass operator &(MyClass op1, MyClass op2)
    {
        if(((op1.x != 0) && (op1.y != 0) && (op1.z != 0)) & ((op2.x != 0) && (op2.y != 0) && (op2.z != 0)))
            return  new MyClass(1, 1, 1); // Note
        else 
            return new MyClass(0, 0, 0); // Note
    }

    //*Note: In order to be applicable as a short circuit operator a user-defined logical operator 
    // ('MyClass.operator |(MyClass, MyClass)') must have the same return type as the type of its 2 parameters

    public static MyClass operator |(MyClass op1, MyClass op2)
    {
        if(((op1.x != 0) || (op1.y != 0) || (op1.z != 0)) | ((op2.x != 0) || (op2.y != 0) || (op2.z != 0)))
            return  new MyClass(1, 1, 1); // Note
        else 
            return new MyClass(0, 0, 0); // Note
    }

    // **Note: Nothing to do with &&, ||, &, | 
    public static bool operator !(MyClass op1)
    {
        if(op1) // Because of overloading false and true (pair) //Also: if((op1.x != 0) || (op1.y != 0) || (op1.z != 0)) // if((op1.x != 0) | (op1.y != 0) | (op1.z != 0))           
            return false; // Note                                
        else                                                              
            return true;                                                     
    }                                                                            
       
    // **Note: For overloading &&, || // Also: for overloading &, | as they return new                                                                                           
    public static bool operator true(MyClass op1)                   
    {                                                                      
        if((op1.x != 0) || (op1.y != 0) || (op1.z != 0))        //Also: if((op1.x != 0) | (op1.y != 0) | (op1.z != 0))       
            return true;                                                               
        else                                                                
            return false;                                                 
    }                                                                              
        
    // **Note: For overloading &&, || // Also: for overloading &, | as they return new                                                      
    public static bool operator false(MyClass op1)                     
    {                                                                                                                             
        if((op1.x == 0) && (op1.y == 0) && (op1.z == 0))        // Also: if((op1.x == 0) & (op1.y == 0) & (op1.z == 0))    
            return true; // Note
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

       if(mc1)
           Console.WriteLine("mc1 is true");
       else
           Console.WriteLine("mc1 is false");

       if(mc2)
           Console.WriteLine("mc2 is true");
       else
           Console.WriteLine("mc2 is false");

       if(mc3)
           Console.WriteLine("mc3 is true");
       else
           Console.WriteLine("mc3 is false");

       if(!mc1)
           Console.WriteLine("mc1 is false");
       else
           Console.WriteLine("mc1 is true");

       if(!mc2)
           Console.WriteLine("mc2 is false");
       else
           Console.WriteLine("mc2 is true");

       if(!mc3)
          Console.WriteLine("mc3 is false");
       else
           Console.WriteLine("mc3 is true"); 

       if(mc1 & mc2)
          Console.WriteLine("mc1 & mc2 is true");
       else
          Console.WriteLine("mc1 & mc2 is false");

       if(mc1 & mc3)
          Console.WriteLine("mc1 & mc3 is true");
       else
          Console.WriteLine("mc1 & mc3 is false");

       if(mc1 | mc2)
          Console.WriteLine("mc1 | mc2 is true");
       else
          Console.WriteLine("mc1 | mc2 is false");

       if(mc1 | mc3)
          Console.WriteLine("mc1 | mc3 is true");
       else
          Console.WriteLine("mc1 | mc3 is false");

       if(mc1 && mc2)
          Console.WriteLine("mc1 && mc2 is true");
       else
          Console.WriteLine("mc1 && mc2 is false");

       if(mc1 && mc3)
          Console.WriteLine("mc1 && mc3 is true");
       else
          Console.WriteLine("mc1 && mc3 is false");

       if(mc1 || mc2)
          Console.WriteLine("mc1 || mc2 is true");
       else
          Console.WriteLine("mc1 || mc2 is false");

       if(mc1 || mc3)
          Console.WriteLine("mc1 || mc3 is true");
       else
          Console.WriteLine("mc1 || mc3 is false");
    }
}
