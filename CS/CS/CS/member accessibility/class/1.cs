// class memebr accessibility

// public

using System;

public class BaseClass
{
    public static void staticmethodBaseClass()
    {
        Console.WriteLine("staticmethodBaseClass()\n");
    }
 
    public void instancemethodBaseClass()
    {
        Console.WriteLine("instancemethodBaseClass()\n");
    }      
}

public class DerivedClass : BaseClass
{
    public static void staticmethodDerivedClass()
    {
        staticmethodBaseClass();
        BaseClass bc = new BaseClass();        
        bc.instancemethodBaseClass();
    }

    public void instancemethodDerivedClass()
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