// interface // interface cannot have static members


using System;

interface InterfaceExample // Note: It is mandatory that all the methods should be implemented by the implementing class 
{
    int nextMethod();
    void resetMethod();    
    void fromMethod(int f); // Note
}

class MyClass : InterfaceExample // Note
{
    int initial;
    int result;
    
    public MyClass() 
    {
        initial = 0;
        result = 0;
    }

    public int nextMethod() 
    {
        result += 2;
        return result;
    }

    public void resetMethod() 
    {
        result = initial;
    }
  
    public void fromMethod(int f) 
    { 
        initial = f; // Note       
        result = initial;
    }
}

class MainClass
{
    
    static void Main()
    {
        MyClass mc = new MyClass();
        
        for(int i=0; i<5; i++)
            Console.WriteLine(mc.nextMethod());
        Console.WriteLine();

        Console.WriteLine("Resetting");
        mc.resetMethod();
        for(int i=0; i<5; i++)
            Console.WriteLine(mc.nextMethod());
        Console.WriteLine();
        
        Console.WriteLine("From 100");;
        mc.fromMethod(100);             
        for(int i=0; i<5; i++)
            Console.WriteLine(mc.nextMethod());
    }
}
 
        
        




















    
