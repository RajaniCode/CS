// data members 

// consts

// static fields (including static volatile and static readonly) 

// instance fields (including instance volatile and instance readonly) 

// const/readonly cannot be marked volatile

// volatile cannot be long, ulong, double and decimal

// Variable AND const can be LOCAL (without access specifiers and member modifiers) [inside static/instance method] (ASSIGNMENT AT DECLARATION MUST)


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
    }   
     
    void instanceMethod()
    {
        const int c1 = 11; // LOCAL (ASSIGNMENT AT DECLARATION MUST) 

        int local1 = 333;  // LOCAL (ASSIGNMENT AT DECLARATION MUST) 
  
        // c1 = 111; // NOT POSSIBLE because const

        local1 = 555;

        Console.WriteLine("\nlocal1 = {0}, c1 = {1}\n", local1, c1);          
    }

    static void Main()
    {  
        const int c2 = 22; // LOCAL (ASSIGNMENT AT DECLARATION MUST)
         
        int local2 = 777;   // LOCAL (ASSIGNMENT AT DECLARATION MUST) 

        MyClass mc1 = new MyClass(20, 30, 40, 50, 60); 
        
        Console.WriteLine("\nMyClass.c = {0}, MyClass.s = {1}, MyClass.sv = {2}, MyClass.sr = {3}, mc1.i = {4}, mc1.iv = {5}, mc1.ir = {6}, local2 = {7}\n", MyClass.c, MyClass.s, MyClass.sv, MyClass.sr, mc1.i, mc1.iv, mc1.ir, local2); 
       
        MyClass mc2 = new MyClass();
        
        // MyClass.c = 100;   // NOT POSSIBLE because const
  
        MyClass.s = 200;  
            
        MyClass.sv = 300; 
        
        // MyClass.sr = 400; // NOT POSSIBLE because readonly
           
        mc2.i = 500;   
  
        mc2.iv = 600;   

        // mc2.ir = 700;    // NOT POSSIBLE because readonly   
       
        // c2 = 222; // NOT POSSIBLE because const
        
        local2 = 999; // NOTE     

        Console.WriteLine("\nMyClass.c = {0}, MyClass.s = {1}, MyClass.sv = {2}, MyClass.sr = {3}, mc2.i = {4}, mc2.iv = {5}, mc1.ir = {6}, local2 = {7}\n", MyClass.c, MyClass.s, MyClass.sv, MyClass.sr, mc2.i, mc2.iv, mc1.ir, local2); 

        Console.WriteLine("\nc2 = {0}\n", c2);

        MainClass mac = new MainClass();

        mac.instanceMethod();
    }
}