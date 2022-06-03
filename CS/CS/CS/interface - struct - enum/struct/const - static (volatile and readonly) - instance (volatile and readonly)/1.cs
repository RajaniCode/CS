// data members in struct

// consts

// static fields (including static volatile and static readonly) 

// instance fields (including instance volatile and instance readonly) 

// const/readonly cannot be marked volatile

// volatile cannot be long, ulong, double and decimal

// Variable AND const can be LOCAL (without access specifiers and member modifiers) [inside static/instance method] (ASSIGNMENT AT DECLARATION MUST)


using System;

struct MainStruct // Note
{
    struct MyStruct
    {
        public const int c  = 1; // can be LOCAL // const cannot be assigned in any constructor

        public static int s = 2;
       
        public static volatile int sv = 3;

        public static readonly int sr = 4;

        public int i; // = 5;             // cannot have instance field initializers in structs
      
        public volatile int iv; // = 6;   // cannot have instance field initializers in structs              

        public readonly int ir; // = 7;   // cannot have instance field initializers in structs 
        

        static MyStruct()
        {
            sr = 44;
        }
    
        // instance fileds (including instance volatile and instance readonly) MUST be fully assigned before control leaves the constructor
        // OTHERWISE, : this()
        public MyStruct(string sp) : this() //  cannot contain explicit parameterless constructors
        {
            
        }

        public MyStruct(int sp, int svp, int ip, int ivp, int irp)
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

        MyStruct ms1 = new MyStruct(20, 30, 40, 50, 60); 
        
        Console.WriteLine("\nMyStruct.c = {0}, MyStruct.s = {1}, MyStruct.sv = {2}, MyStruct.sr = {3}, ms1.i = {4}, ms1.iv = {5}, ms1.ir = {6}, local2 = {7}\n", MyStruct.c, MyStruct.s, MyStruct.sv, MyStruct.sr, ms1.i, ms1.iv, ms1.ir, local2); 
       
        MyStruct ms2 = new MyStruct("parameterized");
        
        // MyStruct.c = 100;   // NOT POSSIBLE because const
  
        MyStruct.s = 200;  
            
        MyStruct.sv = 300; 
        
        // MyStruct.sr = 400; // NOT POSSIBLE because readonly
           
        ms2.i = 500;   
  
        ms2.iv = 600;   

        // ms2.ir = 700;    // NOT POSSIBLE because readonly   
       
        // c2 = 222; // NOT POSSIBLE because const
        
        local2 = 999; // NOTE     

        Console.WriteLine("\nMyStruct.c = {0}, MyStruct.s = {1}, MyStruct.sv = {2}, MyStruct.sr = {3}, ms2.i = {4}, ms2.iv = {5}, ms1.ir = {6}, local2 = {7}\n", MyStruct.c, MyStruct.s, MyStruct.sv, MyStruct.sr, ms2.i, ms2.iv, ms1.ir, local2); 

        Console.WriteLine("\nc2 = {0}\n", c2);

        MainStruct mas = new MainStruct();

        mas.instanceMethod();
    }
}