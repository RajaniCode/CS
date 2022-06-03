// abstract class

// abstract class constructors can be overloaded using derived class constructor [using base()]

// ~NOTE: base() MUST have corresponding BaseClass constructor

// %NOTE: base() is used to assign BaseClass variables [except private (default)] MAY also be used in DerivedClass 
// [WITH DerivedClass constructor call argument in corresponding & MUST BaseClass constructor]
// [AND assign DerivedClass variables (if any) with DerivedClass constructor call argument in DerivedClass constructor]

// [>NOTE: IF base() is accompanied by EXPLICIT parameterless DerivedClass constructor, THEN EXPLICIT parameterless BaseClass constructor is a MUST]

// [^NOTE: ONLY base() CAN be used to assign [private (default)] BaseClass variables used ONLY in BaseClass
// [WITH DerivedClass constructor call argument in corresponding & MUST BaseClass constructor] 
// [In which case the following alternative CANNOT be used]

// Alternative to base():
// You can assign BOTH BaseClass variables [except private (default)] MAY also be used in DerivedClass and DerivedClass variables (if any) 
// WITH DerivedClass constructor call argument IN DerivedClass constructor
// In which case, EXPLICIT parameterless BaseClass constructor is a MUST
// [BUT not recommended because this will not work if the BaseClass variables [except private (default)] THAT MAY also be used in DerivedClass is readonly]


using System;

abstract class BaseClass 
{
    static int s = 1;
    int i = 2;

    public BaseClass(int a)
    {
        s = i = a;
        Console.WriteLine("BaseClass(int a) constructor \n"); 
    }

    public BaseClass(int a, int b)
    {
        s = a;
        i = b; 
        Console.WriteLine("BaseClass(int a, int b) constructor \n"); 
    }   

    public string instanceMethod()  
    {       
        return "instanceMethod() in BaseClass: " + (s + i).ToString();
    }

    public static string staticMethod(BaseClass bcp) 
    {
        return "staticMethod() in BaseClass: " + (s + bcp.i).ToString(); 
    }    
}

class DerivedClass : BaseClass   
{
    public DerivedClass(int a) : base(a)
    {
        Console.WriteLine("DerivedClass(int a) : base(a) constructor \n"); 
    }

    public DerivedClass(int a, int b) : base(a, b)
    {
        Console.WriteLine("DerivedClass(int a, int b) : base(a, b) constructor \n"); 
    }  
}

class MainClass
{
    static void Main()
    {
        BaseClass bcr; 
       
        DerivedClass dc1 = new DerivedClass(1000);
        bcr = dc1;

        Console.WriteLine(bcr.instanceMethod());                        // BaseClass
        Console.WriteLine(dc1.instanceMethod());                        // BaseClass  // dc1 for both DerivedClass and BaseClass instanceMethod() 
        Console.WriteLine(((BaseClass)dc1).instanceMethod());           // BaseClass  
        Console.WriteLine();                                                                          
                                                                                                    
        Console.WriteLine(BaseClass.staticMethod(bcr));                 // BaseClass                        
        Console.WriteLine(BaseClass.staticMethod(dc1));                 // BaseClass             
        Console.WriteLine(BaseClass.staticMethod((BaseClass)dc1));      // BaseClass            
        Console.WriteLine();                                                                       
                                                                                           
        Console.WriteLine(DerivedClass.staticMethod(bcr));              // BaseClass  // DerivedClass for both DerivedClass and BaseClass staticMethod() 
        Console.WriteLine(DerivedClass.staticMethod(dc1));              // BaseClass  // DerivedClass for both DerivedClass and BaseClass staticMethod()
        Console.WriteLine(DerivedClass.staticMethod((BaseClass)dc1));   // BaseClass  // DerivedClass for both DerivedClass and BaseClass staticMethod()
        Console.WriteLine();
                                                                                         
     
        DerivedClass dc2 = new DerivedClass(3, 4);        
        bcr = dc2;  
      
        Console.WriteLine(bcr.instanceMethod());                        // BaseClass
        Console.WriteLine(dc2.instanceMethod());                        // BaseClass 
        Console.WriteLine(((BaseClass)dc2).instanceMethod());           // BaseClass
        Console.WriteLine();                                               
                                                                        
        Console.WriteLine(BaseClass.staticMethod(bcr));                 // BaseClass          
        Console.WriteLine(BaseClass.staticMethod(dc2));                 // BaseClass
        Console.WriteLine(BaseClass.staticMethod((BaseClass)dc2));      // BaseClass
        Console.WriteLine();                                            
                                                                             
        Console.WriteLine(DerivedClass.staticMethod(bcr));              // BaseClass  // DerivedClass for both DerivedClass and BaseClass staticMethod()
        Console.WriteLine(DerivedClass.staticMethod(dc2));              // BaseClass  // DerivedClass for both DerivedClass and BaseClass staticMethod()
        Console.WriteLine(DerivedClass.staticMethod((BaseClass)dc2));   // BaseClass  // DerivedClass for both DerivedClass and BaseClass staticMethod()
        Console.WriteLine();
    }
}