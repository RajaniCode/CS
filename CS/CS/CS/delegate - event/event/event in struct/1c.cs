// event in struct // instance event in static method


using System;

delegate void MyDelegate(); 

struct EventStruct 
{
    public event MyDelegate MyEvent; 

    public static void OnMyEvent(EventStruct esp) // Note: static
    {
        if(esp.MyEvent != null) // Note
            esp.MyEvent(); // Note
    }
}

struct MainStruct
{
    static void MainStructEventHandler() 
    {
        Console.WriteLine("Event Occurred");
    }
 
    static void Main() 
    {
        EventStruct es = new EventStruct(); 
       
        MyDelegate md = MainStructEventHandler; 

        es.MyEvent += md;
   
        EventStruct.OnMyEvent(es); // Note
    }
}

        
    
   
    