// Assignment precedence

using System;

class MyClass
{
    public static int s; // static variable
    public int i;        // instance variable
       
    public MyClass(int a, int b)
    {
        s = a;
        i = b;
    }   
    public static void myMethod(MyClass mcp, int c, int d)   // static method
    {   s = c;
        mcp.i = d;
        Console.WriteLine("s = {0} and i = {1}", s, mcp.i); // Note: mcp.i // USING INSTANCE
    }  
} //

class MainClass //
{ //
    static void Main()
    {     
        MyClass mc = new MyClass(1, 2); 
        MyClass.myMethod(mc, 5, 6); // Arguments reign supreme
        MyClass.s = 3;        
        mc.i = 4; // For instance variable, the last passed value takes precedence WITH REGARD TO 'mc' in MyClass.myMethod(mc); [USING CONSTRUCTOR CALL vs USING INSTANCE]
        MyClass mc1 = new MyClass(7, 8); // For static variable, just the last passed value takes precedence REGARDLESS of 'mc' in MyClass.myMethod(mc); [USING CONSTRUCTOR CALL vs USING CLASS]
        mc1.i = 9;                  
    }    
}
