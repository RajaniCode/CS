// event in interface, private and explicit implementation by struct 

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

struct MainStruct
{
    static void MainStructEventHandler()
    {
        Console.WriteLine("Event occurred");
    }

    static void Main()
    {
        EventStruct es = new EventStruct();
        
        MyInterface mi = (MyInterface)es; // *Note
        
        MyDelegate md = MainStructEventHandler;

        mi.MyEvent += md;      // *Note
       
        es = (EventStruct)mi;  // #Note
    
        es.Onev();             // #Note            
    }
}
    