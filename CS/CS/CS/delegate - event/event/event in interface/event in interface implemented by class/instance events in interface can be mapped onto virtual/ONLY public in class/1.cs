// [although not virtual in interface, instance events [including accessor based] in interface can be mapped onto virtual 
// in the implementing (only public implementation is possible) class/abstract class]


using System;

delegate void MyDelegate();

interface MyInterface
{
    event MyDelegate MyEvent;
}

class BaseClass : MyInterface 
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
        BaseClass bc = new BaseClass();

        bc.MyEvent += MainClassEventHandler;               // *event: BaseClass: 1            
        bc.OnMyEvent();                                    // method: BaseClass // Prints 1 time

        Console.WriteLine("# 2");
        BaseClass bcr;
        DerivedClass dc = new DerivedClass();                          
        bcr = dc;    
                                  
        bcr.MyEvent += MainClassEventHandler;              // event: DerivedClass: 1               
        bcr.OnMyEvent();                                   // method: BaseClass // Doesn't print because event: DerivedClass and even *event: BaseClass can't help print           

        Console.WriteLine("# 3");
        dc.MyEvent += MainClassEventHandler;               // event: DerivedClass: 2  
        dc.OnMyEvent();                                    // method: BaseClass // Doesn't print because event: DerivedClass and even *event: BaseClass can't help print               
            
        Console.WriteLine("# 4");
        ((BaseClass)dc).MyEvent += MainClassEventHandler;  // event: DerivedClass: 3 
        ((BaseClass)dc).OnMyEvent();                       // method: BaseClass // Doesn't print because event: DerivedClass and even *event: BaseClass can't help print               
            
        Console.WriteLine("# 5");
        dc.MyEvent += MainClassEventHandler;               // event: DerivedClass: 4 
        dc.Onev();                                         // method: BaseClass // Prints 4 times // *event: BaseClass can't help print
    }
}