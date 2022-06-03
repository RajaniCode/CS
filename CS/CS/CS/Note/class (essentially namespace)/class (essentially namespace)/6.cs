// class (essentially namespace)

// classes (static/instance) inside a class will be accessed using the class containing it; and their accessibility is the same as a class' member


using System;


internal class A // Also: public and default (internal), cannot be private, protected, or protected internal
{
    public static int a1 = 1;
    private static int a2 = 2;
    protected static int a3 = 3;
    internal static int a4 = 4;
    protected internal static int a5 = 5;
    static int a6 = 6;

 
    private class MainClass
    {
        static void Main()
        {                      
            Console.WriteLine(A.a1 + ", " + A.a2 + ", " + A.a3 + ", " + A.a4 + ", " + A.a5 + ", " + A.a6);            
        }
    }      
}


