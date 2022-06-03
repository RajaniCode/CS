// event in struct // instance


using System;

delegate void MyDelegate(); // 1. delegate

struct EventStruct // 2. event class
{
    public event MyDelegate MyEvent; // 3. event using delegate without parenthesis // Note 

    public void OnMyEvent() // 4. Method called to fire the event
    {
        if(MyEvent != null)
            MyEvent();
    }
}

struct MainStruct // 5. Main()
{
    static void MainStructEventHandler() // 6. event handler
    {
        Console.WriteLine("Event occurred");
    }
 
    static void Main() // 7. Main()
    {
        EventStruct es = new EventStruct(); // 8. event class' objest

        MyDelegate md = MainStructEventHandler; // 9. event handler (without parenthesis) assigned to delegate instance // Note 

        es.MyEvent += md; // 10.assigned delegate instance added to event list // Note

        es.OnMyEvent(); // 11. method call to fire the event // Note 
    }
} 
 