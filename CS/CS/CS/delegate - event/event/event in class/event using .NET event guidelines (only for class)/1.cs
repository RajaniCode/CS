// event in class // using .NET event guidelines (only for class)

// #Note


using System;

class MyEventArgs : EventArgs // #Note
{
    public int eventnumber;   // #Note
}

delegate void MyDelegate(object ob, MyEventArgs args); // #Note

class EventClass
{
    static int count = 0; // #Note

    public event MyDelegate MyEvent;

    public void OnMyEvent()
    {
        MyEventArgs myargs = new MyEventArgs(); // #Note

        if(MyEvent != null)
        {
            myargs.eventnumber = count++;  // #Note
            MyEvent(this, myargs);         // #Note
            
        }
    }
}

class X
{
    public void XEventHandler(object ob, MyEventArgs args) // #Note
    {
        Console.WriteLine("\nEvent #" + args.eventnumber + " received by X object");
        Console.WriteLine("Source: " + ob);
    }
}
           
class Y
{
    public void YEventHandler(object ob, MyEventArgs args) // #Note
    {
        Console.WriteLine("\nEvent #" + args.eventnumber + " received by Y object");
        Console.WriteLine("Source: " + ob);
    }
}    
    
class MainClass
{
    static void Main()
    {
        EventClass ec = new EventClass();

        X x = new X();

        Y y = new Y();

        ec.MyEvent += x.XEventHandler; // #Note
        ec.MyEvent += y.YEventHandler; // #Note
 
        ec.OnMyEvent(); // #Note
        ec.OnMyEvent(); // #Note
    }
}