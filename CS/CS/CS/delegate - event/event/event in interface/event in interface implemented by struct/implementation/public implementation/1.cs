// event in interface, public implementation by struct 


using System;

delegate void MyDelegate();

interface MyInterface
{    
    event MyDelegate MyEvent; // Note: event in interface
}

struct EventStruct : MyInterface // Note
{
    public event MyDelegate MyEvent; 

    public void OnMyEvent() // Note: implicit implementation
    {
        if(MyEvent != null)
            MyEvent();
    }
}

struct MainStruct
{
    static void MainStructEventHandler()
    {
        Console.WriteLine("Event occurred");
    }

    static void Main()
    {
        EventStruct ec = new EventStruct();        
       
        MyDelegate md = MainStructEventHandler;
        ec.MyEvent += md;
    
        ec.OnMyEvent();
    }
}
    