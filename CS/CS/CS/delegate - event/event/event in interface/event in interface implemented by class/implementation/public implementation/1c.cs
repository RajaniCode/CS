// event in interface // public implementation by class // instance event in static method


using System;

delegate void MyDelegate(); 

interface MyInterface
{    
    event MyDelegate MyEvent; 
}

class EventClass : MyInterface 
{
    public event MyDelegate MyEvent; 

    public static void OnMyEvent(EventClass ecp) // Note: static
    {
        if(ecp.MyEvent != null) // Note
            ecp.MyEvent(); // Note
    }
}

class MainClass 
{
    static void MainClassEventHandler() 
    {
        Console.WriteLine("Event Occurred");
    }
 
    static void Main() 
    {
        EventClass ec = new EventClass(); 
       
        ec.MyEvent += MainClassEventHandler; 
   
        EventClass.OnMyEvent(ec); // Note
    }
}

        
    
   
    