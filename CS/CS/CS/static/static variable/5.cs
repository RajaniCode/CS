// static variable in instance method // USING METHOD CALL(S)

// instance variable in instance method // USING METHOD CALL(S)


using System;

class MyClass
{
    static int s; // static variable 
       
    int i; // instance variable     
    
    public int myMethod(int a, int b) // instance method
    {
        s = a;
        i = b;
        return s * i; 
    }
} // 

class MainClass //
{  //
    static void Main() 
    {
        MyClass mc1 = new MyClass();
        MyClass mc2 = new MyClass();

        Console.WriteLine("The result of mc1 = {0}", mc1.myMethod(3, 5));   // *Note
        Console.WriteLine("The result of mc2 = {0}", mc2.myMethod(100, 6)); // *Note
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