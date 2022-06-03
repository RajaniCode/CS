// Properties in interface, public implementation by struct

// using access modifiers with accessors // #Note: accessor must be more restrictive(less accessible) than the property or indexer


using System;

interface MyInterface
{
    int property
    {
        get;   // #Note only get as set is private         
    }    
}

struct MyStruct : MyInterface
{
    int n;  // cannot have instance field initializers in structs

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


    //  Structs cannot contain explicit parameterless constructors


    public void incrementMethod()
    {
        property++; // Note
    }
}

struct MainStruct
{
    static void Main()
    {
        MyStruct ms = new MyStruct();

        Console.WriteLine("Value of property after parameterless constructor call: {0} \n", ms.property);
                     
        // ms.property = 100; // NOT POSSIBLE because set is private

        ms.incrementMethod(); // Note

        Console.WriteLine("The value of property after calling incrementMethod(), value of property: {0} \n", ms.property);             
    }
}