// event in interface, public implementation by struct // using instance method as event EventHandler in struct


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

class X
{
     
    int number; // static int number    

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

    public X(int n) 
    {
        number = n;
    }    

    public void XEventHandler() // Instance Method
    {
        Console.WriteLine("The event received by X object {0}", number); 
    }
}


class MainStruct
{
    static void Main()
    {
        EventStruct es = new EventStruct();
            
        X xo1 = new X(1);
        X xo2 = new X(2);
        X xo3 = new X(3);
        
        MyDelegate md1 = xo1.XEventHandler;
        es.MyEvent += md1;
         
        MyDelegate md2 = xo2.XEventHandler; 
        es.MyEvent += md2;
  
        MyDelegate md3 = xo3.XEventHandler; 
        es.MyEvent += md3;
        
        es.OnMyEvent();
    }
}

    