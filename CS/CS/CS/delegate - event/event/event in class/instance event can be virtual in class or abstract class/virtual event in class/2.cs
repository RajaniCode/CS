// ONLY instance events[including accessor based] can be [virtual in class/abstract class] & can be 'sealed' when overridden

// accessor based 


using System;

delegate void MyDelegate(); 

class BaseClass 
{
    MyDelegate[] ev = new MyDelegate[1]; // Note: Check with 0

    public virtual event MyDelegate MyEvent // Note
    {
        add
        {
            int i;

            for(i=0; i<ev.Length; i++)      
                if(ev[i] == null)  // Note
                {
                    ev[i] = value; // Note
                    break;
                }
            if(i==ev.Length)
                Console.WriteLine("event list is full");
        }

        remove
        {
            int i;

            for(i=0; i<ev.Length; i++)
                if(ev[i] == value) // Note
                {
                    ev[i] = null;  // Note
                    break;
                }
            if(i==ev.Length)
                Console.WriteLine("event handler not found");
        }
     }

    public void OnMyEvent()
    {
        int i;

        for(i=0; i<ev.Length; i++)
            if(ev[i] != null)
                ev[i]();
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
        dc.Onev();                                         // method: DerivedClass // Prints 4 times // *event: BaseClass can't help print 
    }
}