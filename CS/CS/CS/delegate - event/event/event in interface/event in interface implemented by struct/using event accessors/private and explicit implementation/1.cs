// event in interface, private and explicit implementation by struct // using event accessors

// $Note: private and explicit interface implementation of an event must use property syntax

// *Note: MyInterface mi = (MyInterface)es;


using System;

delegate void MyDelegate();

interface MyInterface
{
    event MyDelegate MyEvent;
}

struct EventStruct : MyInterface
{
    MyDelegate[] ev; // Note: cannot have instance field initializers in structs   // $Note
    
    public EventStruct(int size) // Or: static MyDelegate[] ev = new MyDelegate[3];
    {
        ev = new MyDelegate[size];
    } 
      
    event MyDelegate MyInterface.MyEvent // $Note: private and explicit
    {
        add
        {
            int i;

            for(i=0; i<3; i++)      // Also: i<ev.Length
                if(ev[i] == null)  // Note
                {
                    ev[i] = value; // Note
                    break;
                }
            if(i==3)
                Console.WriteLine("event list is full");
        }

        remove
        {
            int i;

            for(i=0; i<3; i++)
                if(ev[i] == value) // Note
                {
                    ev[i] = null;  // Note
                    break;
                }
            if(i==3)
                Console.WriteLine("event handler not found");
        }
     }

    public void OnMyEvent()
    {
        int i;

        for(i=0; i<3; i++)
            if(ev[i] != null)
                ev[i]();
    }
}

struct W
{
    public void WEventHandler()
    {
        Console.WriteLine("Event received by W object");
    }
}

struct X
{
    public void XEventHandler()
    {
        Console.WriteLine("Event received by X object");
    }
}

struct Y
{
    public void YEventHandler()
    {
        Console.WriteLine("Event received by Y object");
    }
}
        
struct Z
{
    public void ZEventHandler()
    {
        Console.WriteLine("Event received by Z object");
    }
}

struct MainStruct
{
    static void Main()
    {
        EventStruct es = new EventStruct(3); //

        W w = new W();
        X x = new X();
        Y y = new Y();
        Z z = new Z();
       
        MyInterface mi = (MyInterface)es; // *Note
     
        MyDelegate md1 = w.WEventHandler;
        mi.MyEvent += md1; // *Note
        
        MyDelegate md2 = x.XEventHandler;
        mi.MyEvent += md2; // *Note
        
        MyDelegate md3 = y.YEventHandler; 
        mi.MyEvent += md3; // *Note
        
        MyDelegate md4 = z.ZEventHandler; 
        mi.MyEvent += md4; // *Note // cannot store, event list full
        
        es.OnMyEvent();
 
        Console.WriteLine("\nremove XEventHandler");
        mi.MyEvent -= md2; // *Note
        es.OnMyEvent();

        Console.WriteLine("\nremove again XEventHandler");
        mi.MyEvent -= md2; // *Note
        es.OnMyEvent();

        Console.WriteLine("\nadd ZEventHandler");
        mi.MyEvent += md4; // *Note
        es.OnMyEvent();
     }
}
       