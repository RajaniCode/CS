// *new(hiding) vs @virtual and override


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

    sealed public  override string virtualMethod()  
    {        
        return "virtualMethod() implementation (overriding) [can be sealed] NOT A MUST in DerivedClass (DerivedClass)\n"; 
    } 
}

class MoreDerivedClass : DerivedClass 
{
    /*
    public new virtual string virtualMethod()
    {   
        Console.WriteLine(base.virtualMethod());
        return "virtualMethod() is 'new' and vitual, and cannot override (MoreDerivedClass)\n";
    }
    */
}

class MainClass
{
    static void Main()
    {
        Console.WriteLine("# 1\n");
        BaseClass[] bcarray1 = new BaseClass[1];
        bcarray1[0] = new BaseClass();  
        Console.WriteLine(bcarray1[0].instanceMethod());                    // BaseClass     // like bc
        Console.WriteLine(BaseClass.staticMethod(bcarray1[0]));    // Note  // BaseClass     // like BaseClass 
        Console.WriteLine(DerivedClass.staticMethod(bcarray1[0])); // Note  // DerivedClass  // like DerivedClass
        Console.WriteLine(bcarray1[0].virtualMethod());                     // BaseClass     // like bc  
        Console.WriteLine();                                                                
                                                                                                                             
        Console.WriteLine("# 2\n");                                                                       
        BaseClass[] bcarray2 = new DerivedClass[1];                                                            
        bcarray2[0] = new DerivedClass();                                                                      
        Console.WriteLine(bcarray2[0].instanceMethod());                    // BaseClass     // like bcr
        Console.WriteLine(BaseClass.staticMethod(bcarray2[0]));    // Note  // BaseClass     // like BaseClass
        Console.WriteLine(DerivedClass.staticMethod(bcarray2[0])); // Note  // DerivedClass  // like DerivedClass
        Console.WriteLine(bcarray2[0].virtualMethod());                     // DerivedClass  // like bcr  // if virtualMethod() not implemented, BaseClass  
        Console.WriteLine();                                                
                                                                                
        Console.WriteLine("# 3\n");                                            
        BaseClass bc = new BaseClass();                                     // BaseClass
        Console.WriteLine(bc.instanceMethod());                             // BaseClass  
        Console.WriteLine(BaseClass.staticMethod(bc));                      // BaseClass
        Console.WriteLine(bc.virtualMethod());                                                    
        Console.WriteLine();                                                                                                    
                                                                                                                                                                                                       
        BaseClass bcr;                                                          
                                                                                                                                                          
        DerivedClass dc = new DerivedClass();                                     
                                                                                  
        bcr = dc;                                                                                                                                                                                                  
                                                                               
        Console.WriteLine("# 4\n");                                                                      
        Console.WriteLine(bcr.instanceMethod());                            // BaseClass     
        Console.WriteLine(dc.instanceMethod());                             // DerivedClass 
        Console.WriteLine(((BaseClass)dc).instanceMethod());                // BaseClass     
        Console.WriteLine();                                               
                                                                         
        Console.WriteLine("# 5\n");                                                      
        Console.WriteLine(BaseClass.staticMethod(bcr));                     // BaseClass          
        Console.WriteLine(BaseClass.staticMethod(dc));                      // BaseClass
        Console.WriteLine(BaseClass.staticMethod((BaseClass)dc));           // BaseClass
        Console.WriteLine();                                            
                                                                            
        Console.WriteLine("# 6\n");                                                                     
        Console.WriteLine(DerivedClass.staticMethod(bcr));                  // DerivedClass  
        Console.WriteLine(DerivedClass.staticMethod(dc));                   // DerivedClass  
        Console.WriteLine(DerivedClass.staticMethod((BaseClass)dc));        // DerivedClass   
        Console.WriteLine();                                              
                                                                                   
        Console.WriteLine("# 7\n");                                                                                                                                                   
        Console.WriteLine(bcr.virtualMethod());                             // DerivedClass // if virtualMethod() not implemented, BaseClass  
        Console.WriteLine(dc.virtualMethod());                              // DerivedClass // if virtualMethod() not implemented, BaseClass
        Console.WriteLine(((BaseClass)dc).virtualMethod());                 // DerivedClass // if virtualMethod() not implemented, BaseClass  
        Console.WriteLine();        


        // MoreDerivedClass mdc = new MoreDerivedClass();

        // Console.WriteLine(mdc.virtualMethod());
     }
}