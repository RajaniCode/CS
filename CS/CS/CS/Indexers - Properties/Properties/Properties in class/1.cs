// Property in class // instance property can access BOTH instance and static variable


using System;

class MyClass
{
    int n = 1;  // default // Note: Check with parameterized constructor call without assigning it

    public int property    // Note: property is not a keyword
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

        Console.WriteLine("Value of property after parameterless constructor call: {0} \n", mc.property);
                     
        mc.property = 100;
          
        Console.WriteLine("After assigning 100, value of property: {0} \n", mc.property);
        
        mc.property = -22;
           
        Console.WriteLine("After assigning -22, value of property: {0} \n", mc.property);        
    }
}