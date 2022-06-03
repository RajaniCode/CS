// static event in class


using System;

delegate void MyDelegate();

class EventClass
{
    public static event MyDelegate MyEvent; // Note

    public void OnMyEvent()
    {
        if(MyEvent != null)
            MyEvent();
    }
}

class MainClass
{
    static void MainClassEventHandler()
    {
        Console.WriteLine("Event occurred");
    }
 
    static void Main()
    {
        EventClass ec = new EventClass();

        EventClass.MyEvent += MainClassEventHandler; // Note

        ec.OnMyEvent(); 
    }
} 
 