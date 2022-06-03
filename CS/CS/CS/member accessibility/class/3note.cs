// class memebr accessibility

// protected 

// #Note: via a qualifier of type base class [especially for instance member]

// *Note: derived class should NOT be thought of Main()'s class

// $Note: via qualifier of further derived in further derived

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
    protected static void DerivedClassMain() 
    {
        DerivedClass dc = new DerivedClass();               // #Note: via a qualifier of type base class [especially for instance member]
                                                  
        DerivedClass.staticmethodBaseClass();               // Note 1

        staticmethodBaseClass();                            // Note 2 

        BaseClass.staticmethodBaseClass();                  // Note 3        
                                                
        dc.instancemethodBaseClass();                       // #Note     
    }
}
      

class DerivedClassLevel2 : DerivedClass // Note: fruther derived
{
    static void Main() 
    {
        DerivedClassLevel2 dcl2 = new DerivedClassLevel2();  // $Note: via qualifier of further derived in further derived
                                                  
        DerivedClassLevel2.staticmethodBaseClass();  // Note 2
        
        staticmethodBaseClass();                     // Note 1   

        DerivedClass.staticmethodBaseClass();        // Note 3      
        
        BaseClass.staticmethodBaseClass();           // Note 4       
                                                                                         
        dcl2.instancemethodBaseClass();              // #Note   

        
        Console.WriteLine("NOTE 1");

        DerivedClassLevel2.DerivedClassMain();  

        Console.WriteLine("NOTE 2");

        DerivedClassMain();

        Console.WriteLine("NOTE 3");

        DerivedClass.DerivedClassMain();
    }
} 