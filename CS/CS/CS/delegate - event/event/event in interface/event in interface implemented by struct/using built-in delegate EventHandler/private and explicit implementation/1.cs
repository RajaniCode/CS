// event in interface, private and explicit implementation by struct // using built-in delegate EventHandler 

// $Note: private and explicit interface implementation of an event must use property syntax

// *Note: MyInterface mi = (MyInterface)es;

// #Note: es = (EventStruct)mi; 


using System;

// using built-in delegate EventHandler

interface MyInterface
{
    event EventHandler MyEvent;
}

struct EventStruct : MyInterface
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

struct MainStruct
{
    static void MainStructEventHandler(object ob, EventArgs args) // Note
    {
        Console.WriteLine("Event occurred"); // Note
        Console.WriteLine("Source: " +  ob); // Note
    }

    static void Main()
    {
        EventStruct es = new EventStruct();

        MyInterface mi = (MyInterface)es; // *Note
        
        EventHandler eh = MainStructEventHandler; // built-in delegate EventHandler

        mi.MyEvent += eh; // built-in delegate EventHandler // *Note

        es = (EventStruct)mi; // #Note
        
        es.Onev();            // #Note
    }
}