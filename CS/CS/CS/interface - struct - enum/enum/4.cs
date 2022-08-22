// enum // named constants can only be alphanumeric (should start with alphabet), should be unique and should not be in quotation

// instance method


using System;

class MyClass
{
    public enum Action {start, forward, reverse, stop}; // Note: public

    public void conveyorMethod(Action a)
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
        MyClass mc1 = new MyClass();
        MyClass mc2 = new MyClass();
        MyClass mc3 = new MyClass();
        MyClass mc4 = new MyClass();

        mc1.conveyorMethod(MyClass.Action.start);    // Note: MyClass
        mc2.conveyorMethod(MyClass.Action.forward);  // Note: MyClass
        mc3.conveyorMethod(MyClass.Action.reverse);  // Note: MyClass
        mc4.conveyorMethod(MyClass.Action.stop);     // Note: MyClass

    }
}
 