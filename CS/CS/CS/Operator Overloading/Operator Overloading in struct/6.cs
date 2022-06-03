// operator overloading in struct // *Note: enabling the short-circuit operators &&, || 

// **Note: && checks the first operand for 'false' and || checks the first operand for 'true'

// struct cannot contain explicit parameterless constructors


using System;

struct MyStruct
{
    int x;
    int y;
    int z;
 
   


    public MyStruct(int a, int b, int c)
    {
        x = a;
        y = b;
        z = b;
    }


    //*Note: In order to be applicable as a short circuit operator a user-defined logical operator 
    // ('MyStruct.operator &(MyStruct, MyStruct)') must have the same return type as the type of its 2 parameters

    public static MyStruct operator &(MyStruct op1, MyStruct op2)
    {
        if(((op1.x != 0) && (op1.y != 0) && (op1.z != 0)) & ((op2.x != 0) && (op2.y != 0) && (op2.z != 0)))
            return  new MyStruct(1, 1, 1); // Note
        else 
            return new MyStruct(0, 0, 0); // Note
    }

    //*Note: In order to be applicable as a short circuit operator a user-defined logical operator 
    // ('MyStruct.operator |(MyStruct, MyStruct)') must have the same return type as the type of its 2 parameters

    public static MyStruct operator |(MyStruct op1, MyStruct op2)
    {
        if(((op1.x != 0) || (op1.y != 0) || (op1.z != 0)) | ((op2.x != 0) || (op2.y != 0) || (op2.z != 0)))
            return  new MyStruct(1, 1, 1); // Note
        else 
            return new MyStruct(0, 0, 0); // Note
    }

    // **Note: Nothing to do with &&, ||, &, | 
    public static bool operator !(MyStruct op1)
    {
        if(op1) // Because of overloading false and true (pair) //Also: if((op1.x != 0) || (op1.y != 0) || (op1.z != 0)) // if((op1.x != 0) | (op1.y != 0) | (op1.z != 0))           
            return false; // Note                                
        else                                                              
            return true;                                                     
    }                                                                            
       
    // **Note: For overloading &&, || // Also: for overloading &, | as they return new                                                                                           
    public static bool operator true(MyStruct op1)                   
    {                                                                      
        if((op1.x != 0) || (op1.y != 0) || (op1.z != 0))        //Also: if((op1.x != 0) | (op1.y != 0) | (op1.z != 0))       
            return true;                                                               
        else                                                                
            return false;                                                 
    }                                                                              
        
    // **Note: For overloading &&, || // Also: for overloading &, | as they return new                                                      
    public static bool operator false(MyStruct op1)                     
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

struct MainStruct //
{ //
    static void Main()
    {
        MyStruct ms1 = new MyStruct(1, 2, 3);
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

       if(ms1)
           Console.WriteLine("ms1 is true");
       else
           Console.WriteLine("ms1 is false");

       if(ms2)
           Console.WriteLine("ms2 is true");
       else
           Console.WriteLine("ms2 is false");

       if(ms3)
           Console.WriteLine("ms3 is true");
       else
           Console.WriteLine("ms3 is false");

       if(!ms1)
           Console.WriteLine("ms1 is false");
       else
           Console.WriteLine("ms1 is true");

       if(!ms2)
           Console.WriteLine("ms2 is false");
       else
           Console.WriteLine("ms2 is true");

       if(!ms3)
          Console.WriteLine("ms3 is false");
       else
           Console.WriteLine("ms3 is true"); 

       if(ms1 & ms2)
          Console.WriteLine("ms1 & ms2 is true");
       else
          Console.WriteLine("ms1 & ms2 is false");

       if(ms1 & ms3)
          Console.WriteLine("ms1 & ms3 is true");
       else
          Console.WriteLine("ms1 & ms3 is false");

       if(ms1 | ms2)
          Console.WriteLine("ms1 | ms2 is true");
       else
          Console.WriteLine("ms1 | ms2 is false");

       if(ms1 | ms3)
          Console.WriteLine("ms1 | ms3 is true");
       else
          Console.WriteLine("ms1 | ms3 is false");

       if(ms1 && ms2)
          Console.WriteLine("ms1 && ms2 is true");
       else
          Console.WriteLine("ms1 && ms2 is false");

       if(ms1 && ms3)
          Console.WriteLine("ms1 && ms3 is true");
       else
          Console.WriteLine("ms1 && ms3 is false");

       if(ms1 || ms2)
          Console.WriteLine("ms1 || ms2 is true");
       else
          Console.WriteLine("ms1 || ms2 is false");

       if(ms1 || ms3)
          Console.WriteLine("ms1 || ms3 is true");
       else
          Console.WriteLine("ms1 || ms3 is false");
    }
}
