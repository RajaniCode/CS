// Properties in interface, public implementation by struct 

// instance property can access BOTH instance and static variable

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
                            
        private set                    
        {                    
            if(value>=0)      // #Note
                n = value;
        }
    }

    //  Structs cannot contain explicit parameterless constructors

// }               // Note
                   
// struct MainStruct // Note
// {               // Note 
    static void Main()
    {
        MyStruct ms = new MyStruct();

        Console.WriteLine("Value of property after parameterless constructor call: {0} \n", ms.property);
                     
        ms.property = 100;
          
        Console.WriteLine("After assigning 100, value of property: {0} \n", ms.property);
        
        ms.property = -22;
           
        Console.WriteLine("After assigning -22, value of property: {0} \n", ms.property);        
    }
}