// abstract class

// abstract class can have constructors (instance/static (which must be parameterless)), destructors


using System;

abstract class BaseClass 
{
    static int s = 1;
    int i = 2;
    
    static BaseClass() // Note
    {
        s = 3; 
        Console.WriteLine("\nstatic constructor automatically invoked\n");
    }  

    public BaseClass() // Note
    {
        i = 4; 
    } 

    ~BaseClass() // Note
    {
        Console.WriteLine("\nBaseClass destructor");
    }

    public string instanceMethod()  
    {       
        return "instanceMethod() in abstract BaseClass: " + (s + i).ToString();
    }

    public static string staticMethod(BaseClass bcp) 
    {
        return "staticMethod() in abstract BaseClass: " + (s + bcp.i).ToString(); 
    }     
}

class DerivedClass : BaseClass
{

}


class MainClass
{
    static void Main()
    {
        BaseClass bcr; 
       
        DerivedClass dc = new DerivedClass();
        
        bcr = dc;  
      
        Console.WriteLine(bcr.instanceMethod());                       // BaseClass
        Console.WriteLine(dc.instanceMethod());                        // BaseClass  // dc for both DerivedClass and BaseClass instanceMethod()
        Console.WriteLine(((BaseClass)dc).instanceMethod());           // BaseClass  
        Console.WriteLine();                                                              
                                                                                          
        Console.WriteLine(BaseClass.staticMethod(bcr));                // BaseClass            
        Console.WriteLine(BaseClass.staticMethod(dc));                 // BaseClass            
        Console.WriteLine(BaseClass.staticMethod((BaseClass)dc));      // BaseClass        
        Console.WriteLine();                                                           
                                                                                       
        Console.WriteLine(DerivedClass.staticMethod(bcr));             // BaseClass  // DerivedClass for both DerivedClass and BaseClass staticMethod()
        Console.WriteLine(DerivedClass.staticMethod(dc));              // BaseClass  // DerivedClass for both DerivedClass and BaseClass staticMethod()
        Console.WriteLine(DerivedClass.staticMethod((BaseClass)dc));   // BaseClass  // DerivedClass for both DerivedClass and BaseClass staticMethod()
        Console.WriteLine();
    }
}