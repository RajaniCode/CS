// abstract class 

// #Note: to call virtualMethod() that is in abstract BaseClass
// use 'base' inside an instance method [Also: parameter for the method to receive and pass to the argument (if any) inside the method]  
// or inside the overridden method of virtual (if overridden) or inside the overridden method of abstract (if any)
// using dot and argument for the parameter(if any) 

// *Note: 'base' cannot be used in a static method 

// @Note: 'base' ONLY for new (instance method that is in BaseClass) AND virtual (method that is in BaseClass) 
// BUT NOT for abstract method (method that is in BaseClass) 

// $Note:  use BaseClass for new (static method that is in BaseClass) 
// inside static or instance method [Also: parameter for the method to receive and pass to the argument (if any) inside the method]
// using dot and argument for the parameter (if any)


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

    public override string abstractMethod() 
    {
        BaseClass bcr;       
        DerivedClass dc = new DerivedClass();        
        bcr = dc;
        Console.WriteLine(BaseClass.staticMethod(bcr)); // $Note
        Console.WriteLine(baseinstanceMethod()); // #Note // *Note // @Note
        Console.WriteLine(base.virtualMethod()); // #Note // *Note // @Note
        return "abstractMethod() must be implemented (overridden) in all derived classes at 1st level derivation (DerivedClass)\n";
    } 
   
    public override string virtualMethod()
    {
        BaseClass bcr;       
        DerivedClass dc = new DerivedClass();        
        bcr = dc;
        Console.WriteLine(BaseClass.staticMethod(bcr)); // $Note 
        Console.WriteLine(baseinstanceMethod()); // #Note // *Note // @Note
        Console.WriteLine(base.virtualMethod()); // #Note // *Note // @Note
        return "virtualMethod() implementation (overriding) NOT A MUST in DerivedClass (DerivedClass)\n"; 
    } 
    
    public string basevirtualMethod() // #Note // *Note // @Note
    {
        return base.virtualMethod(); 
    }

    public string baseinstanceMethod() // #Note // *Note // @Note
    {
        return base.instanceMethod(); 
    }

    public string basestaticMethod(BaseClass bcp) // $Note
    {
        return BaseClass.staticMethod(bcp); 
    }
}


class MainClass
{
    static void Main()
    {
        BaseClass bcr; 
       
        DerivedClass dc = new DerivedClass();
        
        bcr = dc;
        
        Console.WriteLine(bcr.instanceMethod());                       // BaseClass    
        Console.WriteLine(dc.instanceMethod());                        // DerivedClass 
        Console.WriteLine(((BaseClass)dc).instanceMethod());           // BaseClass    
        Console.WriteLine();                                                                  
                                                                                                            
        Console.WriteLine(BaseClass.staticMethod(bcr));                // BaseClass                        
        Console.WriteLine(BaseClass.staticMethod(dc));                 // BaseClass                 
        Console.WriteLine(BaseClass.staticMethod((BaseClass)dc));      // BaseClass          
        Console.WriteLine();

        Console.WriteLine(bcr.abstractMethod());                       // DerivedClass
        Console.WriteLine(dc.abstractMethod());                        // DerivedClass
        Console.WriteLine(((BaseClass)dc).abstractMethod());           // DerivedClass
        Console.WriteLine();

        Console.WriteLine(bcr.virtualMethod());                        // DerivedClass // IF virtualMethod() NOT OVERRIDDEN in DerivedClass, BaseClass
        Console.WriteLine(dc.virtualMethod());                         // DerivedClass // IF virtualMethod() NOT OVERRIDDEN in DerivedClass, BaseClass
        Console.WriteLine(((BaseClass)dc).virtualMethod());            // DerivedClass // IF virtualMethod() NOT OVERRIDDEN in DerivedClass, BaseClass
        Console.WriteLine();

        Console.WriteLine(dc.basevirtualMethod());                     // base
        Console.WriteLine();

        Console.WriteLine(dc.baseinstanceMethod());                    // base
        Console.WriteLine();  

        Console.WriteLine(dc.basestaticMethod(bcr));                   // BaseClass 
        Console.WriteLine();     
     }
}