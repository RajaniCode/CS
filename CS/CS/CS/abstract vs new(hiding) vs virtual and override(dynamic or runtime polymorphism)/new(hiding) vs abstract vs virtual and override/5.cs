// abstract class 

// #Note: protected


// abstract, virtual CANNOT be private (default) in base class
// and when overridden in derived class, the access modifier, return type and parameter(if any) should be same

// abstract, virtual CAN be protected in base class BUT:
// accessed ONLY INSIDE *derived class (or derived from it) 
// accessed ONLY INSIDE *derived classes[including further derived] of the same/different assembly
// [#especially for instance member] via a qualifier of type derived class [$via qualifier of further derived in further derived] 
// [*derived class should NOT be thought of Main()'s class]
// [Note: class should be public for accessing from derived class in different assembly]


using System;

abstract class BaseClass 
{
    protected static int s = 1; // #Note
    protected int i = 2;        // #Note   

    protected string instanceMethod() // #Note
    {       
        return "instanceMethod() in abstract BaseClass: " + (s + i).ToString();
    }

    protected static string staticMethod(DerivedClass dcp) // #Note
    {
        return "staticMethod() in abstract BaseClass: " + (s + dcp.i).ToString(); 
    }

    protected abstract string abstractMethod(); // #Note
   
    protected virtual string virtualMethod() // #Note
    {
        return "virtualMethod() in abstract BaseClass"; 
    } 
}

class DerivedClass : BaseClass
{
    protected new string instanceMethod()  // #Note
    {       
        return "instanceMethod() in DerivedClass: " + (s + i).ToString();
    }

    protected new static string staticMethod(DerivedClass dcp) // #Note
    {
        return "staticMethod() in DerivedClass: " + (s + dcp.i).ToString(); // #Note
    } 

    protected override string abstractMethod() // #Note
    {
        return "abstractMethod() must be implemented (overridden) in all derived classes at 1st level derivation (DerivedClass)\n";
    } 
   
    protected override string virtualMethod() // #Note 
    {
        return "virtualMethod() implementation (overriding) NOT A MUST in DerivedClass (DerivedClass)\n"; 
    } 
    
    string basevirtualMethod() // #Note 
    {
        return base.virtualMethod(); 
    }

    string baseinstanceMethod() // #Note 
    {
        return base.instanceMethod(); 
    }

    string basestaticMethod(DerivedClass dcp) // #Note 
    {
        return BaseClass.staticMethod(dcp); 
    }

    // #Note

    static void Main()
    {
        DerivedClass dc = new DerivedClass();
        
        Console.WriteLine(dc.instanceMethod());           // DerivedClass // #Note               
        Console.WriteLine();  
            
                                                         
        Console.WriteLine(BaseClass.staticMethod(dc));    // BaseClass    // #Note              
        Console.WriteLine(DerivedClass.staticMethod(dc)); // DerivedClass // #Note
        Console.WriteLine(staticMethod(dc));              // DerivedClass // #Note                                                                   
        Console.WriteLine();

        Console.WriteLine(dc.abstractMethod());           // DerivedClass // #Note             
        Console.WriteLine();

        Console.WriteLine(dc.virtualMethod());            // DerivedClass // #Note              
        Console.WriteLine();

        Console.WriteLine(dc.basevirtualMethod());        // base         // #Note 
        Console.WriteLine();

        Console.WriteLine(dc.baseinstanceMethod());       // base         // #Note 
        Console.WriteLine();  

        Console.WriteLine(dc.basestaticMethod(dc));       // BaseClass    // #Note 
        Console.WriteLine();     
     }
}