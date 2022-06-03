// data members 

// consts

// static fields (including static volatile and static readonly) 

// instance fields (including instance volatile and instance readonly) 

// const/readonly cannot be marked volatile

// volatile cannot be long, ulong, double and decimal

// DateTime.Now.TimeOfDay.ToString(); // 'System.TimeSpan'


using System;

class MainClass // Note
{
    class MyClass
    {       
        // public const string c  = DateTime.Now.TimeOfDay.ToString(); // c is essentially char[], hence must be assigned null// NOT POSSIBLE because  A const of reference type other than string can only be initialized with null

        public static string s = DateTime.Now.TimeOfDay.ToString();
       
        public static volatile string sv = DateTime.Now.TimeOfDay.ToString();

        public static readonly string sr = DateTime.Now.TimeOfDay.ToString();

        public string i = DateTime.Now.TimeOfDay.ToString();  
      
        public volatile string iv = DateTime.Now.TimeOfDay.ToString();              

        public readonly string ir = DateTime.Now.TimeOfDay.ToString();                
    }   
     
    void instanceMethod()
    {
        // const string c1  = DateTime.Now.TimeOfDay.ToString(); // c is essentially char[], hence must be assigned null// NOT POSSIBLE because  A const of reference type other than string can only be initialized with null

        string local1 = DateTime.Now.TimeOfDay.ToString();

        Console.WriteLine("\nlocal1 = {0}\n", local1);         
    }

    static void Main()
    {  
        // const string c2  = DateTime.Now.TimeOfDay.ToString(); // c is char[], hence must be assigned null// NOT POSSIBLE because  A const of reference type other than string can only be initialized with null

        string local2 = DateTime.Now.TimeOfDay.ToString();

        MyClass mc1 = new MyClass(); 
        
        Console.WriteLine("\nMyClass.s = {0}, MyClass.sv = {1}, MyClass.sr = {2}, mc1.i = {3}, mc1.iv = {4}, mc1.ir = {5}, local2 = {6}\n", MyClass.s, MyClass.sv, MyClass.sr, mc1.i, mc1.iv, mc1.ir, local2);        
    }
}