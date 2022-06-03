// event multicast in interface, public implementation by struct 


using System;

delegate void MyDelegate();

interface MyInterface
{    
    event MyDelegate MyEvent; 
}

struct EventStruct : MyInterface
{
    public event MyDelegate MyEvent;

    public void OnMyEvent()
    {
        if(MyEvent != null)
            MyEvent();
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

struct MainStruct
{
    static void MainStructEventHandler()
    {
        Console.WriteLine("Event received by MainClass");    
    }

    static void Main()
    {
        EventStruct es = new EventStruct();
        X xo = new X(); 
        Y yo = new Y(); 
          
        MyDelegate md1 = MainStructEventHandler;
        es.MyEvent += md1;

        MyDelegate md2 = xo.XEventHandler; // Note
        es.MyEvent += md2; // Note

        MyDelegate md3 = yo.YEventHandler; 
        es.MyEvent +=  md3; 
        
        es.OnMyEvent();
        Console.WriteLine();
        
        es.MyEvent -= md2; // Note

        es.OnMyEvent(); 
        Console.WriteLine();

        es.MyEvent -= md3; 

        es.OnMyEvent();
        Console.WriteLine("Next");   

        es.MyEvent -= md1; 

        es.OnMyEvent();
        Console.WriteLine("End");               
    }
}
 
         
        






        