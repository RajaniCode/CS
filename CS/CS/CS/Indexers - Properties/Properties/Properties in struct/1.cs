// Property in struct // instance property can access BOTH instance and static variable


using System;

struct MyStruct
{
    int n;  // cannot have instance field initializers in structs

    public int property    
    {                                                 
        get                    
        {                    
            return n;                    
        }                    
                            
        set                    
        {                    
            if(value>=0)   
                n = value;
        }
    }

    //  Structs cannot contain explicit parameterless constructors
}

struct MainStruct
{
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