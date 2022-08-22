// data members 

// consts

// static fields (including static volatile and static readonly) 

// instance fields (including instance volatile and instance readonly) 

// const/readonly cannot be marked volatile

// volatile cannot be long, ulong, double and decimal

// DateTime.Now.Ticks; // Note data type is long


using System;

class MainClass // Note
{
    class MyClass
    {
        // public const int c  = (int)DateTime.Now.Ticks; // NOT POSSIBLE because The expression being assigned to 'MainClass.MyClass.c' must be constant

        public static int s = (int)DateTime.Now.Ticks;
       
        public static volatile int sv = (int)DateTime.Now.Ticks;

        public static readonly int sr = (int)DateTime.Now.Ticks;

        public int i = (int)DateTime.Now.Ticks;    
      
        public volatile int iv = (int)DateTime.Now.Ticks;               

        public readonly int ir = (int)DateTime.Now.Ticks;                
    }   
     
    void instanceMethod()
    {
      // const int c1 = (int)DateTime.Now.Ticks; // NOT POSSIBLE because The expression being assigned to 'MainClass.MyClass.c' must be constant

      int local1 = (int)DateTime.Now.Ticks;

      Console.WriteLine("\nlocal1 = {0}\n", local1);            
    }

    static void Main()
    {  
        // const int c2 = (int)DateTime.Now.Ticks; // NOT POSSIBLE because The expression being assigned to 'MainClass.MyClass.c' must be constant

        int local2 = (int)DateTime.Now.Ticks;

        MyClass mc = new MyClass(); 
        
        Console.WriteLine("\nMyClass.s.ToString() = {0}, MyClass.sv = {1}, MyClass.sr = {2}, mc.i = {3}, mc.iv = {4}, mc.ir = {5}, local2 = {6}\n", MyClass.s, MyClass.sv, MyClass.sr, mc.i, mc.iv, mc.ir, local2);        

        MainClass mac = new MainClass();

        mac.instanceMethod();
    }
}