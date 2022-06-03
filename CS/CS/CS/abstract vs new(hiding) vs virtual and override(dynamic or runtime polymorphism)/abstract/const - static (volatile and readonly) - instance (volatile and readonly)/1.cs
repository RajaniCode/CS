// data members in abstract class

// consts

// static fields (including static volatile and static readonly) 

// instance fields (including instance volatile and instance readonly) 

// const/readonly cannot be marked volatile

// volatile cannot be long, ulong, double and decimal

// Variable AND const can be LOCAL (without access specifiers and member modifiers) [inside static/instance method] (ASSIGNMENT AT DECLARATION MUST)


using System;

class MainClass // Note
{
    abstract class BaseClass
    {
        public const int c  = 1; // can be LOCAL // const cannot be assigned in any constructor

        public static int s = 2;
       
        public static volatile int sv = 3;

        public static readonly int sr = 4;

        public int i = 5;    
      
        public volatile int iv = 6;               

        public readonly int ir = 7; 
        

        static BaseClass()
        {
            sr = 44;
        }

        public BaseClass()
        {
            
        }

        public BaseClass(int sp, int svp, int ip, int ivp, int irp) 
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

    class DerivedClass : BaseClass
    {
        public DerivedClass()
        {

        } 

        public DerivedClass(int sp, int svp, int ip, int ivp, int irp) : base(sp, svp, ip, ivp, irp)
        {

        }       
    }

    static void Main()
    {  
        const int c2 = 22; // LOCAL (ASSIGNMENT AT DECLARATION MUST)
         
        int local2 = 777;   // LOCAL (ASSIGNMENT AT DECLARATION MUST) 

        DerivedClass dc1 = new DerivedClass(20, 30, 40, 50, 60); 
        
        Console.WriteLine("\nDerivedClass.c = {0}, DerivedClass.s = {1}, DerivedClass.sv = {2}, DerivedClass.sr = {3}, dc1.i = {4}, dc1.iv = {5}, dc1.ir = {6}, local2 = {7}\n", DerivedClass.c, DerivedClass.s, DerivedClass.sv, DerivedClass.sr, dc1.i, dc1.iv, dc1.ir, local2); 
       
        DerivedClass dc2 = new DerivedClass();
        
        // DerivedClass.c = 100;   // NOT POSSIBLE because const
  
        DerivedClass.s = 200;  
            
        DerivedClass.sv = 300; 
        
        // DerivedClass.sr = 400; // NOT POSSIBLE because readonly
           
        dc2.i = 500;   
  
        dc2.iv = 600;   

        // dc2.ir = 700;    // NOT POSSIBLE because readonly   
       
        // c2 = 222; // NOT POSSIBLE because const
        
        local2 = 999; // NOTE     

        Console.WriteLine("\nDerivedClass.c = {0}, DerivedClass.s = {1}, DerivedClass.sv = {2}, DerivedClass.sr = {3}, dc2.i = {4}, dc2.iv = {5}, dc1.ir = {6}, local2 = {7}\n", DerivedClass.c, DerivedClass.s, DerivedClass.sv, DerivedClass.sr, dc2.i, dc2.iv, dc1.ir, local2); 

        Console.WriteLine("\nc2 = {0}\n", c2);

        MainClass mac = new MainClass();

        mac.instanceMethod();
    }
}