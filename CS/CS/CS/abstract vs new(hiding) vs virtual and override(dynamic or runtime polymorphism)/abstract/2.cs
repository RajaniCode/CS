// abstract class

// static methods in abstract class can access instance variables by
// 1. USING BASE CLASS REFERENCE PASSED IN PARAMETER that allows [BASE CLASS REFERENCE that refers DERIVED CLASS OBJECT] PASSED IN ARGUMENT from Main()
// 2. USING BASE CLASS REFERENCE PASSED IN PARAMETER that allows [DERIVED CLASS OBJECT] PASSED IN ARGUMENT from Main()

// 3. USING DERIVED CLASS REFERENCE PASSED IN PARAMETER that allows [(TYPE CAST using DERIVED CLASS)BASE CLASS REFERENCE that refers DERIVED CLASS OBJECT] PASSED IN ARGUMENT from Main()
// 4. USING DERIVED CLASS REFERENCE PASSED IN PARAMETER that allows [DERIVED CLASS OBJECT] PASSED IN ARGUMENT from Main()


using System;

abstract class BaseClass
{
    static int s = 1;
    int i = 2;

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
   
}


class MainClass
{
    static void Main()
    {
        BaseClass bcr; 
       
        DerivedClass dc = new DerivedClass();
        
        bcr = dc;  
        
        Console.WriteLine(bcr.instanceMethod());                         // BaseClass
        Console.WriteLine(dc.instanceMethod());                          // BaseClass
        Console.WriteLine(((BaseClass)dc).instanceMethod());             // BaseClass
        Console.WriteLine();       
                                                                                  
        Console.WriteLine(BaseClass.staticMethod((DerivedClass)bcr));    // #Note  // BaseClass          
        Console.WriteLine(BaseClass.staticMethod(dc));                             // BaseClass
        Console.WriteLine(BaseClass.staticMethod((DerivedClass)dc));     // #Note  // BaseClass
        Console.WriteLine();                                                          
                                                                                     
        Console.WriteLine(DerivedClass.staticMethod((DerivedClass)bcr)); // #Note  // BaseClass 
        Console.WriteLine(DerivedClass.staticMethod(dc));                          // BaseClass 
        Console.WriteLine(DerivedClass.staticMethod((DerivedClass)dc));  // #Note  // BaseClass 
        Console.WriteLine();
    }
}