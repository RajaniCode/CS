// new(hiding) vs virtual and override

// #Note: virtualMethod() implementation (overriding) NOT A MUST in DerivedClass (DerivedClass)


using System;

class BaseClass 
{
    public static int s = 1; // #Note
    public int i = 2;        // #Note

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
    public new string instanceMethod()  //  Use the 'new' keyword if hiding was intended.
    {       
        return "instanceMethod() in DerivedClass: " + (s + i).ToString();
    }

    public new static string staticMethod(BaseClass bcp) //  Use the 'new' keyword if hiding was intended.
    {
        return "staticMethod() in DerivedClass: " + (s + bcp.i).ToString(); 
    } 
   
    // #Note: virtualMethod() implementation (overriding) NOT A MUST in DerivedClass (DerivedClass)
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
                                                                              
        Console.WriteLine(DerivedClass.staticMethod(bcr));             // DerivedClass  
        Console.WriteLine(DerivedClass.staticMethod(dc));              // DerivedClass  
        Console.WriteLine(DerivedClass.staticMethod((BaseClass)dc));   // DerivedClass   
        Console.WriteLine();                                                              
                                                                                                                                                                                                                     
        Console.WriteLine(bcr.virtualMethod());                       // BaseClass  // #Note 
        Console.WriteLine(dc.virtualMethod());                        // BaseClass  // #Note 
        Console.WriteLine(((BaseClass)dc).virtualMethod());           // BaseClass  // #Note 
        Console.WriteLine();        
     }
}