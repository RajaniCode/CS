// static variable can be used in instance method and assigned value from OUTSIDE the method USING CONSTRUCTOR CALL in Main() in the same or different class

// instance variable can be used in instance method and assigned value from OUTSIDE the method USING CONSTRUCTOR CALL in Main() in the same or different class


using System;

class MyClass
{
    static int s; // static variable
    int i;        // instance variable
    
    public MyClass(int a, int b)
    {
        s = a;
        i = b;
    }
        
    
    public void myMethod()   // instance method
    {
        Console.WriteLine("s = {0} and i = {1}", s, i);
    }    
} //

class MainClass //
{ // 
    static void Main()
    {
        MyClass mc = new MyClass(1, 2);
        
        mc.myMethod();        
    }    
}