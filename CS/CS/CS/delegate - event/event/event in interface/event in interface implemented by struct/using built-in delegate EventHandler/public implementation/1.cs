// event using in interface, public implementation by struct // using built-in delegate EventHandler 


using System;

// using built-in delegate EventHandler

interface MyInterface
{
    event EventHandler MyEvent;
}

struct EventStruct : MyInterface
{
    public event EventHandler MyEvent;

    public void OnMyEvent()
    {
        if(MyEvent != null)
            MyEvent(this, EventArgs.Empty); // Note
    }
}

struct MainStruct
{
    static void MainStructEventHandler(object ob, EventArgs args) // Note
    {
        Console.WriteLine("Event occurred"); // Note
        Console.WriteLine("Source: " +  ob); // Note
    }

    static void Main()
    {
        EventStruct es = new EventStruct();

        EventHandler eh = MainStructEventHandler; // built-in delegate EventHandler

        es.MyEvent += eh; // built-in delegate EventHandler
        
        es.OnMyEvent();
    }
}
        
     
     
