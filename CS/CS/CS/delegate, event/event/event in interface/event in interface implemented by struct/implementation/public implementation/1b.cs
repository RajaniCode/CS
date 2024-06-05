// event in interface, public implementation by struct // event handler as instance


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
 