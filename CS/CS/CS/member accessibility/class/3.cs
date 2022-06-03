// class memebr accessibility

// protected 

// #Note: via a qualifier of type base class [especially for instance member]

// *Note: derived class should NOT be thought of Main()'s class

using System;

public class BaseClass
{
    protected static void staticmethodBaseClass()
    {
        Console.WriteLine("staticmethodBaseClass()\n");
    }
 
    protected void instancemethodBaseClass()
    {
        Console.WriteLine("instancemethodBaseClass()\n");
    }
}      

class DerivedClass : BaseClass // *Note: derived class should NOT be thought of Main()'s class
{
    static void Main() 
    {
        DerivedClass dc = new DerivedClass();  // #Note: via a qualifier of type base class [especially for instance member]
                                                  
        DerivedClass.staticmethodBaseClass();  // Note: BaseClass, if staticmethodBaseClass() in DerivedClass, then DerivedClass 

        staticmethodBaseClass();               // Note: BaseClass, if staticmethodBaseClass() in DerivedClass, then DerivedClass  

        BaseClass.staticmethodBaseClass();     // Note: BaseClass      
                                                
        dc.instancemethodBaseClass();          // #Note: BaseClass, if instancemethodBaseClass() in DerivedClass, then DerivedClass    
    }
}
      
 