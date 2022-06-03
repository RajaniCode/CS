// static variable can be used in instance method and assigned value from OUTSIDE the method USING CLASS in Main() in the same or different class

// instance variable can be used in instance method and assigned value from OUTSIDE the method USING INSTANCE in Main() in the same or different class


using System;

class MyClass
{
    public static int s; // static variable   // public
    public int i;        // instance variable // public
    
    public void myMethod()   // instance method
    {
        Console.WriteLine("s = {0} and i = {1}", s, i);
    }    

} //

class MainClass //
{ //

    static void Main()
    {
        MyClass mc = new MyClass();
        
        MyClass.s = 3;
        mc.i = 4;
        
        mc.myMethod();       
    }    
}