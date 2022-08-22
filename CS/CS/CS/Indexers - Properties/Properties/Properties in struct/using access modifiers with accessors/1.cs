// Property in struct

// using access modifiers with accessors // #Note: accessor must be more restrictive(less accessible) than the property or indexer


using System;

struct MyStruct
{
    int n;  

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

        Console.WriteLine("Value of property after parameterless conclassor call: {0} \n", ms.property);
                     
        // ms.property = 100; // NOT POSSIBLE because set is private

        ms.incrementMethod(); // Note

        Console.WriteLine("The value of property after calling incrementMethod(), value of property: {0} \n", ms.property);             
    }
}