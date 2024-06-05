// [although not vitual in interface, instance properties [can only be accessor based] in interface can be mapped onto virtual 
// in the implementing (only public implementation is possible) class/abstract class]


using System;

interface MyInterface
{
    int property
    {
        get;
        set;
    }
}

class BaseClass : MyInterface
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
    }
}