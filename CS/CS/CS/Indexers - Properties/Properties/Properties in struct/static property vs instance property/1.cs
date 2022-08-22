// Properties in struct // static properties

// staic property can access [const as read-only static property] DIRECTLY  

// staic property can access ONLY [static fields] including [static volatile] AND [static readonly as read-only static property] DIRECTLY 

// static constructor can access ONLY [static fields] including [static volatile] AND [static readonly] DIRECTLY 
 

// staic property can access [instance fields] including [instance volatile] AND [instance readonly as read-only static property] 
// USING ms CREATED INSIDE struct as: static MyStruct ms = new MyStruct(); 

// static constructor can access [instance fields] including [instance volatile] BUT CANNOT access [*instance readonly] AT ALL  
// USING ms CREATED INSIDE struct as: static MyStruct ms = new MyStruct(); 


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
        s = 20;
        sv = 30;
        sr = 40;
        ms.i = 50;
        ms.iv = 60;
        // ms.ir = 70; // *NOT POSSIBLE because instance readonly ONLY in instance [parameterized in struct] constructor 
        Console.WriteLine("\nexplicit static parameterless constructor atomatically invoked\n");
    }    
}

struct MainStruct
{
    static void Main()
    {
        Console.WriteLine("read-only static property C accessing const: {0} \n", MyStruct.C);

        MyStruct.S = 200; 
         
        Console.WriteLine("static property S accessing static: {0} \n", MyStruct.S);

        MyStruct.SV = 300;

        Console.WriteLine("static property SV accessing static volatile: {0} \n", MyStruct.SV);

        Console.WriteLine("read-only static property SR accessing static readonly: {0} \n", MyStruct.SR);   

        MyStruct.I = 500; 
         
        Console.WriteLine("static property I accessing instance: {0} \n", MyStruct.I);

        MyStruct.IV = 600;

        Console.WriteLine("static property IV accessing instance volatile: {0} \n", MyStruct.IV);

        Console.WriteLine("read-only static property IR accessing instance readonly: {0} \n", MyStruct.IR);               
    }
}