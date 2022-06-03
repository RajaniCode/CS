// instance property in interface, public implementation by class 

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

class MyClass : MyInterface
{
    int n = 1;  

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

    public MyClass()
    { 
        n = 7;
    }
// }               // Note
                   
// class MainClass // Note
// {               // Note 
    static void Main()
    {
        MyClass mc = new MyClass();

        Console.WriteLine("Value of property after parameterless constructor call: {0} \n", mc.property);
                     
        mc.property = 100;
          
        Console.WriteLine("After assigning 100, value of property: {0} \n", mc.property);
        
        mc.property = -22;
           
        Console.WriteLine("After assigning -22, value of property: {0} \n", mc.property);        
    }
}