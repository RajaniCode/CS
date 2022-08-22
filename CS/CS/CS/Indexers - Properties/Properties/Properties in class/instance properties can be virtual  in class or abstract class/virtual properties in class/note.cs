// ONLY instance properties [can only be accessor based] can be [virtual in class/abstract class] & can be 'sealed' when overridden

// #Note: calling base class instance property in a derived class instance method using 'base', and then calling the instance method from Main()
// [Only assignment, call, increment, decrement, and new object expressions can be used as a statement]


using System;

class BaseClass
{
    public int n; 

    public virtual int property   
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

    public BaseClass()
    { 
        n = 7;
    }
}

class DerivedClass : BaseClass
{
    sealed public override int property  // can be 'sealed' when override
    {
        get
        {
            return n;
        }
        
        set
        {
            n = value; // Note: different implementation 
        }
    }
}

class FurtherDerivedClass: DerivedClass
{
    public void methodFurtherDerivedClass()
    {     
        Console.WriteLine("base.property in methodFurtherDerivedClass(): {0}", base.property); // #Note  
    }
}

class MainClass
{
    static void Main()
    {
        Console.WriteLine("# 1");
        BaseClass bc = new BaseClass();

        Console.WriteLine("Value of property after parameterless BaseClass constructor call: {0} \n",bc.property);
                     
        bc.property = 100;
          
        Console.WriteLine("After assigning 100 using bc, value of property: {0} \n", bc.property);
        
        bc.property = -22;
           
        Console.WriteLine("After assigning -22 using bc, value of property: {0} \n", bc.property);
   
        Console.WriteLine("# 2");
        BaseClass bcr;
        DerivedClass dc = new DerivedClass();
        bcr = dc;

        Console.WriteLine("Value of property after parameterless DerivedClass constructor call: {0} \n", bcr.property);
                     
        bcr.property = 100;
          
        Console.WriteLine("After assigning 100 using bcr, value of property: {0} \n", bcr.property);
        
        bcr.property = -22;
           
        Console.WriteLine("After assigning -22 using bcr, value of property: {0} \n", bcr.property); 


        Console.WriteLine("# 3");
        Console.WriteLine("Value of property using dc: {0} \n", dc.property);
                     
        dc.property = 100;
          
        Console.WriteLine("After assigning 100 using dc, value of property: {0} \n", dc.property);
        
        dc.property = -22;
           
        Console.WriteLine("After assigning -22 using dc, value of property: {0} \n", dc.property); 


        Console.WriteLine("# 4");
        Console.WriteLine("Value of property using ((BaseClass)dc): {0} \n", ((BaseClass)dc).property);
                     
        ((BaseClass)dc).property = 100;
          
        Console.WriteLine("After assigning 100 using ((BaseClass)dc), value of property: {0} \n", ((BaseClass)dc).property);
        
        ((BaseClass)dc).property = -22;
           
        Console.WriteLine("After assigning -22 using ((BaseClass)dc), value of property: {0} \n", ((BaseClass)dc).property);  

        Console.WriteLine("# 5");
        FurtherDerivedClass fdc = new FurtherDerivedClass();
        fdc.methodFurtherDerivedClass(); // #Note        
    }
}