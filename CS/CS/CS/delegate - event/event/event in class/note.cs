// static event in static class


using System;

delegate void MyDelegate();

static class EventClass
{
    public static event MyDelegate MyEvent; // Note

    public static void OnMyEvent()
    {
        if(MyEvent != null)
            MyEvent();
    }
} // 

static class MainClass //
{ //
    static void MainClassEventHandler()
    {
        Console.WriteLine("Event occurred");
    }
 
    static void Main()
    {
       EventClass.MyEvent += MainClassEventHandler; // Note

       EventClass.OnMyEvent(); 
    }
} 
 