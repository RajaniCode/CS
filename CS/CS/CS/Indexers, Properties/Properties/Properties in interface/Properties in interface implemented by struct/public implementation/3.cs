// Properties in struct, public implementation by struct

// #Note: get operation should be nonintrusive although not enforced by the compiler


using System;

interface MyInterface
{
    int property
    {
        get;
        set;
    }    
}

struct MyStruct : MyInterface
{
    public int n; // cannot have instance field initializers in structs

    public int property  
    {
        get
        {
            return n;
        }
        
        set
        {
            if(value>=0) 
                n = value;
        }
    }

    //  Structs cannot contain explicit parameterless constructors
}

struct MainClass
{
    static void Main()
    {
        MyStruct ms = new MyStruct();

        Console.WriteLine("Initial value of n: {0} \n", ms.n);
        Console.WriteLine("Initial value of property: {0} \n", ms.property);
        
        ms.n = -10; 
        ms.property = 5;
        Console.WriteLine("After assigning n = -10 and property = 5, value of n: {0} \n", ms.n);   
        Console.WriteLine("After assigning n = -10 and property = 5, value of property: {0} \n", ms.property);
         
        ms.n = -20; 
        ms.property = -25;
        Console.WriteLine("After assigning n = -20 and property = -1, value of n: {0} \n",ms.n);    
        Console.WriteLine("After assigning n = -20 and property = -1, value of property: {0} \n", ms.property);

        ms.n = -30; 
        ms.property = 50;
        Console.WriteLine("After assigning n = -30 and property = 50, value of n: {0} \n",ms.n);    
        Console.WriteLine("After assigning n = -30 and property = 50, value of property: {0} \n", ms.property);                

        ms.n = 80; 
        ms.property = -70;
        Console.WriteLine("After assigning n = 80 and property = -70, value of n: {0} \n",ms.n);    
        Console.WriteLine("After assigning n = 80 and property = -70, value of property: {0} \n", ms.property);  

        ms.property = 2;
        Console.WriteLine("After assigning property = 2, value of n: {0} \n",ms.n);    
        Console.WriteLine("After assigning property = 2, value of property: {0} \n", ms.property);                
                 
        ms.n = 1; 
        Console.WriteLine("After assigning n = 1, value of n: {0} \n",ms.n);    
        Console.WriteLine("After assigning n = 1, value of property: {0} \n", ms.property);  

        ms.n = 3; 
        ms.property = 4;
        Console.WriteLine("After assigning n = 3 and property = 4, value of n: {0} \n",ms.n);    
        Console.WriteLine("After assigning n = 3 and property = 4, value of property: {0} \n", ms.property);        
    } 
}
   
    
    


 
         







    