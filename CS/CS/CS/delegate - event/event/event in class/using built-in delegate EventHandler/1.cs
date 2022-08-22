// event using built-in delegate EventHandler


using System;

// built-in delegate EventHandler

class EventClass
{
    public event EventHandler MyEvent;

    public void OnMyEvent()
    {
        if(MyEvent != null)
            MyEvent(this, EventArgs.Empty); // Note
    }
}

class MainClass
{
    static void MainClassEventHandler(object ob, EventArgs args) // Note
    {
        Console.WriteLine("Event occurred"); // Note
        Console.WriteLine("Source: " +  ob); // Note
    }

    static void Main()
    {
        EventClass ec = new EventClass();

        ec.MyEvent += MainClassEventHandler;
        
        ec.OnMyEvent();
    }
}
        
     
     
