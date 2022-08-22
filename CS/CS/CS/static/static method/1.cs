//static variable can be used in static method and assigned value from OUTSIDE the method USING CONSTRUCTOR CALL in Main() in the same or different class

// instance variable can be used in static method ONLY by USING REFERENCE PASSED IN PARAMETER that allows OBJECT PASSED IN ARGUMENT from Main()
// and assigned value from OUTSIDE the method USING CONSTRUCTOR CALL in Main() in the same or different class


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
       
    public static void myMethod(MyClass mcp)   // static method
    {   
        Console.WriteLine("s = {0} and i = {1}", s, mcp.i); // Note: mc.i // USING INSTANCE
    }  
} //

class MainClass //
{ //
    static void Main()
    {
        MyClass mc = new MyClass(1, 2);
        
        MyClass.myMethod(mc);        
    }    
}
