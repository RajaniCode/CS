// static event in struct


using System;

delegate void MyDelegate();

struct EventStruct
{
    public static event MyDelegate MyEvent; // Note

    public void OnMyEvent()
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
        EventStruct es = new EventStruct();

        MyDelegate md = MainStructEventHandler; 

        EventStruct.MyEvent += md;

        es.OnMyEvent(); 
    }
} 
 