// [although not abstract in interface, instance events [except accessor based] in interface can be mapped onto abstract 
// in the implementing (MUST & only public implementation is possible) abstract class]


using System;

delegate void MyDelegate(); 

interface MyInterface
{
    event MyDelegate MyEvent;
}    

abstract class BaseClass : MyInterface
{
    public abstract event MyDelegate MyEvent;

    // Note: No default implementation    
}

class DerivedClass : BaseClass 
{
    MyDelegate ev;

    sealed public override event MyDelegate MyEvent // Note: Can be 'sealed' because it is an override
    {
        add
        {
            ev += value;
        }
        
        remove
        {
            ev -= value;
        }
    }

    public void Onev() 
    {
        if(ev != null)
            ev();
    }
}


class MainClass
{
    static void MainClassEventHandler() 
    {
        Console.WriteLine("Event occurred");
    }
 
    static void Main() 
    {
        Console.WriteLine("# 1");
        BaseClass bcr;
        DerivedClass dc = new DerivedClass();                          
        bcr = dc;                    
        
        bcr.MyEvent += MainClassEventHandler;               // event: DerivedClass: 1
        // bcr.Onev();                                      // method: NOT POSSIBLE because it is in DerivedClass                   
        
        Console.WriteLine("# 2");
        dc.MyEvent += MainClassEventHandler;                // event: DerivedClass: 2        
        dc.Onev();                                          // method: DerivedClass // Prints 2 times

        Console.WriteLine("# 3");
        ((BaseClass)dc).MyEvent += MainClassEventHandler;   // event: DerivedClass
        // ((BaseClass)dc).Onev();                          // method: NOT POSSIBLE because it is in DerivedClass 
    }
}