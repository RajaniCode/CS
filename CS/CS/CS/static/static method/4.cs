// static variable can be used in static method and assigned value INSIDE THE METHOD DIRECTLY

// instance variable can be used in static method ONLY by USING REFERENCE PASSED IN PARAMETER that allows OBJECT PASSED IN ARGUMENT from Main()
// and assigned value INSIDE THE METHOD DIRECTLY


using System;

class MyClass
{
    static int s; // static variable
    int i;        // instance variable
    
       
    public static void myMethod(MyClass mcp)   // instance method
    {   s = 7;
        mcp.i = 8;       
        Console.WriteLine("s = {0} and i = {1}", s, mcp.i); // Note: mcp.i // USING INSTANCE
    }  
} //

class MainClass //
{ //
    static void Main()
    {   
        MyClass mc = new MyClass();             
        
        MyClass.myMethod(mc);        
    }    
}




