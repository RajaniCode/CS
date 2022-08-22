// Properties in struct // static properties and instance properties

// two (or more) different properties [even if one is static and the other is instance] can access the same variable although unusual


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

    public static int C1  
    {        
        get
        {
           return c;
        }     
    }

    public static int S1 
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
     
    public static int SV1  
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

    public static int SR1  
    {        
        get
        {
           return sr;
        }       
    }

    static MyStruct ms = new MyStruct();

    public static int I1 
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
     
    public static int IV1  
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

    public static int IR1  
    {        
        get
        {
           return ms.ir;
        }       
    }

    public int C2  
    {        
        get
        {
           return c;
        }     
    }

    public int S2 
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
     
    public int SV2  
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

    public int SR2  
    {        
        get
        {
           return sr;
        }       
    }

  

    public int I2 
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
     
    public int IV2  
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

    public int IR2  
    {        
        get
        {
           return ir;
        }       
    }

    static MyStruct()
    {
        s = 201;
        sv = 301;
        sr = 401;
        ms.i = 501;
        ms.iv = 601;
        // ms.ir = 701; // *NOT POSSIBLE because instance readonly ONLY in instance [parameterized in struct] constructor
        Console.WriteLine("\nstatic parameterless constructor atomatically invoked\n");
    } 

    // In struct instance fields (including instance volatile and instance readonly) must be fully assigned before control leaves
    // parameterized instance constructor OR : this()
    public MyStruct(string sp)
    {
        s = 202;
        sv = 302;
        // sr = 402; // *NOT POSSIBLE because static readonly ONLY in struct constructor
        i = 502;
        iv = 602;
        ir = 702; 
        Console.WriteLine("\ninstance parameterless constructor invoked by calling parameterless constructor call\n");
    }         
}

struct MainStruct
{
    static void Main()
    {
        Console.WriteLine("read-only static property C1 accessing const: {0} \n", MyStruct.C1);

        Console.WriteLine("static property S1 accessing static: {0} \n", MyStruct.S1);

        Console.WriteLine("static property SV1 accessing static volatile: {0} \n", MyStruct.SV1);

        Console.WriteLine("read-only static property SR accessing static readonly: {0} \n", MyStruct.SR1);   
         
        Console.WriteLine("static property I1 accessing instance: {0} \n", MyStruct.I1);

        Console.WriteLine("static property IV1 accessing instance volatile: {0} \n", MyStruct.IV1);

        Console.WriteLine("read-only static property IR1 accessing instance readonly: {0} \n", MyStruct.IR1);     


        MyStruct ms = new MyStruct("parameterized");

        Console.WriteLine("read-only instance property C2 accessing const: {0} \n", ms.C2);
         
        Console.WriteLine("instance property S2 accessing static: {0} \n", ms.S2);

        Console.WriteLine("instance property SV2 accessing static volatile: {0} \n", ms.SV2);

        Console.WriteLine("read-only instance property SR2 accessing static readonly: {0} \n", ms.SR2);   
         
        Console.WriteLine("instance property I2 accessing instance: {0} \n", ms.I2);

        Console.WriteLine("static instance IV2 accessing instance volatile: {0} \n", ms.IV2);

        Console.WriteLine("read-only static instance IR2 accessing instance readonly: {0} \n", ms.IR2);   
    }
}