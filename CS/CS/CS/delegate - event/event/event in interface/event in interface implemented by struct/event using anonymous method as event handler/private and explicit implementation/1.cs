// event in interface, private and explicit implementation by struct // using anonymous method as event handler

// $Note: private and explicit interface implementation of an event must use property syntax

// *Note: MyInterface mi = (MyInterface)es;

// #Note: es = (EventStruct)mi; 


using System;

delegate void MyDelegate();

interface MyInterface
{
    event MyDelegate MyEvent;
}

struct EventStruct : MyInterface 
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

    public void OnMyEvent()
    {
        if(ev != null)
            ev();
    }
}

struct MainClass
{
    static void Main()
    {
        EventStruct  es = new EventStruct();
    
        MyInterface mi = (MyInterface)es; // *Note

        mi.MyEvent += delegate // Note:  event handler (anonymous method) // *Note
        {
            Console.WriteLine("Event occurred");
        }; // Note
        
        es = (EventStruct)mi;  // #Note
                               
        es.OnMyEvent();        // #Note
        es.OnMyEvent();        // #Note
    }
}


       

    