// event in struct // event handler as instance


using System;

delegate void MyDelegate();

struct EventStruct
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
    void MainStructEventHandler() // Note
    {
        Console.WriteLine("Event occurred");
    }
 
    static void Main()
    {
        EventStruct es = new EventStruct();

        MainStruct ms = new MainStruct();  // Note

        MyDelegate md = ms.MainStructEventHandler; // Note

        es.MyEvent += md;

        es.OnMyEvent(); 
    }
} 
 