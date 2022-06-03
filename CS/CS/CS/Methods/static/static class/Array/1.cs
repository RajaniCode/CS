// Array in static class // data members 

// consts

// static fields (including static volatile and static readonly) 

// const/readonly cannot be marked volatile

// volatile cannot be long, ulong, double and decimal

// Array and const array can be LOCAL (without access specifiers and member modifiers) [ONLY inside static method in static class]
// const array regardless of type can only be assigned nulland ONLY AT DECLARATION AND const array element assignment is ALSO NOT POSSIBLE anywhere
// readonly array (static/instance) cannot be assigned outside declaration and constructors BUT readonly array element assignment is POSSIBLE anywhere


using System;

static class MainClass // Note // can be static
{
    static class MyClass
    {
        static int size;

        public const  string[] c  = null; // ONLY null regardless of type // DON'T print the array or the array element as printing null will throw System.NullReferenceException

        public static  string[] s = {"s1", "s2", "s3", "s4"}; 
       
        public static volatile string[] sv;

        public static readonly string[] sr;

        static MyClass()
        {
            size = 4;
            sv = new string[size]; 
            sr = new string[] {"sr1", "sr2", "sr3", "sr4"};
        }      
    }   
     
    static string[] staticMethod()
    {
      const string[] c1 = null; // ONLY null regardless of type // Don't print the array or the array element as printing null will throw System.NullReferenceException
      
      string[] local1 = new string[] {"local11", "local12", "local13", "local14"};

      // c1[0] = "c1"; // NOT POSSIBLE because it will throw System.NullReferenceException  

      local1 = new string[] {"newerlocal11", "newerlocal12", "newerlocal13", "newerlocal14"};
   
      return local1;                   
    }                                
                                           
    static void Main()            
    {                               
        const string[] c2 = null; // ONLY null regardless of type // Don't print the array or the array element as printing null will throw System.NullReferenceException
  
        string[] local2 = new string[] {"local21", "local22", "local23", "local24"};

        
        MyClass.sv[0] = "sv1";

        MyClass.sv[1] = "sv2";

        MyClass.sv[2] = "sv3"; 

        MyClass.sv[3] = "sv4";   // array index should be less than size
     
        Console.WriteLine("\n# 1\n");
        for(int i=0; i<4; i++)
            Console.WriteLine("\nMyClass.s[{0}] = {1}, MyClass.sv[{2}] = {3}, MyClass.sr[{4}] = {5}, local2[{6}] = {7}\n", i, MyClass.s[i], i, MyClass.sv[i], i, MyClass.sr[i], i, local2[i]); 
       

        // c2[0] = "c2"; // NOT POSSIBLE because it will throw System.NullReferenceException
  
        local2 = new string[] {"newerlocal21", "newerlocal22", "newerlocal23", "newerlocal24"}; // NOTE


        // MyClass.c = null; // NOT POSSIBLE because c is const
       
        MyClass.s = new string[] {"newers1", "newers2", "newers3", "newers4"};

        // MyClass.sr = new string[] {"newersr1", "newersr2", "newersr3", "newersr4"}; // NoT POSSIBLE because sr is readonly BUT

       
        MyClass.sr[0] = "newersr1"; // POSSIBLE   

        MyClass.sr[1] = "newersr2"; // POSSIBLE

        MyClass.sr[2] = "newersr3"; // POSSIBLE   
       
        MyClass.sr[3] = "newersr4"; // POSSIBLE 


        Console.WriteLine("\n# 2\n");
        for(int i=0; i<4; i++)
            Console.WriteLine("\nMyClass.s[{0}] = {1}, MyClass.sv[{2}] = {3}, MyClass.sr[{4}] = {5}, local2[{6}] = {7}\n", i, MyClass.s[i], i, MyClass.sv[i], i, MyClass.sr[i], i, local2[i]); 
       
        
        string[] args = MainClass.staticMethod(); // NOTE
        
        for(int i=0; i<4; i++)
           Console.WriteLine(args[i]);              // NOTE
           


        int size = 4;

        string[] local3 = new string[size]; // POSSIBLE ONLY without assignment // POSSIBLE ONLY incase of LOCAL (inside static/instance method)  AND INSIDE CONSTRUCTOR // array index should be less than size

        local3[0] = "local31";
   
        local3[1] = "local32";
 
        local3[2] = "local33";

        local3[0] = "local34";

        local3 = new string[] {"newlocal31", "newlocal32", "newlocal33", "newlocal34"};


        string[] local4;

        local4 = new string[size]; // POSSIBLE ONLY without assignment // POSSIBLE ONLY incase of LOCAL (inside static/instance method) AND INSIDE CONSTRUCTOR // array index should be less than size     

        local4[0] = "local41";
   
        local4[1] = "local42";
 
        local4[2] = "local43";

        local4[3] = "local44";

        local4 = new string[] {"newlocal21", "newlocal22", "newlocal23", "newlocal24"};


        string[] array = new string[4]; // POSSIBLE without assignment // array index should be less than 4    

        array[0] = "array1";
   
        array[1] = "array2";
 
        array[2] = "array3";

        array[3] = "array4";

        array = new string[5];

        array = new string[] {"newarray1", "newarray2", "newarray3", "newarray4", "newarray5"};

        array = new string[] {"newerarray1", "newerarray2", "newesrarray3"};
    }
}