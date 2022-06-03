// Assignment precedence

using System;

class MyClass
{
    public static int s; // static variable   // public
    public int i;        // instance variable // public
    
    public MyClass(int a, int b) 
    {
        s = a;
        i = b;
    }
        
    
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
        MyClass mc = new MyClass(1, 2);
        mc.myMethod(5, 6); // Arguments reign supreme
        MyClass.s = 3;
        mc.i = 4; // For instance variable, the last passed value takes precedence WITH REGARD TO 'mc' in mc.Method(); [USING CONSTRUCTOR CALL vs USING INSTANCE]
        MyClass mc1 = new MyClass(7, 8); // For static variable, just the last passed value takes precedence REGARDLESS of 'mc' in mc.Method(); [USING CONSTRUCTOR CALL vs USING CLASS]
        mc1.i = 9;                
    }    
}