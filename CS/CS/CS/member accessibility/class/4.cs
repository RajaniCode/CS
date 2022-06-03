// class memebr accessibility

// internal

using System;

public class BaseClass
{
    internal static void staticmethodBaseClass()
    {
        Console.WriteLine("staticmethodBaseClass()\n");
    }
 
    internal void instancemethodBaseClass()
    {
        Console.WriteLine("instancemethodBaseClass()\n");
    }      
}

public class DerivedClass : BaseClass
{
    internal static void staticmethodDerivedClass()
    {
        staticmethodBaseClass();
        BaseClass bc = new BaseClass();        
        bc.instancemethodBaseClass();
    }

    internal void instancemethodDerivedClass()
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