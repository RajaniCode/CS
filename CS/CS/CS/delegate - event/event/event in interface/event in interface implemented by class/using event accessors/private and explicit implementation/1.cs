// event in interface // private and explicit implementation by class // using event accessors

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
    MyDelegate[] ev = new MyDelegate[3]; // Note // $Note

    event MyDelegate MyInterface.MyEvent // *Note: private and explicit // $Note
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

    public void Onev()
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
     
        MyInterface mi = (MyInterface)ec; // *Note

        mi.MyEvent += w.WEventHandler; // Note: MyEvent // *Note
        mi.MyEvent += x.XEventHandler; // Note: MyEvent // *Note
        mi.MyEvent += y.YEventHandler; // Note: MyEvent // *Note
        mi.MyEvent += z.ZEventHandler; // Note: MyEvent // *Note // cannot store, event list full
        ec.Onev();
 
        Console.WriteLine("\nremove XEventHandler");
        mi.MyEvent -= x.XEventHandler; // *Note 
        ec.Onev();

        Console.WriteLine("\nremove again XEventHandler");
        mi.MyEvent -= x.XEventHandler; // *Note
        ec.Onev();

        Console.WriteLine("\nadd ZEventHandler");
        mi.MyEvent += z.ZEventHandler; // *Note 
        ec.Onev();
     }
}
       