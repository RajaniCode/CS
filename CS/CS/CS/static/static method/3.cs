//static variable can be used in static method and assigned value from OUTSIDE the method USING CLASS in Main() in the same or different class

// instance variable can be used in static method ONLY by USING REFERENCE PASSED IN PARAMETER that allows OBJECT PASSED IN ARGUMENT from Main()
// and assigned value from OUTSIDE the method USING METHOD CALL in Main() in the same or different class


using System;

class MyClass
{
    public static int s; // static variable
    public int i;        // instance variable
     
    public static void myMethod(MyClass mcp, int c, int d)   // static method
    {   
        s = c;
        mcp.i = d;
        Console.WriteLine("s = {0} and i = {1}", s, mcp.i); // Note: mcp.i // USING INSTANCE
    }  
} //

class MainClass //
{ //
    static void Main()
    {
        MyClass mc = new MyClass();
        
        MyClass.myMethod(mc, 5, 6);       
    }    
}
