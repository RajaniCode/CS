// Properties in interface, private and explicit implementation by struct

// instance property can access BOTH instance and static variable


using System;

interface MyInterface
{
    int property
    {
        get;
        set;
    }    
}

struct MyStruct : MyInterface
{
    int n; // cannot have instance field initializers in structs

    int MyInterface.property    // Note: property is not a keyword
    {                                                 
        get                    
        {                    
            return n;                    
        }                    
                            
        set                    
        {                    
            if(value>=0)   // Note: value is a keyword
                n = value;
        }
    }

    //  Structs cannot contain explicit parameterless constructors
}

struct MainStruct
{
    static void Main()
    {
        MyStruct mc = new MyStruct();
    
        MyInterface mi = (MyInterface)mc;

        Console.WriteLine("Value of property after parameterless constructor call: {0} \n", mi.property);
                     
        mi.property = 100;
          
        Console.WriteLine("After assigning 100, value of property: {0} \n", mi.property);
        
        mi.property = -22;
           
        Console.WriteLine("After assigning -22, value of property: {0} \n", mi.property);        
    }
}