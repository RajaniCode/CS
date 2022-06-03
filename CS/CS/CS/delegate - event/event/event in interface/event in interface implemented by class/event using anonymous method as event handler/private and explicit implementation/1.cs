// event in interface // public implementation by class

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

    public void Onev()
    {
        if(ev != null)
            ev();
    }
}

class MainClass
{
    static void Main()
    {
        EventClass ec = new EventClass();
    
        MyInterface mi = (MyInterface)ec; // *Note

        mi.MyEvent += delegate // Note:  event handler (anonymous method) // *Note
        {
            Console.WriteLine("Event occurred");
        }; // Note
        
        ec.Onev();
        ec.Onev(); // Note
    }
}


       

    