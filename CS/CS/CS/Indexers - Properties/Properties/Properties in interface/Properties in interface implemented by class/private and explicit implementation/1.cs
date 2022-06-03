// instance property in interface, private and explicit implementation by class

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

class MyClass : MyInterface
{
    int n = 1;  // default // Note: Check with parameterized constructor call without assigning it

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

    public MyClass()
    { 
        n = 7;
    }
}

class MainClass
{
    static void Main()
    {
        MyClass mc = new MyClass();
    
        MyInterface mi = (MyInterface)mc;

        Console.WriteLine("Value of property after parameterless constructor call: {0} \n", mi.property);
                     
        mi.property = 100;
          
        Console.WriteLine("After assigning 100, value of property: {0} \n", mi.property);
        
        mi.property = -22;
           
        Console.WriteLine("After assigning -22, value of property: {0} \n", mi.property);        
    }
}