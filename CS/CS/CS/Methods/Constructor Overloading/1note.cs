// Constructor Overloading

// ?Note: parameterless constructor [NEEDED if there is constructor overloading AND parameterless constructor call] 


using System;

class MyClass
{
    int x; 
  
    public MyClass()
    {
        Console.WriteLine("Inside MyClass()");
        x = 0;
    }

    public MyClass(int k)
    {
        Console.WriteLine("Inside MyClass(int k)");
        x = k;
    }

    public MyClass(int k, int l)
    {
        Console.WriteLine("Inside MyClass(int k, int l)");
        x = k * l;
    }

    public MyClass(double k)
    {
        Console.WriteLine("Inside MyClass(double k)");
        x = (int)k; // Note
    }

    public MyClass(double k, double l)
    {
        Console.WriteLine("Inside MyClass(double k, double l)");
        x = (int)k * (int)l; // Note
    }

    public static void printMethod(MyClass mcp) // static

    {
        Console.WriteLine("printMethod: x = {0}", mcp.x);
    }
}

class MainClass
{
    static void Main()
    {
        MyClass mc1 = new MyClass();
       
        MyClass mc2 = new MyClass(1);
      
        MyClass mc3 = new MyClass(2, 3);
        
        MyClass mc4 = new MyClass(4D);
       
        MyClass mc5 = new MyClass(5D, 6D);
      

        MyClass.printMethod(mc1);
        MyClass.printMethod(mc2);
        MyClass.printMethod(mc3);
        MyClass.printMethod(mc4);
        MyClass.printMethod(mc5);          
    }
}
 


