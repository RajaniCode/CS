// new(hiding) vs abstract vs virtual and override


using System;

abstract class BaseClass 
{
    public abstract string abstractMethod(); 

    public virtual string virtualMethod()     
    {
        return "virtualMethod() in abstract BaseClass"; 
    }    
}

class DerivedClass : BaseClass
{
    sealed public override string abstractMethod() // Can be sealed
    {
        return "abstractMethod() in DerivedClass"; 
    }     
}

class MainClass : DerivedClass 
{  

    // internal new int abstractMethod()
    // {
       //  return 12345; 
    // }  

    
    internal new string abstractMethod()
    {
        return base.abstractMethod(); // base. refers 'override' and not 'abstract'
    }       

    static void Main()
    { 
         MainClass mc = new MainClass();
         Console.WriteLine(mc.abstractMethod());       
    }
}




/*


using System;

abstract class BaseClass 
{
    // public abstract string abstractMethod(); 

    public virtual string virtualMethod()     
    {
        return "virtualMethod() in abstract BaseClass"; 
    }    
}

class DerivedClass : BaseClass
{
    sealed public override string virtualMethod() // Can be sealed
    {
        return "virtualMethod() in DerivedClass"; 
    }     
}

class MainClass : DerivedClass 
{  
  
    // internal new int virtualMethod()
    // {
       //  return 12345; 
    // }  
         
    internal new string virtualMethod()
    {
        return base.virtualMethod();
    }    

    static void Main()
    { 
         MainClass mc = new MainClass();
         Console.WriteLine(mc.virtualMethod());       
    }
}


*/











