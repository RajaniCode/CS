// event in interface, public implementation by struct // using anonymous method as event handler


using System;

delegate void MyDelegate();

interface MyInterface
{
    event MyDelegate MyEvent;
}

struct EventStruct : MyInterface
{
    public event MyDelegate MyEvent;

    public void OnMyEvent()
    {
        if(MyEvent != null)
            MyEvent();
    }
}

struct MainStruct 
{
    static void Main()
    {
        EventStruct  es = new EventStruct();
    
        es.MyEvent += delegate // Note:  event handler (anonymous method)
        {
            Console.WriteLine("Event occurred");
        }; // Note
        
        es.OnMyEvent();
        es.OnMyEvent(); // Note
    }
}


       

    