// event in interface // public implementation by class // using event accessors


using System;

delegate void MyDelegate();

interface MyInterface
{
    event MyDelegate MyEvent;
}

class EventClass : MyInterface
{
    MyDelegate[] ev = new MyDelegate[3]; // Note

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

class W
{
    public void WEventHandler()
    {
        Console.WriteLine("Event received by W object");
    }
}

class X
{
    public void XEventHandler()
    {
        Console.WriteLine("Event received by X object");
    }
}

class Y
{
    public void YEventHandler()
    {
        Console.WriteLine("Event received by Y object");
    }
}
        
class Z
{
    public void ZEventHandler()
    {
        Console.WriteLine("Event received by Z object");
    }
}

class MainClass
{
    static void Main()
    {
        EventClass ec = new EventClass();

        W w = new W();
        X x = new X();
        Y y = new Y();
        Z z = new Z();
     
        ec.MyEvent += w.WEventHandler; // Note: MyEvent
        ec.MyEvent += x.XEventHandler; // Note: MyEvent
        ec.MyEvent += y.YEventHandler; // Note: MyEvent
        ec.MyEvent += z.ZEventHandler; // Note: MyEvent // cannot store, event list full
        ec.OnMyEvent();
 
        Console.WriteLine("\nremove XEventHandler");
        ec.MyEvent -= x.XEventHandler; 
        ec.OnMyEvent();

        Console.WriteLine("\nremove again XEventHandler");
        ec.MyEvent -= x.XEventHandler; 
        ec.OnMyEvent();

        Console.WriteLine("\nadd ZEventHandler");
        ec.MyEvent += z.ZEventHandler; // Note: MyEvent
        ec.OnMyEvent();
     }
}
       