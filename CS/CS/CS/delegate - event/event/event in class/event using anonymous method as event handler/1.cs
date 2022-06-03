// event in class // using anonymous method as event handler


using System;

delegate void MyDelegate();

class EventClass
{
    public event MyDelegate MyEvent;

    public void OnMyEvent()
    {
        if(MyEvent != null)
            MyEvent();
    }
}

class MainClass
{
    static void Main()
    {
        EventClass ec = new EventClass();
    
        ec.MyEvent += delegate // Note:  event handler (anonymous method)
        {
            Console.WriteLine("Event occurred");
        }; // Note
        
        ec.OnMyEvent();
        ec.OnMyEvent(); // Note
    }
}


       

    