// enum // named constants can only be alphanumeric (should start with alphabet), should be unique and should not be in quotation

// static method


using System;

class MyClass
{
    public enum Action {start, forward, reverse, stop}; // Note: public

    public static void conveyorMethod(Action a)
    {
        switch(a)
        {
            case Action.start:   
                Console.WriteLine("Starting");
                break;
              
            case Action.forward:   
                Console.WriteLine("Forwarding");
                break; 
                 
            case Action.reverse:   
                Console.WriteLine("Reversing");
                break;
              
            case Action.stop:   
                Console.WriteLine("Stopping");
                break;
        }
    }
}

class MainClass
{ 
    static void Main()
    {
        MyClass.conveyorMethod(MyClass.Action.start);    // Note: MyClass
        MyClass.conveyorMethod(MyClass.Action.forward);  // Note: MyClass
        MyClass.conveyorMethod(MyClass.Action.reverse);  // Note: MyClass
        MyClass.conveyorMethod(MyClass.Action.stop);     // Note: MyClass

    }
}
 