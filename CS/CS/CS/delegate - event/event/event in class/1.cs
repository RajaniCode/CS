// event in class // instance


using System;

delegate void MyDelegate(); // 1. delegate

class EventClass // 2. event class
{
    public event MyDelegate MyEvent; // 3. event using delegate without parenthesis // Note 

    public void OnMyEvent() // 4. Method called to fire the event
    {
        if(MyEvent != null)
            MyEvent();
    }
}

class MainClass// 5. Main()
{
    static void MainClassEventHandler() // 6. event handler
    {
        Console.WriteLine("Event occurred");
    }
 
    static void Main() // 7. Main()
    {
        EventClass ec = new EventClass(); // 8. event class' object

        ec.MyEvent += MainClassEventHandler; // 9. event handler (without parenthesis) added to event list // Note 

        ec.OnMyEvent(); // 10. method call to fire the event // Note 
    }
} 
 