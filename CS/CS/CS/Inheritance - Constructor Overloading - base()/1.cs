// Inheritance - Constructor Overloading // Run from command prompt to see destructors


using System;
 
class BaseClass
{
    public BaseClass()  
    {
        Console.WriteLine("\nBaseClass() constructor invoked"); // 1, 2     
    }

    ~BaseClass()  
    {
        Console.WriteLine("\nBaseClass() destructor invoked"); // 5, 6     
    }
}

class DerivedClass : BaseClass
{
    public DerivedClass() 
    {
      Console.WriteLine("\nDerivedClass() constructor invoked"); // 3
    }                                                              
    
    ~DerivedClass()                                                   
    {
      Console.WriteLine("\nDerivedClass() destructor invoked"); // 4  
    }     
}

class MainClass
{
    static void Main()
    {
        BaseClass bc = new BaseClass();        
                                               
        Console.WriteLine("\nNext");
        
        DerivedClass dc = new DerivedClass();             
                                               
        Console.WriteLine("\nLast");           
    }       
}