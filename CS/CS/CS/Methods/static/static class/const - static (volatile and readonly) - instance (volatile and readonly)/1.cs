// data members 

// consts

// static fields (including static volatile and static readonly) 

// const/readonly cannot be marked volatile

// volatile cannot be long, ulong, double and decimal

// Variable AND const can be LOCAL (without access specifiers and member modifiers) [inside static/instance method] (ASSIGNMENT AT DECLARATION MUST)


using System;

static class MainClass // Note // can be static
{
    static class MyClass
    {
        public const int c  = 1; // can be LOCAL // const cannot be assigned in any constructor

        public static int s = 2;
       
        public static volatile int sv = 3;

        public static readonly int sr = 4;

        static MyClass()
        {
            sr = 44;
        }
    }   
     
    static void staticMethod()
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
        
        Console.WriteLine("\nMyClass.c = {0}, MyClass.s = {1}, MyClass.sv = {2}, MyClass.sr = {3}, local2 = {4}\n", MyClass.c, MyClass.s, MyClass.sv, MyClass.sr, local2); 
       
        
        // c2 = 222; // NOT POSSIBLE because const
        
        local2 = 999; // NOTE     

        Console.WriteLine("\nMyClass.c = {0}, MyClass.s = {1}, MyClass.sv = {2}, MyClass.sr = {3}, local2 = {4}\n", MyClass.c, MyClass.s, MyClass.sv, MyClass.sr, local2); 

        Console.WriteLine("\nc2 = {0}\n", c2);

        MainClass.staticMethod(); // NOTE
    }
}