// event in interface  // private and explicit implementation by class  // using built-in delegate EventHandler 

// $Note: private and explicit interface implementation of an event must use property syntax

// *Note: MyInterface mi = (MyInterface)es;


using System;

// built-in delegate EventHandler

interface MyInterface
{
    event EventHandler MyEvent;
}

class EventClass : MyInterface
{
    EventHandler ev; // $Note

    event EventHandler MyInterface.MyEvent // $Note: private and explicit 
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
        if(ev != null)
            ev(this, EventArgs.Empty); // Note
    }
}

class MainClass
{
    static void MainClassEventHandler(object ob, EventArgs args) // Note
    {
        Console.WriteLine("Event occurred"); // Note
        Console.WriteLine("Source: " +  ob); // Note
    }

    static void Main()
    {
        EventClass ec = new EventClass();

        MyInterface mi = (MyInterface)ec;    // *Note

        mi.MyEvent += MainClassEventHandler; // *Note
        
        ec.Onev();
    }
}
        
     
     
