// data members 

// consts

// static fields (including static volatile and static readonly) 

// instance fields (including instance volatile and instance readonly) 

// const/readonly cannot be marked volatile

// volatile cannot be long, ulong, double and decimal

// instance (including instance volatile and instance readonly) fields using 'base' (only in instance method in derived class)

// const, static fields (including static volatile and static readonly) using base class


using System;

class MainClass // Note
{
    class BaseClass
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
     
    class DerivedClass : BaseClass
    {
        public void methodDerivedClass()
        {
            Console.WriteLine("\nBaseClass.c = {0}, BaseClass.s = {1}, BaseClass.sv = {2}, BaseClass.sr = {3}, base.i = {4}, base.iv = {5}, base.ir = {6}\n", BaseClass.c, BaseClass.s, BaseClass.sv, BaseClass.sr, base.i, base.iv, base.ir);        
        }
    }

    static void Main()
    {  
        BaseClass bc = new BaseClass(20, 30, 40, 50, 60); 
        
        Console.WriteLine("\nBaseClass.c = {0}, BaseClass.s = {1}, BaseClass.sv = {2}, BaseClass.sr = {3}, bc.i = {4}, bc.iv = {5}, bc.ir = {6}\n", BaseClass.c, BaseClass.s, BaseClass.sv, BaseClass.sr, bc.i, bc.iv, bc.ir); 
        
        DerivedClass dc = new DerivedClass();
        dc.methodDerivedClass();
    }
}