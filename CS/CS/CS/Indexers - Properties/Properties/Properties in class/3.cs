// Property in class

// #Note: get operation should be nonintrusive although not enforced by the compiler


using System;

class MyClass
{
    public int n = 1; 

    public int property  
    {
        get
        {
            return n; // #Note: wrong: n * 2
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

        Console.WriteLine("Initial value of n: {0} \n", mc.n);
        Console.WriteLine("Initial value of property: {0} \n", mc.property);
        
        mc.n = -10; 
        mc.property = 5;
        Console.WriteLine("After assigning n = -10 and property = 5, value of n: {0} \n", mc.n);   
        Console.WriteLine("After assigning n = -10 and property = 5, value of property: {0} \n", mc.property);
         
        mc.n = -20; 
        mc.property = -25;
        Console.WriteLine("After assigning n = -20 and property = -1, value of n: {0} \n",mc.n);    
        Console.WriteLine("After assigning n = -20 and property = -1, value of property: {0} \n", mc.property);

        mc.n = -30; 
        mc.property = 50;
        Console.WriteLine("After assigning n = -30 and property = 50, value of n: {0} \n",mc.n);    
        Console.WriteLine("After assigning n = -30 and property = 50, value of property: {0} \n", mc.property);                

        mc.n = 80; 
        mc.property = -70;
        Console.WriteLine("After assigning n = 80 and property = -70, value of n: {0} \n",mc.n);    
        Console.WriteLine("After assigning n = 80 and property = -70, value of property: {0} \n", mc.property);  

        mc.property = 2;
        Console.WriteLine("After assigning property = 2, value of n: {0} \n",mc.n);    
        Console.WriteLine("After assigning property = 2, value of property: {0} \n", mc.property);                
                 
        mc.n = 1; 
        Console.WriteLine("After assigning n = 1, value of n: {0} \n",mc.n);    
        Console.WriteLine("After assigning n = 1, value of property: {0} \n", mc.property);  

        mc.n = 3; 
        mc.property = 4;
        Console.WriteLine("After assigning n = 3 and property = 4, value of n: {0} \n",mc.n);    
        Console.WriteLine("After assigning n = 3 and property = 4, value of property: {0} \n", mc.property);        
    } 
}
   
    
    


 
         







    