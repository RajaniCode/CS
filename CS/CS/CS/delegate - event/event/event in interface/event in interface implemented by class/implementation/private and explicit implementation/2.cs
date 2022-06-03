// event multicast in interface // private and explicit implementation by class 

// $Note: private and explicit interface implementation of an event must use property syntax

// *Note: MyInterface mi = (MyInterface)es;


using System;

delegate void MyDelegate();

interface MyInterface
{    
    event MyDelegate MyEvent;
}

class EventClass : MyInterface 
{
    MyDelegate ev; // $Note

    event MyDelegate MyInterface.MyEvent // $Note: private and explicit 
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
        if(ev != null) // Note
            ev();      // Note
    }
}

class X
{
    public void XEventHandler()
    {
        Console.WriteLine("Event received by X object");
    }
}

class Y
{
    public void YEventHandler()
    {
        Console.WriteLine("Event received by Y object");
    }
}

class MainClass
{
    static void MainClassEventHandler()
    {
        Console.WriteLine("Event received by MainClass");    
    }

    static void Main()
    {
        EventClass ec = new EventClass();

        MyInterface mi = (MyInterface)ec; // *Note
 
        X xo = new X(); // Note
        Y yo = new Y(); // Note
          
        
        mi.MyEvent += MainClassEventHandler; // *Note
        mi.MyEvent += xo.XEventHandler;      // *Note
        mi.MyEvent += yo.YEventHandler;      // *Note
        
        ec.Onev();        
        Console.WriteLine();
        
        mi.MyEvent -= xo.XEventHandler;      // *Note
        
        ec.Onev(); // Note
        Console.WriteLine();

        mi.MyEvent -= yo.YEventHandler;      // *Note
        
        ec.Onev(); // Note  
        Console.WriteLine("Next");
 
        mi.MyEvent -= MainClassEventHandler; // *Note
        
        ec.Onev(); // Note   
        Console.WriteLine("End");       
    }
}
 
         
        






        