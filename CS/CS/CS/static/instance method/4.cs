// static variable can be used in instance method and assigned value INSIDE THE METHOD DIRECTLY

// instance variable can be used in instance method and assigned value INSIDE THE METHOD DIRECTLY


using System;

class MyClass
{
    public static int s; // static variable
    public int i;        // instance variable
    
    public void myMethod()   // instance method 
    {
        s = 7;
        i = 8;           
        Console.WriteLine("s = {0} and i = {1}", s, i);
    }    
}

class MainClass
{
    static void Main()
    {
        MyClass mc = new MyClass();        
        
        mc.myMethod();    
    }    
}