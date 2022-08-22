// event in interface // private and explicit implementation by class // instance event in static method

// $Note: private and explicit interface implementation of an event must use property syntax

// *Note: MyInterface mi = (MyInterface)es;


using System;

delegate void MyDelegate(); 

interface MyInterface
{    
    event MyDelegate MyEvent; 
}

class EventClass : MyInterface 
{
    MyDelegate ev; // $Note

    event MyDelegate MyInterface.MyEvent // $Note: private and explicit 
    {
        add
        {
            ev += value;
        }
        
        remove
        {
            ev -= value;
        }
    }         

    public static void Onev(EventClass ecp) // Note: static
    {
        if(ecp.ev != null) // Note
            ecp.ev(); // Note
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
       
        MyInterface mi = (MyInterface)ec;    // *Note

        mi.MyEvent += MainClassEventHandler; // *Note  
   
        EventClass.Onev(ec); // Note
    }
}

        
    
   
    