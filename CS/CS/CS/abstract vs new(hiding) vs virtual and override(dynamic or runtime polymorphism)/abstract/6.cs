// abstract class 

// can have const, readonly [which can be assigned ONLY in BaseClass constructor via DerivedClass constructor using base()]

// can extend built-in object


using System;

abstract class BaseClass : object
{
    public const int c = 1;

    public readonly int r = 2;

    static int s = 3;

    int i = 4;

    public BaseClass(int rp)
    {
        r = rp;
        Console.WriteLine("\ninstance constructor BaseClass(int rp) invoked and r = rp: {0}\n", r);
    }

    public string instanceMethod()  
    {       
        return "instanceMethod() in abstract BaseClass: " + (s + i).ToString();
    }

    public static string staticMethod(DerivedClass dcp) // #Note
    {
        return "staticMethod() in abstract BaseClass: " + (s + dcp.i).ToString(); 
    }
}

class DerivedClass : BaseClass
{
    public DerivedClass(int rp) : base(rp)
    {

    }
}


class MainClass
{
    static void Main()
    {
        BaseClass bcr; 
       
        DerivedClass dc = new DerivedClass(777);
        
        bcr = dc;  

        Console.WriteLine("\nValue of const = BaseClass.c = {0}\n", BaseClass.c);
        Console.WriteLine("\nValue of const = DerivedClass.c = {0}\n", DerivedClass.c);
        Console.WriteLine("\nValue of readonly = bcr.r = {0}\n", bcr.r);
        Console.WriteLine("\nValue of readonly = dc.r = {0}\n", dc.r);
        Console.WriteLine("\nValue of readonly = ((BaseClass)dc).r = {0}\n", ((BaseClass)dc).r);
  

        Console.WriteLine(bcr.instanceMethod());                         // BaseClass
        Console.WriteLine(dc.instanceMethod());                          // BaseClass  // dc for both DerivedClass and BaseClass instanceMethod()
        Console.WriteLine(((BaseClass)dc).instanceMethod());             // BaseClass  
        Console.WriteLine();                                                           
                                                                                                                        
        Console.WriteLine(BaseClass.staticMethod((DerivedClass)bcr));    // BaseClass            
        Console.WriteLine(BaseClass.staticMethod(dc));                   // BaseClass    
        Console.WriteLine(BaseClass.staticMethod((DerivedClass)dc));     // BaseClass   
        Console.WriteLine();                                                            
                                                                                        
        Console.WriteLine(DerivedClass.staticMethod((DerivedClass)bcr)); // BaseClass  // DerivedClass for both DerivedClass and BaseClass staticMethod()
        Console.WriteLine(DerivedClass.staticMethod(dc));                // BaseClass  // DerivedClass for both DerivedClass and BaseClass staticMethod()
        Console.WriteLine(DerivedClass.staticMethod((DerivedClass)dc));  // BaseClass  // DerivedClass for both DerivedClass and BaseClass staticMethod()
        Console.WriteLine();
    }
}