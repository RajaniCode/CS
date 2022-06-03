// event in class // event handler as instance


using System;

delegate void MyDelegate();

class EventClass
{
    public event MyDelegate MyEvent; 

    public void OnMyEvent()
    {
        if(MyEvent != null)
            MyEvent();
    }
}

class MainClass
{
    void MainClassEventHandler() // Note
    {
        Console.WriteLine("Event occurred");
    }
 
    static void Main()
    {
        EventClass ec = new EventClass();

        MainClass mc = new MainClass();  // Note

        ec.MyEvent += mc.MainClassEventHandler; // Note

        ec.OnMyEvent(); 
    }
} 
 