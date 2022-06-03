// event in interface // private and explicit implementation by class

// $Note: private and explicit interface implementation of an event must use property syntax

// *Note: MyInterface mi = (MyInterface)es;


using System;

delegate void MyDelegate();

interface MyInterface
{
    event MyDelegate MyEvent; // Note: event in interface
}

class EventClass : MyInterface // Note
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

    public void Onev()
    {
        if(ev != null) // Note
            ev();      // Note
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
        
        MyInterface mi = (MyInterface)ec;    // *Note
        
        mi.MyEvent += MainClassEventHandler; // *Note
    
        ec.Onev();
    }
}
    