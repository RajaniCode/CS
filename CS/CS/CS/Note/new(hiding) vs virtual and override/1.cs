// new(hiding) vs virtual and override

// #NOTE


using System;

class BaseClass 
{
    public static int s = 1; 
    public int i = 2;        

    public string instanceMethod()  
    {       
        return "instanceMethod() in BaseClass: " + (s + i).ToString();
    }

    public static string staticMethod(BaseClass bcp) 
    {
        return "staticMethod() in BaseClass: " + (s + bcp.i).ToString(); 
    }
  
    public virtual string virtualMethod() 
    {
        return "virtualMethod() in BaseClass"; 
    } 
}

class DerivedClass : BaseClass
{
    public new string instanceMethod()  
    {       
        return "instanceMethod() in DerivedClass: " + (s + i).ToString();
    }

    public new static string staticMethod(BaseClass bcp) 
    {
        return "staticMethod() in DerivedClass: " + (s + bcp.i).ToString(); 
    } 
   
    public override string virtualMethod()
    {
	// Console.WriteLine(base.virtualMethod()); 
        return "virtualMethod() implementation (overriding) NOT A MUST in DerivedClass (DerivedClass)\n"; 
    }
}


class MainClass
{
    static void Main()
    {
        BaseClass bcr; 
       
        BaseClass bc = new BaseClass();

        DerivedClass dc = new DerivedClass();
        
        bcr = dc; // Same as // bcr = new DerivedClass();

        Console.WriteLine(bc.instanceMethod());                        // BaseClass          
        Console.WriteLine(bcr.instanceMethod());                       // BaseClass    
        Console.WriteLine(dc.instanceMethod());                        // DerivedClass 
        Console.WriteLine(((BaseClass)dc).instanceMethod());           // BaseClass    
        Console.WriteLine();

        Console.WriteLine(BaseClass.staticMethod(bc));                 // BaseClass  
        Console.WriteLine(BaseClass.staticMethod(bcr));                // BaseClass                        
        Console.WriteLine(BaseClass.staticMethod(dc));                 // BaseClass                 
        Console.WriteLine(BaseClass.staticMethod((BaseClass)dc));      // BaseClass          
        Console.WriteLine();
 
        Console.WriteLine(DerivedClass.staticMethod(bc));              // DerivedClass      
        Console.WriteLine(DerivedClass.staticMethod(bcr));             // DerivedClass                       
        Console.WriteLine(DerivedClass.staticMethod(dc));              // DerivedClass                
        Console.WriteLine(DerivedClass.staticMethod((BaseClass)dc));   // DerivedClass        
        Console.WriteLine();
        
        Console.WriteLine(bc.virtualMethod());                // #NOTE // BaseClass // EVEN IF virtualMethod() OVERRIDDEN in DerivedClass
        Console.WriteLine(bcr.virtualMethod());                        // DerivedClass // IF virtualMethod() NOT OVERRIDDEN in DerivedClass, BaseClass
        Console.WriteLine(dc.virtualMethod());                         // DerivedClass // IF virtualMethod() NOT OVERRIDDEN in DerivedClass, BaseClass
        Console.WriteLine(((BaseClass)dc).virtualMethod());            // DerivedClass // IF virtualMethod() NOT OVERRIDDEN in DerivedClass, BaseClass
        Console.WriteLine();  
     }
}