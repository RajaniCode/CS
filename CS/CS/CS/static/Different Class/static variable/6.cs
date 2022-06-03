// static variable in static method // USING METHOD CALL(S)

// instance variable in static method // USING METHOD CALL(S)


using System;

class MyClass
{
    static int s; // static variable 
    public int i; // instance variable     

    public static int myMethod(MyClass mcp, int a, int b) // static method
    {
        s = a;
        mcp.i = b;
        return s * mcp.i; // Note 
    }    
} // 

class MainClass //
{  //
    static void Main() 
    {
        MyClass mc1 = new MyClass();
        MyClass mc2 = new MyClass();

        Console.WriteLine("The result = {0}", MyClass.myMethod(mc1, 3, 5));   // *Note
        Console.WriteLine("The result = {0}", MyClass.myMethod(mc2, 100, 6)); // *Note
    }
}


// *Note:
// In case static variable is used either in instance method or static method, 
// and assigned value from OUTSIDE the method USING CONSTRUCTOR CALL in Main() in the same or different class
// UNLIKE THE CASE OF INSTANCE VARIABLE, the CONSTRUCTOR CALL should be USED ONCE, 
// otherwise ONLY THE LAST ASSIGNED VALUE will be the value FOR ALL CONSTRUCTOR CALL USAGE
    
// [ALSO IN CASE OF assignments USING CLASS, the CLASS should be USED ONCE in Main() in the same or different class
//  otherwise ONLY THE LAST ASSIGNED VALUE will be the value FOR ALL CLASS USAGE] 
// [BUT NOT IN CASE OF assignments USING METHOD CALLS in Main() in the same or different class]
