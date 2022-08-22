// Properties in struct // instance properties

// instance property [except read-only] can be assigned in static constructor 
// USING: ms CREATED INSIDE struct as: static MyStruct ms = new MyStruct(); 
// [NOT USEFUL for instance property accessing instance fields (including instance volatile)]
// [NOT USEFUL if simultaneously assigned in instance constructor]

// instance property [except read-only] can be assigned in instance constructor


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

    static MyStruct ms = new MyStruct();

    static MyStruct()
    {
        Console.WriteLine("\nexplicit static parameterless constructor atomatically invoked\n");
      
        ms.S = 2000;  // NO EFFECT
        ms.SV = 3000; // NO EFFECT
        ms.I = 5000;  // NO EFFECT
        ms.IV = 6000; // NO EFFECT
    }
    
    // In struct instance fields (including instance volatile and instance readonly) must be fully assigned before control leaves
    // parameterized instance constructor OR : this()
    public MyStruct(string sp) : this()
    {
        Console.WriteLine("\nexplcit instance parameterless constructor invoked by calling parameterless constructor call\n");    
        S = 2222;
        SV = 3333;
        I = 5555;  
        IV = 6666; 
    }    
}

struct MainStruct
{
    static void Main()
    {
        MyStruct ms = new MyStruct("parameterized");

        Console.WriteLine("read-only instance property C accessing const: {0} \n", ms.C);

        Console.WriteLine("instance property S accessing static: {0} \n", ms.S);

        Console.WriteLine("instance property SV accessing static volatile: {0} \n", ms.SV);

        Console.WriteLine("read-only instance property SR accessing static readonly: {0} \n", ms.SR);   
         
        Console.WriteLine("instance property I accessing instance: {0} \n", ms.I);

        Console.WriteLine("instance property IV accessing instance volatile: {0} \n", ms.IV);

        Console.WriteLine("read-only instance property IR accessing instance readonly: {0} \n", ms.IR);       
    }
}