// Override // CS // Java
using System;

class Program 
{
    static void Main() 
    {     
	BaseClass bc = new BaseClass();                                                                                                                                                      
        BaseClass bcr;                                                                             
        DerivedClass dc = new DerivedClass();                                                                                                                        
        bcr = dc;                                                                              
                   
	Console.WriteLine(bc.InstanceMethod()); // BaseClass
	Console.WriteLine(dc.InstanceMethod()); // DerivedClass // if instanceMethod() not implemented in DerivedClass, BaseClass                                                                                                                                       
        Console.WriteLine(bcr.InstanceMethod()); // DerivedClass // Differs from CS regardless of 'new' modifier as methods are virtual by default in Java // if instanceMethod() not implemented in DerivedClass, BaseClass
        Console.WriteLine(((BaseClass)dc).InstanceMethod()); // DerivedClass // Differs from CS regardless of 'new' modifier as methods are virtual by default in Java // if instanceMethod() not implemented in DerivedClass, BaseClass
     }
}

class BaseClass {
    // hiding intended in CS // virtual by default in Java hence @Override 
    public string InstanceMethod() 
    {     
        return "InstanceMethod() in BaseClass";
    }
}

class DerivedClass : BaseClass 
{
    // hiding intended in CS // virtual by default in Java hence @Override 
    // warning CS0108: 'DerivedClass.InstanceMethod()' hides inherited member 'BaseClass.InstanceMethod()'. Use the new keyword if hiding was intended.
    public string InstanceMethod() 
    {     
        return "InstanceMethod() in DerivedClass";
    }
}

// Output
/*
/Users/rajaniapple/Desktop/Mnemonics/Override/Program.cs(32,19): warning CS0108: 'DerivedClass.InstanceMethod()' hides inherited member 'BaseClass.InstanceMethod()'. Use the new keyword if hiding was intended. [/Users/rajaniapple/Desktop/Mnemonics/Override/Override.csproj]
InstanceMethod() in BaseClass
InstanceMethod() in DerivedClass
InstanceMethod() in BaseClass
InstanceMethod() in BaseClass
*/