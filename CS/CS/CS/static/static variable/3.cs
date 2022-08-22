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
// UNLIKE THE CASE OF INSTANCE VARIABLE, the STATIC VARIABLE should be called/used immediately after assigned using CONSTRUCTOR CALL, 
// otherwise if called or used after subsequent assignment using CONSTRUCTOR CALL(S)
// ONLY THE LAST ASSIGNMENT VALUE will be its value 
    
// [ALSO IN CASE OF assignments USING CLASS, the STATIC VARIABLE should be called/used immediately after assigned using CLASS, 
// otherwise if called or used after subsequent assignment using CLASS(ES)
// ONLY THE LAST ASSIGNMENT VALUE will be its value 

// [BUT NOT IN CASE OF assignments USING METHOD CALLS in Main() in the same or different class]