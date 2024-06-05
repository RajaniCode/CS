// Assignment precedence

using System;

class A
{
    public static int s; // static variable
    public int i;        // instance variable
       
    public A(int k, int l)
    {
        s = k;
        i = l;
    }   
    public static void myMethod(A ap, int m, int n)   // static method
    {   A.s = m;
        ap.i = n;
        Console.WriteLine("s = {0} and i = {1}", A.s, ap.i); // Note: mcp.i // USING INSTANCE
    }  
} //

class MainClass //
{ //
    static void Main()
    {     
        A a = new A(1, 2); 
        A.myMethod(a, 5, 6); // Arguments reign supreme
        A.s = 3;        
        a.i = 4; // For instance variable, the last passed value takes precedence WITH REGARD TO 'a' in B.myMethod(a); [USING CONSTRUCTOR CALL vs USING INSTANCE]
        A a1 = new A(7, 8); // For static variable, just the last passed value takes precedence REGARDLESS of 'a' in B.myMethod(a); [USING CONSTRUCTOR CALL vs USING CLASS]
        a1.i = 9;                  
    }    
}
