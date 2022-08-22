// class memebr accessibility

// protected internal 

using System;

public class BaseClass
{
    protected internal static void staticmethodBaseClass()
    {
        Console.WriteLine("staticmethodBaseClass()\n");
    }
 
    protected internal void instancemethodBaseClass()
    {
        Console.WriteLine("instancemethodBaseClass()\n");
    }      
}

public class DerivedClass : BaseClass
{
    protected internal static void staticmethodDerivedClass()
    {
        staticmethodBaseClass();
        BaseClass bc = new BaseClass();        
        bc.instancemethodBaseClass();
    }

    protected internal void instancemethodDerivedClass()
    {
        staticmethodBaseClass();
        instancemethodBaseClass();
    }      
}

class MainClass
{
    static void Main()
    {
        BaseClass bc = new BaseClass();
    
        BaseClass.staticmethodBaseClass();          

        bc.instancemethodBaseClass();

        DerivedClass dc = new DerivedClass();
   
        DerivedClass.staticmethodDerivedClass();

        dc.instancemethodDerivedClass();
    }
}