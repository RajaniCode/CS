// new(hiding) vs abstract vs virtual and override

// *without new(hiding) vs #must abstract overrididng  vs @without virtual overriding


using System;

abstract class BaseClass 
{
    public static int s = 1; 
    public int i = 2;        

    public string instanceMethod()  
    {       
        return "instanceMethod() in abstract BaseClass: " + (s + i).ToString();
    }

    public static string staticMethod(BaseClass bcp) 
    {
        return "staticMethod() in abstract BaseClass: " + (s + bcp.i).ToString(); 
    }  

    public abstract string abstractMethod(); 

    public virtual string virtualMethod()     
    {
        return "virtualMethod() in abstract BaseClass"; 
    } 
}

class DerivedClass : BaseClass
{
    // *without new(hiding)

    public override string abstractMethod() 
    {
        return "abstractMethod() must be implemented (overridden) in all derived classes at 1st level derivation (DerivedClass)\n";
    }

    // @without virtual overriding
}

class MainClass
{
    static void Main()
    {            
        BaseClass bcr; 
       
        DerivedClass dc = new DerivedClass();
        
        bcr = dc;

        Console.WriteLine(bcr.instanceMethod());                       // BaseClass    
        Console.WriteLine(dc.instanceMethod());                        // BaseClass    // *Note 
        Console.WriteLine(((BaseClass)dc).instanceMethod());           // BaseClass    
        Console.WriteLine();                                                                  
                                                                                                            
        Console.WriteLine(BaseClass.staticMethod(bcr));                // BaseClass                        
        Console.WriteLine(BaseClass.staticMethod(dc));                 // BaseClass                 
        Console.WriteLine(BaseClass.staticMethod((BaseClass)dc));      // BaseClass          
        Console.WriteLine();                                                                           
                                                                                                             
        Console.WriteLine(DerivedClass.staticMethod(bcr));             // BaseClass    // *Note 
        Console.WriteLine(DerivedClass.staticMethod(dc));              // BaseClass    // *Note 
        Console.WriteLine(DerivedClass.staticMethod((BaseClass)dc));   // BaseClass    // *Note 
        Console.WriteLine();                                                                  
                                                                                                                                                          
        Console.WriteLine(bcr.abstractMethod());                       // DerivedClass 
        Console.WriteLine(dc.abstractMethod());                        // DerivedClass  
        Console.WriteLine(((BaseClass)dc).abstractMethod());           // DerivedClass 
        Console.WriteLine();                                                            
                                                                                             
        Console.WriteLine(bcr.virtualMethod());                        // BaseClass    // @Note 
        Console.WriteLine(dc.virtualMethod());                         // BaseClass    // @Note 
        Console.WriteLine(((BaseClass)dc).virtualMethod());            // BaseClass    // @Note 
        Console.WriteLine();               
     }
}