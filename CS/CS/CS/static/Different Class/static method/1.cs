// static variable can be used in static method [in different class] ONLY by USING CLASS and should be PUBLIC

// instance variable can be used in static method [in different class]
// ONLY by USING REFERENCE PASSED IN PARAMETER that allows OBJECT PASSED IN ARGUMENT from Main() and should be PUBLIC


using System;

class A
{
    public static int s; // static variable   // Note: public
    public int i;        // instance variable // Note: public
    
    public A(int k, int l)
    {
        s = k;
        i = l;   
    }
}

class B
{       
    public static void myMethod(A ap)   // static method
    {   
        Console.WriteLine("s = {0} and i = {1}", A.s, ap.i); // Note
    }  
} //

class MainClass //
{ //
    static void Main()
    {
        A a = new A(1, 2);
        
        B.myMethod(a);        
    }    
}
