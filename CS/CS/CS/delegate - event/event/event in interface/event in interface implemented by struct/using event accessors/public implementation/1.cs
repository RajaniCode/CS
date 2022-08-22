// event in interface, public implementation by struct // using event accessors


using System;

delegate void MyDelegate();

interface MyInterface
{
    event MyDelegate MyEvent;
}

struct EventStruct : MyInterface
{
    MyDelegate[] ev; // Note: cannot have instance field initializers in structs 
    
    public EventStruct(int size) // Or: static MyDelegate[] ev = new MyDelegate[3];
    {
        ev = new MyDelegate[size];
    } 
      
    public event MyDelegate MyEvent // Note
    {
        add // add event to the list
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

        remove // add event to the list
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

struct Mainstruct
{
    static void Main()
    {
        EventStruct es = new EventStruct(3); //

        W w = new W();
        X x = new X();
        Y y = new Y();
        Z z = new Z();
     
        MyDelegate md1 = w.WEventHandler;
        es.MyEvent += md1; 
        
        MyDelegate md2 = x.XEventHandler;
        es.MyEvent += md2;
        
        MyDelegate md3 = y.YEventHandler; 
        es.MyEvent += md3;
        
        MyDelegate md4 = z.ZEventHandler; 
        es.MyEvent += md4; // cannot store, event list full
        
        es.OnMyEvent();
 
        Console.WriteLine("\nremove XEventHandler");
        es.MyEvent -= md2;
        es.OnMyEvent();

        Console.WriteLine("\nremove again XEventHandler");
        es.MyEvent -= md2;
        es.OnMyEvent();

        Console.WriteLine("\nadd ZEventHandler");
        es.MyEvent += md4; // Note: MyEvent
        es.OnMyEvent();
     }
}
       