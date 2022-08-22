// Method Overloading // static method // Also: works if overloaded as instance or with different access modifier


using System;

class MyClass
{
    static int x;

    public static void myMethod()
    {
        Console.WriteLine("No parameters");
    }
   
     
    public static void myMethod(int a)
    {
        x = a;
        Console.WriteLine("Parameter int: x = {0}", x);
    }

    public static void myMethod(int a, int b)
    {
        Console.WriteLine("Parameters int: a = {0}, b = {1}", a, b);
    }

    public static void myMethod(double a)
    {
        Console.WriteLine("Parameter double: a = {0}", a);
    }

    public static void myMethod(double a, double b)
    {
        Console.WriteLine("Parameter double: a = {0}, b = {1}", a, b);
    }
}

class MainClass
{
    static void Main()
    {
        MyClass.myMethod();

        MyClass.myMethod(1);

        MyClass.myMethod(2, 3); 
  
        MyClass.myMethod(4D);

        MyClass.myMethod(5D, 6D);

        int i = 11;
        double d = 12;

        byte b = 13;
        short s = 14;

        float f = 15F;

        MyClass.myMethod(i); // calls int

        MyClass.myMethod(d); // calls double


        MyClass.myMethod(b); // calls int
        MyClass.myMethod(s); // calls int
       
        
        MyClass.myMethod(f); // calls double       
    }
}
  
    