// instance property in interface, public implementation by class

// using access modifiers with accessors // #Note: accessor must be more restrictive(less accessible) than the property or indexer


using System;

interface MyInterface
{
    int property
    {
        get;   // #Note only get as set is private         
    }    
}

class MyClass : MyInterface
{
    int n = 1;  

    public int property    
    {                                                 
        get                    
        {                    
            return n;                    
        }                    
                            
        private set       // #Note                    
        {                    
            if(value>=0)   
                n = value;
        }
    }

    public MyClass()
    { 
        n = 7;
    }

    public void incrementMethod()
    {
        property++; // Note
    }
}

class MainClass
{
    static void Main()
    {
        MyClass mc = new MyClass();

        Console.WriteLine("Value of property after parameterless constructor call: {0} \n", mc.property);
                     
        // mc.property = 100; // NOT POSSIBLE because set is private

        mc.incrementMethod(); // Note

        Console.WriteLine("The value of property after calling incrementMethod(), value of property: {0} \n", mc.property);             
    }
}