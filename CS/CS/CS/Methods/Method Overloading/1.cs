// Method Overloading // instance method // Note: return type difference is not enough


using System;

class MyClass
{
    public void myMethod()
    {
        Console.WriteLine("No parameters");
    }

    public void myMethod(int a) //1. Differ by type of parameter //2. Differ by number of parameters
    {
        Console.WriteLine("Parameter(int a): = {0}", a);
    }

    public void myMethod(int a, int b) //2. Differ by number of parameters
    {
        Console.WriteLine("Parameters (int a, int b): a = {0}, b = {1}", a, b);
    }

    public void myMethod(double a) //1. Differ by type of parameter
    {
        Console.WriteLine("Parameter (double a): a = {0}", a);
    }

    public void myMethod(double a, double b)
    {
        Console.WriteLine("Parameters (double a, double b): a = {0}, b = {1}", a, b);
    }

    public void myMethod(int a, double b) //3. Differ by order of parameter types
    {
        Console.WriteLine("Parameters (int a, double b): a = {0}, b = {1}", a, b);
    }

    public void myMethod(double a, int b) //3. Differ by order of parameter types
    {
        Console.WriteLine("Parameters (int a, double b): a = {0}, b = {1}", a, b);
    }    
}

class MainClass
{
    static void Main()
    {
        MyClass mc = new MyClass();
    
        mc.myMethod();

        mc.myMethod(1);

        mc.myMethod(2, 3); 
  
        mc.myMethod(4D);

        mc.myMethod(5D, 6D);

        mc.myMethod(7, 8D);

        mc.myMethod(9D, 10);

        int i = 11;
        double d = 12;

        byte b = 13;
        short s = 14;

        float f = 15F;

        mc.myMethod(i); // calls int

        mc.myMethod(d); // calls double


        mc.myMethod(b); // calls int
        mc.myMethod(s); // calls int
       
        
        mc.myMethod(f); // calls double
    }
}
  
    