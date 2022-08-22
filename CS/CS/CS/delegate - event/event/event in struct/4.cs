// event in struct // using static method as event EventHandler in struct


using System;

delegate void MyDelegate();

class EventStruct
{
    public event MyDelegate MyEvent;

    public void OnMyEvent()
    {
        if(MyEvent != null)
            MyEvent();
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

        // X xo = new X(1);
        
        MyDelegate md = X.XEventHandler;
        es.MyEvent += md;
        
        es.OnMyEvent();
    }
}

    