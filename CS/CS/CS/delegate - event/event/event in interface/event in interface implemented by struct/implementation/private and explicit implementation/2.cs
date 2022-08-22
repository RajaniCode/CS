// event multicast in interface, private and explicit implementation by struct 

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

    public void Onev()
    {
        if(ev != null) 
            ev();     
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

        MyInterface mi = (MyInterface)es; // *Note

        X xo = new X(); 
        Y yo = new Y(); 
          
        MyDelegate md1 = MainStructEventHandler;
        mi.MyEvent += md1; // *Note

        MyDelegate md2 = xo.XEventHandler; 
        mi.MyEvent += md2;  // *Note

        MyDelegate md3 = yo.YEventHandler; 
        mi.MyEvent +=  md3; // *Note
        
        es = (EventStruct)mi; // #Note
        es.Onev();            // #Note
        Console.WriteLine();
        
        mi.MyEvent -= md2; // *Note

        es = (EventStruct)mi; // #Note
        es.Onev();            // #Note
        Console.WriteLine();

        mi.MyEvent -= md3; // *Note
 
        es = (EventStruct)mi; // #Note
        es.Onev();            // #Note
        Console.WriteLine("Next");   

        mi.MyEvent -= md1; // *Note

        es = (EventStruct)mi; // #Note
        es.Onev();            // #Note
        Console.WriteLine("End");               
    }
} 
         
        






        