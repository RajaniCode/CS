// event in interface, private and explicit implementation by struct // using static method as event EventHandler in struct

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


class X
{

// *Note:
// In case static variable is used either in instance method or static method, 
// and assigned value from OUTSIDE the method USING CONSTRUCTOR CALL in Main() in the same or different class
// UNLIKE THE CASE OF INSTANCE VARIABLE, the STATIC VARIABLE should be called/used immediately after assigned using CONSTRUCTOR CALL, 
// otherwise if called or used after subsequent assignment using CONSTRUCTOR CALL(S)
// ONLY THE LAST ASSIGNMENT VALUE will be its value 
    
// [ALSO IN CASE OF assignments USING CLASS, the STATIC VARIABLE should be called/used immediately after assigned using CLASS, 
// otherwise if called or used after subsequent assignment using CLASS(ES)
// ONLY THE LAST ASSIGNMENT VALUE will be its value 

// [BUT NOT IN CASE OF assignments USING METHOD CALLS in Main() in the same or different class]


    /*     
    static int number; 

    public X(int n) 
    { 
        number = n;
    }
    */

    public static void XEventHandler() // Static Method
    {
        // Console.WriteLine("The event received by X objest " + number);

        Console.WriteLine("The event received by X object");
    }
}



class MainStruct
{
    static void Main()
    {
        EventStruct es = new EventStruct();

        MyInterface mi = (MyInterface)es;  // *Note

        // X xo = new X(1);
        
        MyDelegate md = X.XEventHandler;
        mi.MyEvent += md; // *Note
        
        
        es = (EventStruct)mi; // #Note
        es.Onev();       // #Note
    }
}

    