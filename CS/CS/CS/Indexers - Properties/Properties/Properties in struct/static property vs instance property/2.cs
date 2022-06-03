// Properties in struct // instance properties

// instance property can access [const as read-only instance property] DIRECTLY  

// instance property can access [static/instance fields] including [static/instance volatile] AND [static/instance readonly as read-only static property] DIRECTLY 

// instance constructor can access [static/instance fields] including [static/instance volatile] AND [instance readonly] DIRECTLY 
// BUT CANNOT access [*static readonly] AT ALL
 

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


    public int C  
    {        
        get
        {
           return c;
        }     
    }

    public int S 
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
     
    public int SV  
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

    public int SR  
    {        
        get
        {
           return sr;
        }       
    }

  

    public int I 
    {        
        get
        {
           return i;
        }  

        set
        {
            i = value;          
        }   
    }
     
    public int IV  
    {        
        get
        {
           return iv;
        }  

        set
        {
            iv = value;          
        }   
    }

    public int IR  
    {        
        get
        {
           return ir;
        }       
    }
    
    public MyStruct(string sp) // ONLY parameterized nstance constructor in struct
    {
        s = 20;
        sv = 30;
        // sr = 40; // *NOT POSSIBLE because static readonly ONLY is static constructor
        i = 50;
        iv = 60;
        ir = 70; 
        Console.WriteLine("\ninstance parameterless constructor invoked by calling parameterless constructor call\n");
    }    
}

struct MainStruct
{
    static void Main()
    {
        MyStruct ms = new MyStruct("parameterized");

        Console.WriteLine("read-only instance property C accessing const: {0} \n", ms.C);

        ms.S = 200; 
         
        Console.WriteLine("instance property S accessing static: {0} \n", ms.S);

        ms.SV = 300;

        Console.WriteLine("instance property SV accessing static volatile: {0} \n", ms.SV);

        Console.WriteLine("read-only instance property SR accessing static readonly: {0} \n", ms.SR);   

        ms.I = 500; 
         
        Console.WriteLine("instance property I accessing instance: {0} \n", ms.I);

        ms.IV = 600;

        Console.WriteLine("instance property IV accessing instance volatile: {0} \n", ms.IV);

        Console.WriteLine("read-only instance property IR accessing instance readonly: {0} \n", ms.IR);       
    }
}