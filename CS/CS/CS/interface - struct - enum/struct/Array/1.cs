// Array in struct // data members 

// consts

// static fields (including static volatile and static readonly) 

// instance fields (including instance volatile and instance readonly) 

// const/readonly cannot be marked volatile

// volatile cannot be long, ulong, double and decimal

// Array and const array can be LOCAL (without access specifiers and member modifiers) [inside static/instance method]
// const array regardless of type can only be assigned nulland ONLY AT DECLARATION AND const array element assignment is ALSO NOT POSSIBLE anywhere
// readonly array (static/instance) cannot be assigned outside declaration and constructors BUT readonly array element assignment is POSSIBLE anywhere


using System;

struct MainStruct // Note
{
    struct MyStruct
    {
        int size;

        public const  string[] c  = null; // ONLY null regardless of type // DON'T print the array or the array element as printing null will throw System.NullReferenceException

        public static  string[] s = {"s1", "s2", "s3", "s4"}; 
       
        public static volatile string[] sv;

        public static readonly string[] sr;

        public string[] i; // = new string[] {"i1", "i2", "i3", "i4"};                  // cannot have instance field initializers in structs
      
        public volatile string[] iv; // = new string[4] {"iv1", "iv2", "iv3", "iv4"};   // cannot have instance field initializers in structs             

        public readonly string[] ir; // = new string[4];                                 // cannot have instance field initializers in structs  
        

        static MyStruct()
        {
            sr = new string[] {"sr1", "sr2", "sr3", "sr4"};
        }

        public MyStruct(string sp) //  cannot contain explicit parameterless constructors
        {   
            size = 4;
            sv = new string[size]; 
            i = new string[] {"i1", "i2", "i3", "i4"}; 
            iv = new string[4] {"iv1", "iv2", "iv3", "iv4"};
            ir = new string[4];  
            ir[0] = "ir1";
            ir[1] = "ir2";
            ir[2] = "ir3";
            ir[3] = "ir4";                     
        } 

        // instance fileds (including instance volatile and instance readonly) MUST be fully assigned before control leaves the constructor
        // OTHERWISE, : this()
        public MyStruct(int sizep) : this() 
        {
            sv = new string[sizep];
            i = new string[] {"i1", "ni2", "i3", "i4"}; 
            iv = new string[4] {"iv1", "iv2", "iv3", "iv4"};
            ir = new string[4];   
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

        
        MyStruct ms = new MyStruct("parameterized"); 
       
        MyStruct.sv[0] = "sv1";

        MyStruct.sv[1] = "sv2";

        MyStruct.sv[2] = "sv3"; 

        MyStruct.sv[3] = "sv4";   // array index should be less than size
     
        Console.WriteLine("\n# 1\n");
        for(int i=0; i<4; i++)
            Console.WriteLine("\nMyStruct.s[{0}] = {1}, MyStruct.sv[{2}] = {3}, MyStruct.sr[{4}] = {5}, ms.i[{6}] = {7}, ms.iv[{8}] = {9}, ms.ir[{10}] = {11}, local2[{12}] = {13}\n", i, MyStruct.s[i], i, MyStruct.sv[i], i, MyStruct.sr[i], i, ms.i[i], i, ms.iv[i], i, ms.ir[i], i, local2[i]); 
       

        // c2[0] = "c2"; // NOT POSSIBLE because it will throw System.NullReferenceException
  
        local2 = new string[] {"newerlocal21", "newerlocal22", "newerlocal23", "newerlocal24"}; // NOTE


        // MyStruct.c = null; // NOT POSSIBLE because c is const
       
        MyStruct.s = new string[] {"newers1", "newers2", "newers3", "newers4"};

        // MyStruct.sr = new string[] {"newersr1", "newersr2", "newersr3", "newersr4"}; // NoT POSSIBLE because sr is readonly BUT

       
        MyStruct.sr[0] = "newersr1"; // POSSIBLE   

        MyStruct.sr[1] = "newersr2"; // POSSIBLE

        MyStruct.sr[2] = "newersr3"; // POSSIBLE   
       
        MyStruct.sr[3] = "newersr4"; // POSSIBLE 


        ms.i = new string[] {"neweri1", "neweri2", "neweri3", "neweri4"}; 

        ms.iv = new string[] {"neweriv1", "neweriv2", "neweriv3", "neweriv4"}; 

        // ms.ir = new string[] {"newerir1", "newerir2", "newerir3", "newerir4"}; // NoT POSSIBLE because ir is readonly BUT

        ms.ir[0] = "newerir1"; // POSSIBLE   

        ms.ir[1] = "newerir2"; // POSSIBLE

        ms.ir[2] = "newerir3"; // POSSIBLE   
       
        ms.ir[3] = "newerir4"; // POSSIBLE 


        Console.WriteLine("\n# 2\n");
        for(int i=0; i<4; i++)
            Console.WriteLine("\nMyStruct.s[{0}] = {1}, MyStruct.sv[{2}] = {3}, MyStruct.sr[{4}] = {5}, ms.i[{6}] = {7}, ms.iv[{8}] = {9}, ms.ir[{10}] = {11}, local2[{12}] = {13}\n", i, MyStruct.s[i], i, MyStruct.sv[i], i, MyStruct.sr[i], i, ms.i[i], i, ms.iv[i], i, ms.ir[i], i, local2[i]); 
       
        

        MyStruct ms1 = new MyStruct(4);
        
        MyStruct.sv[0] = "newestsv1";

        MyStruct.sv[1] = "newestsv2";

        MyStruct.sv[2] = "newestsv3"; 

        MyStruct.sv[3] = "newestsv4"; // array index should be less than size
     
        Console.WriteLine("\n# 3\n");
        for(int i=0; i<4; i++)
           Console.WriteLine("\nMyStruct.s[{0}] = {1}, MyStruct.sv[{2}] = {3}, MyStruct.sr[{4}] = {5}, ms1.i[{6}] = {7}, ms1.iv[{8}] = {9}, ms1.ir[{10}] = {11}\n", i, MyStruct.s[i], i, MyStruct.sv[i], i, MyStruct.sr[i], i, ms1.i[i], i, ms1.iv[i], i, ms1.ir[i]); 
       


        MainStruct mac = new MainStruct();

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