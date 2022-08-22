// data members 

// consts

// static fields (including static volatile and static readonly) 

// instance fields (including instance volatile and instance readonly) 

// const/readonly cannot be marked volatile

// volatile cannot be long, ulong, double and decimal


using System;

class MainClass // Note
{
    class MyClass
    {
        public const int c  = 1; // can be LOCAL // const cannot be assigned in any constructor

        public static int s = 2;
       
        public static volatile int sv = 3;

        public static readonly int sr = 4;

        public int i = 5;    
      
        public volatile int iv = 6;               

        public readonly int ir = 7; 
        

        static MyClass()
        {
            sr = 44;
        }

        public MyClass()
        {
            
        }

        public MyClass(int sp, int svp, int ip, int ivp, int irp) 
        {
            s = sp;
            sv = svp;
            i = ip;                   
            iv = ivp;
            ir = irp;             
        }    

        public static void staticMethod(MyClass mcp) // static method access
        {
             Console.WriteLine("\nstaticMethod(): c = {0}, s = {1}, sv = {2}, sr = {3}, mcp.i = {4}, mcp.iv = {5}, mcp.ir = {6}\n", c, s, sv, sr, mcp.i, mcp.iv, mcp.ir); 
        }

        public void instanceMethod() // instance method access
        {
            Console.WriteLine("\ninstanceMethod(): c = {0}, s = {1}, sv = {2}, sr = {3}, i = {4}, iv = {5}, ir = {6}\n", c, s, sv, sr, i, iv, ir); 
       
        }
    }   
     
    static void Main()
    {  
        MyClass mc = new MyClass(20, 30, 40, 50, 60); 
        
        Console.WriteLine("\nMyClass.c = {0}, MyClass.s = {1}, MyClass.sv = {2}, MyClass.sr = {3}, mc.i = {4}, mc.iv = {5}, mc.ir = {6}\n", MyClass.c, MyClass.s, MyClass.sv, MyClass.sr, mc.i, mc.iv, mc.ir); 
       
        MyClass.staticMethod(mc);
     
        mc.instanceMethod();        
    }
}