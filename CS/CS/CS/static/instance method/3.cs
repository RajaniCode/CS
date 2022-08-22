// static variable can be used in instance method and assigned value from OUTSIDE the method USING METHOD CALL in Main() in the same or different class

// instance variable can be used in instance method and assigned value from OUTSIDE the method USING METHOD CALL in Main() in the same or different class


using System;

class MyClass
{
    public static int s; // static variable
    public int i;        // instance variable
    
    public void myMethod(int c, int d)   // instance method
    {
        s = c;
        i = d;           
        Console.WriteLine("s = {0} and i = {1}", s, i);
    }    
} //

class MainClass //
{ //
    static void Main()
    {   
        MyClass mc = new MyClass();
        
        mc.myMethod(5, 6);         
    }    
}