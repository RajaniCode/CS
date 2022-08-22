// interface // interface cannot have static members


using System;  

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


//>csc 1.cs 1a.cs 1b.cs

//>1

// (1.cs containing entry point[static void Main()])



        
        




















    
