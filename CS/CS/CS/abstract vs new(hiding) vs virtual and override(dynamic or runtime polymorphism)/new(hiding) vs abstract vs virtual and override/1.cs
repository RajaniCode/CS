// new(hiding) vs abstract vs virtual and override


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
    public new string instanceMethod()  //  Use the 'new' keyword if hiding was intended.
    {       
        return "instanceMethod() in DerivedClass: " + (s + i).ToString();
    }

    public new static string staticMethod(BaseClass bcp) //  Use the 'new' keyword if hiding was intended. // Cannot be sealed because not override
    {
        return "staticMethod() in DerivedClass: " + (s + bcp.i).ToString(); 
    } 

    sealed public override string abstractMethod() // Can be sealed
    {
        return "abstractMethod() must be implemented (overridden) in all derived classes at 1st level derivation and can be 'sealed' (DerivedClass)\n";
    }

    sealed public  override string virtualMethod()  // Can be sealed
    {        
        return "virtualMethod() implementation (overriding) NOT A MUST in DerivedClass and can be 'sealed' (DerivedClass)\n"; 
    } 
}

class MainClass
{
    static void Main()
    {   
        Console.WriteLine("# 1\n");
        BaseClass[] bcarray = new BaseClass[1];
        bcarray[0] = new DerivedClass();  
        Console.WriteLine(bcarray[0].instanceMethod());                     // BaseClass     // like bcr
        Console.WriteLine(BaseClass.staticMethod(bcarray[0]));    // Note   // BaseClass     // like BaseClass
        Console.WriteLine(DerivedClass.staticMethod(bcarray[0])); // Note   // DerivedClass  // like DerivedClass
        Console.WriteLine(bcarray[0].abstractMethod());                     // DerivedClass  // like bcr  // abstractMethod() MUST be implemented
        Console.WriteLine(bcarray[0].virtualMethod());                      // DerivedClass  // like bcr  // if virtualMethod() not implemented, BaseClass  
        Console.WriteLine();                                                     
                                                                                                                                                                
        BaseClass bcr;                                                                                                                      
                                                                                                    
        DerivedClass dc = new DerivedClass();                                         
                                                                                                                                                                     
        bcr = dc;                                                                     
                                                                                                 
        Console.WriteLine("# 2\n");                                                                                                                                                          
        Console.WriteLine(bcr.instanceMethod());                            // BaseClass     
        Console.WriteLine(dc.instanceMethod());                             // DerivedClass 
        Console.WriteLine(((BaseClass)dc).instanceMethod());                // BaseClass    
        Console.WriteLine();                                                                                                                                                        
                                                                                                      
        Console.WriteLine("# 3\n");                                                                                                                                                                                  
        Console.WriteLine(BaseClass.staticMethod(bcr));                     // BaseClass                        
        Console.WriteLine(BaseClass.staticMethod(dc));                      // BaseClass                 
        Console.WriteLine(BaseClass.staticMethod((BaseClass)dc));           // BaseClass          
        Console.WriteLine();                                                                                                                                                                 
                                                                                                   
        Console.WriteLine("# 4\n");                                                                                                
        Console.WriteLine(DerivedClass.staticMethod(bcr));                  // DerivedClass 
        Console.WriteLine(DerivedClass.staticMethod(dc));                   // DerivedClass 
        Console.WriteLine(DerivedClass.staticMethod((BaseClass)dc));        // DerivedClass 
        Console.WriteLine();                                                                  
                                                                                                                                                                                                                                                
        Console.WriteLine("# 5\n");                                                                                      
        Console.WriteLine(bcr.abstractMethod());                            // DerivedClass // abstractMethod() MUST be implemented
        Console.WriteLine(dc.abstractMethod());                             // DerivedClass // abstractMethod() MUST be implemented 
        Console.WriteLine(((BaseClass)dc).abstractMethod());                // DerivedClass // abstractMethod() MUST be implemented 
        Console.WriteLine();                                                            
                                                                                                   
        Console.WriteLine("# 6\n");                                                                                
        Console.WriteLine(bcr.virtualMethod());                             // DerivedClass // if virtualMethod() not implemented, BaseClass
        Console.WriteLine(dc.virtualMethod());                              // DerivedClass // if virtualMethod() not implemented, BaseClass 
        Console.WriteLine(((BaseClass)dc).virtualMethod());                 // DerivedClass // if virtualMethod() not implemented, BaseClass
        Console.WriteLine();              
     }
}