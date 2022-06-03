// event in interface // public implementation by class


using System;

delegate void MyDelegate();

interface MyInterface
{    
    event MyDelegate MyEvent; // Note: event in interface
}

class EventClass : MyInterface // Note
{
    public event MyDelegate MyEvent; 

    public void OnMyEvent() // Note: implicit implementation
    {
        if(MyEvent != null)
            MyEvent();
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
        EventClass ec = new EventClass();        
       
        ec.MyEvent += MainClassEventHandler;
    
        ec.OnMyEvent();
    }
}