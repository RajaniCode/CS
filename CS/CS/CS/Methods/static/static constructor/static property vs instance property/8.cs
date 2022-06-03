// Properties in class // static properties and instance properties

// two (or more) different properties [even if one is static and the other is instance] can access the same variable although unusual


using System;

class MyClass
{
    const int c = 1;
   
    static int s = 2;
    
    static int sv = 3;
    
    static readonly int sr = 4; 

    int i = 5;
    
    volatile int iv = 6;

    readonly int ir = 7;

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

    static MyClass mc = new MyClass();

    public static int I1 
    {        
        get
        {
           return mc.i;
        }  

        set
        {
            mc.i = value;          
        }   
    }
     
    public static int IV1  
    {        
        get
        {
           return mc.iv;
        }  

        set
        {
            mc.iv = value;          
        }   
    }

    public static int IR1  
    {        
        get
        {
           return mc.ir;
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

    static MyClass()
    {
        s = 201;
        sv = 301;
        sr = 401;
        mc.i = 501;
        mc.iv = 601;
        // mc.ir = 701; // *NOT POSSIBLE because instance readonly ONLY in instance constructor
        Console.WriteLine("\nstatic parameterless constructor atomatically invoked\n");
    } 

    public MyClass()
    {
        s = 202;
        sv = 302;
        // sr = 402; // *NOT POSSIBLE because static readonly ONLY in struct constructor
        i = 502;
        iv = 602;
        ir = 702; 
        Console.WriteLine("\nexplicit instance parameterless constructor invoked by parameterless constructor call\n");
    }         
}

class MainClass
{
    static void Main()
    {
        Console.WriteLine("read-only static property C1 accessing const: {0} \n", MyClass.C1);

        Console.WriteLine("static property S1 accessing static: {0} \n", MyClass.S1);

        Console.WriteLine("static property SV1 accessing static volatile: {0} \n", MyClass.SV1);

        Console.WriteLine("read-only static property SR accessing static readonly: {0} \n", MyClass.SR1);   
         
        Console.WriteLine("static property I1 accessing instance: {0} \n", MyClass.I1);

        Console.WriteLine("static property IV1 accessing instance volatile: {0} \n", MyClass.IV1);

        Console.WriteLine("read-only static property IR1 accessing instance readonly: {0} \n", MyClass.IR1);     



        MyClass mc = new MyClass();

        Console.WriteLine("read-only instance property C2 accessing const: {0} \n", mc.C2);

        Console.WriteLine("instance property S2 accessing static: {0} \n", mc.S2);

        Console.WriteLine("instance property SV2 accessing static volatile: {0} \n", mc.SV2);

        Console.WriteLine("read-only instance property SR2 accessing static readonly: {0} \n", mc.SR2);   
         
        Console.WriteLine("instance property I2 accessing instance: {0} \n", mc.I2);

        Console.WriteLine("static instance IV2 accessing instance volatile: {0} \n", mc.IV2);

        Console.WriteLine("read-only static instance IR2 accessing instance readonly: {0} \n", mc.IR2);     
    }
}