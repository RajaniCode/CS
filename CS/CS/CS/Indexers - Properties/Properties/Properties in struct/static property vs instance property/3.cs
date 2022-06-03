// Properties in struct  // static properties 

// static property [except read-only] can be assigned in static constructor

// static property [except read-only] can be assigned in static constructor 

// static property [except read-only] &
// [**INCLUDING that accessing instance field (including instance volatile)] *{NOT IN class}*
// can be assigned in instance constructor 


using System;

struct MyStruct
{
    const int c = 1;
   
    static int s = 2;
    
    static int sv = 3;
    
    static readonly int sr = 4; 

    int i; // cannot have instance field initializers in structs
    
    volatile int iv; // cannot have instance field initializers in structs

    readonly int ir; // cannot have instance field initializers in structs


    public static int C  
    {        
        get
        {
           return c;
        }     
    }

    public static int S 
    {        
        get
        {
           return s;
        }  

        set
        {
            s = value;          
        }   
    }
     
    public static int SV  
    {        
        get
        {
           return sv;
        }  

        set
        {
            sv = value;          
        }   
    }

    public static int SR  
    {        
        get
        {
           return sr;
        }       
    }

    static MyStruct ms = new MyStruct();

    public static int I 
    {        
        get
        {
           return ms.i;
        }  

        set
        {
            ms.i = value;          
        }   
    }
     
    public static int IV  
    {        
        get
        {
           return ms.iv;
        }  

        set
        {
            ms.iv = value;          
        }   
    }

    public static int IR  
    {        
        get
        {
           return ms.ir;
        }       
    }
    
    static MyStruct()
    {
        Console.WriteLine("\nexplicit static parameterless constructor atomatically invoked\n");

        s = 20;
        sv = 30;
        sr = 40;
        ms.i = 50;
        ms.iv = 60;
        // ms.ir = 70; // NOT POSSIBLE because ir is instance readonly [which can be accessed ONLY in instance constructor]
        
        S = 2000;
        SV = 3000;
        I = 5000;
        IV = 6000;
    } 

    // In struct instance fields (including instance volatile and instance readonly) must be fully assigned before control leaves
    // parameterized instance constructor OR : this()
    public MyStruct(string sp) : this() // ONLY parameterized instance constructor in struct
    {  
        Console.WriteLine("\nparameterized instance constructor invoked by parameterized instance constructor call\n");       

        S = 2222;
        SV = 3333;
        I = 5555;  // #POSSIBLE in struct 
        IV = 6666; // #POSSIBLE in struct  
    }             
}

struct MainStruct
{
    static void Main()
    {
        Console.WriteLine("read-only static property C accessing const: {0} \n", MyStruct.C);
             
        Console.WriteLine("static property S accessing static: {0} \n", MyStruct.S);

        Console.WriteLine("static property SV accessing static volatile: {0} \n", MyStruct.SV);

        Console.WriteLine("read-only static property SR accessing static readonly: {0} \n", MyStruct.SR); 
       
        Console.WriteLine("static property I accessing instance: {0} \n", MyStruct.I);

        Console.WriteLine("static property IV accessing instance volatile: {0} \n", MyStruct.IV);

        Console.WriteLine("read-only static property IR accessing instance readonly: {0} \n", MyStruct.IR);    

        MyStruct ms = new MyStruct("parameterized");

        Console.WriteLine("read-only static property C accessing const: {0} \n", MyStruct.C);
             
        Console.WriteLine("static property S accessing static: {0} \n", MyStruct.S);

        Console.WriteLine("static property SV accessing static volatile: {0} \n", MyStruct.SV);

        Console.WriteLine("read-only static property SR accessing static readonly: {0} \n", MyStruct.SR); 
       
        Console.WriteLine("static property I accessing instance: {0} \n", MyStruct.I);

        Console.WriteLine("static property IV accessing instance volatile: {0} \n", MyStruct.IV);

        Console.WriteLine("read-only static property IR accessing instance readonly: {0} \n", MyStruct.IR);               
    }
}