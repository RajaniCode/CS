// event in interface // private and explicit implementation by class // using instance method as event EventHandler

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
        if(ev != null) // Note
            ev();      // Note
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


class MainClass
{
    static void Main()
    {
        EventClass ec = new EventClass();

        MyInterface mi = (MyInterface)ec; // *Note   

        X xo1 = new X(1);
        X xo2 = new X(2);
        X xo3 = new X(3);
        
        mi.MyEvent += xo1.XEventHandler; // *Note
        mi.MyEvent += xo2.XEventHandler; // *Note   
        mi.MyEvent += xo3.XEventHandler; // *Note
        
        ec.Onev();
    }
}

    