// static variable in instance method // USING CONSTRUCTOR CALL(S)

// instance variable in instance method // USING CONSTRUCTOR CALL(S)


using System;

class MyClass
{
    static int s; // static variable 
    int i; // instance variable 
    
    public MyClass(int a, int b) 
    {
        s = a; 
        i = b; 
    }

    public int myMethod() // instance method
    {
        return s * i; 
    }
} // 

class MainClass //
{  //
    static void Main() 
    {   
        MyClass mc1 = new MyClass(3, 5);   // *Note
        MyClass mc2 = new MyClass(100, 6); // *Note
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