// instance property in interface, private and explicit implementation by class

// #Note: get operation should be nonintrusive although not enforced by the compiler


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
    public int n = 1; 

    int MyInterface.property  
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

        Console.WriteLine("Initial value of n: {0} \n", mc.n);
        Console.WriteLine("Initial value of property: {0} \n", mi.property);
        
        mc.n = -10; 
        mi.property = 5;
        Console.WriteLine("After assigning n = -10 and property = 5, value of n: {0} \n", mc.n);   
        Console.WriteLine("After assigning n = -10 and property = 5, value of property: {0} \n", mi.property);
         
        mc.n = -20; 
        mi.property = -25;
        Console.WriteLine("After assigning n = -20 and property = -1, value of n: {0} \n",mc.n);    
        Console.WriteLine("After assigning n = -20 and property = -1, value of property: {0} \n", mi.property);

        mc.n = -30; 
        mi.property = 50;
        Console.WriteLine("After assigning n = -30 and property = 50, value of n: {0} \n",mc.n);    
        Console.WriteLine("After assigning n = -30 and property = 50, value of property: {0} \n", mi.property);                

        mc.n = 80; 
        mi.property = -70;
        Console.WriteLine("After assigning n = 80 and property = -70, value of n: {0} \n",mc.n);    
        Console.WriteLine("After assigning n = 80 and property = -70, value of property: {0} \n", mi.property);  

        mi.property = 2;
        Console.WriteLine("After assigning property = 2, value of n: {0} \n",mc.n);    
        Console.WriteLine("After assigning property = 2, value of property: {0} \n", mi.property);                
                 
        mc.n = 1; 
        Console.WriteLine("After assigning n = 1, value of n: {0} \n",mc.n);    
        Console.WriteLine("After assigning n = 1, value of property: {0} \n", mi.property);  

        mc.n = 3; 
        mi.property = 4;
        Console.WriteLine("After assigning n = 3 and property = 4, value of n: {0} \n",mc.n);    
        Console.WriteLine("After assigning n = 3 and property = 4, value of property: {0} \n", mi.property);        
    } 
}
   
    
    


 
         







    