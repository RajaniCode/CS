// Generic delegate // using .NET evet guidelines


using System;

class MyEventArgs : EventArgs
{
    public int eventnumber;
}

delegate void MyDelegate<T1, T2>(T1 t1, T2 t2);

class EventClass
{
    static int count = 0;
    
    public event MyDelegate<EventClass, MyEventArgs> MyEvent;

    public void OnMyEvent()
    {
        MyEventArgs myargs = new MyEventArgs();
        
        if(MyEvent != null)
        {
            myargs.eventnumber = count++;
            MyEvent(this, myargs);
        }
    }
}

class X
{
    public void XEventHandler<T1, T2>(T1 t1, T2 t2) where T2: MyEventArgs
    {
        Console.WriteLine("\nEvent #" + t2.eventnumber + " received by X object");
        Console.WriteLine("Source: " + t1);
    }
}

class Y
{
    public void YEventHandler<T1, T2>(T1 t1, T2 t2) where T2: MyEventArgs
    {
        Console.WriteLine("\nEvent #" + t2.eventnumber + " received by Y object");
        Console.WriteLine("Source: " + t1);
    }
}

class MainClass
{
    static void Main()
    {
        EventClass ec = new EventClass();
        
        X x = new X();
        Y y = new Y();
    
        ec.MyEvent += x.XEventHandler;
        ec.MyEvent += y.YEventHandler;

        ec.OnMyEvent();
        ec.OnMyEvent();
    }
}
         
       

