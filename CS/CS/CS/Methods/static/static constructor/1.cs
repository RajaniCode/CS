// static constructor // no access modifier // a static constructor must be parameterless therefore cannot be overloaded


using System;

class MyClass
{
    public static int x; // static 
    public int y;
    
    static MyClass() // static constructor // no access modifier
    {   
        x = 100; // static        
    }

    public MyClass() // instance constructor // public access modifier
    {   
        y = 200; // instance       
    }

    ~MyClass() // Note
    {
        Console.WriteLine("Destructor"); 
    } 
}

class MainClass
{
    static void Main()
    {
        MyClass mc = new MyClass();
       
        Console.WriteLine("MyClass.x = {0}", MyClass.x);
        Console.WriteLine("mc.y = {0}", mc.y);
    }
}
  