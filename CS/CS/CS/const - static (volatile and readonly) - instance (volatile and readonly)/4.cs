// Array // data members 

// consts

// static fields (including static volatile and static readonly) 

// instance fields (including instance volatile and instance readonly) 

// const/readonly cannot be marked volatile

// volatile cannot be long, ulong, double and decimal

// Array and const array can be LOCAL (without access specifiers and member modifiers) [inside static/instance method]
// const array regardless of type can only be assigned nulland ONLY AT DECLARATION AND const array element assignment is ALSO NOT POSSIBLE anywhere
// readonly array (static/instance) cannot be assigned outside declaration and constructors BUT readonly array element assignment is POSSIBLE anywhere


using System;

class MainClass // Note
{
    class MyClass
    {
        int size;

        public const  string[] c  = null; // ONLY null regardless of type // DON'T print the array or the array element as printing null will throw System.NullReferenceException

        public static  string[] s = {"s1", "s2", "s3", "s4"}; 
       
        public static volatile string[] sv;

        public static readonly string[] sr;

        public string[] i = new string[] {"i1", "i2", "i3", "i4"};    
      
        public volatile string[] iv = new string[4] {"iv1", "iv2", "iv3", "iv4"};                

        public readonly string[] ir = new string[4];  
        

        static MyClass()
        {
            sr = new string[] {"sr1", "sr2", "sr3", "sr4"};
        }

        public MyClass() 
        {   
            size = 4;
            sv = new string[size]; 
            ir[0] = "ir1";
            ir[1] = "ir2";
            ir[2] = "ir3";
            ir[3] = "ir4";                     
        } 

        public MyClass(int sizep)    
        {
            sv = new string[sizep]; 
            ir[0] = "newestir1";
            ir[1] = "newestir2";
            ir[2] = "newestir3";
            ir[3] = "newestir4";
        }
    }   
     
    string[] instanceMethod()
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

        
        MyClass mc = new MyClass(); 
       
        MyClass.sv[0] = "sv1";

        MyClass.sv[1] = "sv2";

        MyClass.sv[2] = "sv3"; 

        MyClass.sv[3] = "sv4";   // array index should be less than size
     
        Console.WriteLine("\n# 1\n");
        for(int i=0; i<4; i++)
            Console.WriteLine("\nMyClass.s[{0}] = {1}, MyClass.sv[{2}] = {3}, MyClass.sr[{4}] = {5}, mc.i[{6}] = {7}, mc.iv[{8}] = {9}, mc.ir[{10}] = {11}, local2[{12}] = {13}\n", i, MyClass.s[i], i, MyClass.sv[i], i, MyClass.sr[i], i, mc.i[i], i, mc.iv[i], i, mc.ir[i], i, local2[i]); 
       

        // c2[0] = "c2"; // NOT POSSIBLE because it will throw System.NullReferenceException
  
        local2 = new string[] {"newerlocal21", "newerlocal22", "newerlocal23", "newerlocal24"}; // NOTE


        // MyClass.c = null; // NOT POSSIBLE because c is const
       
        MyClass.s = new string[] {"newers1", "newers2", "newers3", "newers4"};

        // MyClass.sr = new string[] {"newersr1", "newersr2", "newersr3", "newersr4"}; // NoT POSSIBLE because sr is readonly BUT

       
        MyClass.sr[0] = "newersr1"; // POSSIBLE   

        MyClass.sr[1] = "newersr2"; // POSSIBLE

        MyClass.sr[2] = "newersr3"; // POSSIBLE   
       
        MyClass.sr[3] = "newersr4"; // POSSIBLE 


        mc.i = new string[] {"neweri1", "neweri2", "neweri3", "neweri4"}; 

        mc.iv = new string[] {"neweriv1", "neweriv2", "neweriv3", "neweriv4"}; 

        // mc.ir = new string[] {"newerir1", "newerir2", "newerir3", "newerir4"}; // NoT POSSIBLE because ir is readonly BUT

        mc.ir[0] = "newerir1"; // POSSIBLE   

        mc.ir[1] = "newerir2"; // POSSIBLE

        mc.ir[2] = "newerir3"; // POSSIBLE   
       
        mc.ir[3] = "newerir4"; // POSSIBLE 


        Console.WriteLine("\n# 2\n");
        for(int i=0; i<4; i++)
            Console.WriteLine("\nMyClass.s[{0}] = {1}, MyClass.sv[{2}] = {3}, MyClass.sr[{4}] = {5}, mc.i[{6}] = {7}, mc.iv[{8}] = {9}, mc.ir[{10}] = {11}, local2[{12}] = {13}\n", i, MyClass.s[i], i, MyClass.sv[i], i, MyClass.sr[i], i, mc.i[i], i, mc.iv[i], i, mc.ir[i], i, local2[i]); 
       
        

        MyClass mc1 = new MyClass(4);
        
        MyClass.sv[0] = "newestsv1";

        MyClass.sv[1] = "newestsv2";

        MyClass.sv[2] = "newestsv3"; 

        MyClass.sv[3] = "newestsv4"; // array index should be less than size
     
        Console.WriteLine("\n# 3\n");
        for(int i=0; i<4; i++)
           Console.WriteLine("\nMyClass.s[{0}] = {1}, MyClass.sv[{2}] = {3}, MyClass.sr[{4}] = {5}, mc1.i[{6}] = {7}, mc1.iv[{8}] = {9}, mc1.ir[{10}] = {11}\n", i, MyClass.s[i], i, MyClass.sv[i], i, MyClass.sr[i], i, mc1.i[i], i, mc1.iv[i], i, mc1.ir[i]); 
       


        MainClass mac = new MainClass();

        string[] args = mac.instanceMethod(); // NOTE
        
        for(int i=0; i<4; i++)
           Console.WriteLine(args[i]);        // NOTE
           


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