// ONLY instance events [including accessor based] can be [virtual in class/abstract class] & can be 'sealed' when overridden

// Note: what happens when virtual event is not overridden


using System;

delegate void MyDelegate(); 

abstract class BaseClass 
{
    public virtual event MyDelegate MyEvent;

    public void OnMyEvent() // Note: Default implementation
    {
        if(MyEvent != null)
            MyEvent();
    }
    
}

class DerivedClass : BaseClass 
{
   // virtual event is not overridden
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
      
        bcr.MyEvent += MainClassEventHandler;              // event: BaseClass: 1 [since virtual event is not overridden]
        bcr.OnMyEvent();                                   // method: BaseClass // Prints 1 time  

        Console.WriteLine("# 2");
        dc.MyEvent += MainClassEventHandler;               // event: BaseClass: 2 [since virtual event is not overridden]
        dc.OnMyEvent();                                    // method: BaseClass // Prints 2 times  
         
        Console.WriteLine("# 3");    
        ((BaseClass)dc).MyEvent += MainClassEventHandler;  // event: BaseClass: 3 [since virtual event is not overridden]
        ((BaseClass)dc).OnMyEvent();                       // method: BaseClass // Prints 3 times  

        Console.WriteLine("# 4");

        // dc.MyEvent += MainClassEventHandler;               
        // dc.Onev(); // NOT POSSIBLE because DerivedClass doesn't have Onev()                                         
    }
} 
 