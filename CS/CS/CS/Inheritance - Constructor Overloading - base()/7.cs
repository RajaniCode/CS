// Inheritance - Constructor Overloading // CANNOT Call PROTECTED INSTANCE FROM DERIVED via a qualifier of type 'BaseClass' 


using System;
 
class BaseClass
{
    protected static int StaticNumber = 1;
    protected int InstanceNumber = 2;

    protected static void StaticMethod()
    {
        Console.WriteLine("Static Hola!");     
    }

    protected void InstanceMethod()
    {
        Console.WriteLine("Instance Hola!");     
    }
   
}

class DerivedClass : BaseClass
{ 
    internal static void StaticHola()
    {
       
        StaticMethod();                               // YES: Without any Qualifier [BECAUSE Calling STATIC from STATIC]       
        Console.WriteLine(StaticNumber);              // YES: Without any Qualifier [BECAUSE Calling STATIC from STATIC]  

        BaseClass.StaticMethod();                     // ALSO: Using BaseClass
        Console.WriteLine(BaseClass.StaticNumber);    // ALSO: Using BaseClass   

        DerivedClass.StaticMethod();                  // ALSO: Using DerivedClass
        Console.WriteLine(DerivedClass.StaticNumber); // ALSO: Using DerivedClass 
       
        
        // InstanceMethod();                          // BUT NOT: Without any Qualifier [BECAUSE Calling INSTANCE from STATIC]  
        // Console.WriteLine(InstanceNumber);         // BUT NOT: Without any Qualifier [BECAUSE Calling INSTANCE from STATIC]  


        BaseClass bc = new BaseClass();
        // bc.InstanceMethod();                       // BUT NOT: via a qualifier of type 'BaseClass' [BECAUSE Calling PROTECTED INSTANCE FROM DERIVED]         
        // Console.WriteLine(bc.InstanceNumber);      // BUT NOT: via a qualifier of type 'BaseClass' [BECAUSE Calling PROTECTED INSTANCE FROM DERIVED]  

        DerivedClass dc = new DerivedClass();
        dc.InstanceMethod();                          // ALSO: via a qualifier of type 'DerivedClass'          
        Console.WriteLine(dc.InstanceNumber);         // ALSO: via a qualifier of type 'DerivedClass' 
    }

    internal void InstanceHola()
    {           
        StaticMethod();                               // YES: Without any Qualifier [BECAUSE Calling STATIC from INSTANCE]        
        Console.WriteLine(StaticNumber);              // YES: Without any Qualifier [BECAUSE Calling STATIC from INSTANCE]   

        BaseClass.StaticMethod();                     // ALSO: Using BaseClass
        Console.WriteLine(BaseClass.StaticNumber);    // ALSO: Using BaseClass   

        DerivedClass.StaticMethod();                  // ALSO: Using DerivedClass
        Console.WriteLine(DerivedClass.StaticNumber); // ALSO: Using DerivedClass 
       
        
        InstanceMethod();                             // YES: Without any Qualifier [BECAUSE Calling INSTANCE from INSTANCE] 
        Console.WriteLine(InstanceNumber);            // YES: Without any Qualifier [BECAUSE Calling INSTANCE from INSTANCE] 

        BaseClass bc = new BaseClass();
        // bc.InstanceMethod();                       // BUT NOT: via a qualifier of type 'BaseClass' [BECAUSE Calling PROTECTED INSTANCE FROM DERIVED]      
        // Console.WriteLine(bc.InstanceNumber);      // BUT NOT: via a qualifier of type 'BaseClass' [BECAUSE Calling PROTECTED INSTANCE FROM DERIVED]

        DerivedClass dc = new DerivedClass();
        dc.InstanceMethod();                          // ALSO: via a qualifier of type 'DerivedClass'          
        Console.WriteLine(dc.InstanceNumber);         // ALSO: via a qualifier of type 'DerivedClass' 
   
    }
}

class MainClass
{
    static void Main()
    {
      
        DerivedClass.StaticHola();

        DerivedClass dc = new DerivedClass();
 
        dc.InstanceHola();

    }  

         
}