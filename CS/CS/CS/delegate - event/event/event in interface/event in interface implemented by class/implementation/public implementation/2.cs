// event multicast in interface // public implementation by class 


using System;

delegate void MyDelegate();

interface MyInterface
{    
    event MyDelegate MyEvent;
}

class EventClass : MyInterface 
{
    public event MyDelegate MyEvent;

    public void OnMyEvent()
    {
        if(MyEvent != null)
            MyEvent();
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
        X xo = new X(); // Note
        Y yo = new Y(); // Note
          
        
        ec.MyEvent += MainClassEventHandler;
        ec.MyEvent += xo.XEventHandler; // Note
        ec.MyEvent += yo.YEventHandler; // Note
        
        ec.OnMyEvent();        
        Console.WriteLine();
        
        ec.MyEvent -= xo.XEventHandler; // Note
        
        ec.OnMyEvent(); // Note
        Console.WriteLine();

        ec.MyEvent -= yo.YEventHandler; // Note
        
        ec.OnMyEvent(); // Note  
        Console.WriteLine("Next");
 
        ec.MyEvent -= MainClassEventHandler; // Note
        
        ec.OnMyEvent(); // Note   
        Console.WriteLine("End");       
    }
}
 
         
        






        