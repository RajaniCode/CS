// static variable in instance method // USING CLASS(ES)

// instance variable in instance method // USING CLASS(ES)



using System;

class MyClass
{
    public static int s; // static variable        // Note: public
    public int i;        // instance variable      // Note: public

    
    public int myMethod() // instance method
    {
        return s * i; 
    }
} // 

class MainClass //
{  //
    static void Main() 
    {
        MyClass.s = 3;   // *Note
        MyClass.s = 100; // *Note
    
        MyClass mc1 = new MyClass();
        MyClass mc2 = new MyClass();

        mc1.i = 5;
        mc2.i = 6;

        Console.WriteLine("The result of mc1 = {0}", mc1.myMethod());
        Console.WriteLine("The result of mc2 = {0}", mc2.myMethod());  
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
