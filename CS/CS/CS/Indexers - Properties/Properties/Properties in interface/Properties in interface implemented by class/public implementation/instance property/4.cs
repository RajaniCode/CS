// instance properties in interface, public implementation by class

// two (or more) different properties [ONLY instance properties in interface] can access the same variable although unusual


using System;

interface MyInterface
{
    int C1
    {
        get;
    }

    int S1
    {
        get;
        set;
    }

    int SV1
    {
        get;
        set;
    }
    
    int SR1
    {
        get;
    }

    int I1
    {
        get;
        set;
    }
   
    int IV1
    {
        get;
        set;
    }

    int IR1
    {
        get;
    }

     int C2
    {
        get;
    }

    int S2
    {
        get;
        set;
    }

    int SV2
    {
        get;
        set;
    }
    
    int SR2
    {
        get;
    }

    int I2
    {
        get;
        set;
    }
   
    int IV2
    {
        get;
        set;
    }

    int IR2
    {
        get;
    }
}

class MyClass : MyInterface 
{
    const int c = 1;
   
    static int s = 2;
    
    static int sv = 3;
    
    static readonly int sr = 4; 

    int i = 5;
    
    volatile int iv = 6;

    readonly int ir = 7;

    public int C1  
    {        
        get
        {
           return c;
        }     
    }

    public int S1 
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
     
    public int SV1  
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

    public int SR1  
    {        
        get
        {
           return sr;
        }       
    }  

    public int I1 
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
     
    public int IV1  
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

    public int IR1  
    {        
        get
        {
           return ir;
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

    static MyClass mc = new MyClass();

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
        MyClass mc = new MyClass();

        Console.WriteLine("read-only instance property C1 accessing const: {0} \n", mc.C1);

        Console.WriteLine("instance property S1 accessing static: {0} \n", mc.S1);

        Console.WriteLine("instance property SV1 accessing static volatile: {0} \n", mc.SV1);

        Console.WriteLine("read-only instance property SR1 accessing static readonly: {0} \n", mc.SR1);   
         
        Console.WriteLine("instance property I1 accessing instance: {0} \n", mc.I1);

        Console.WriteLine("static instance IV1 accessing instance volatile: {0} \n", mc.IV1);

        Console.WriteLine("read-only static instance IR1 accessing instance readonly: {0} \n", mc.IR1);  


        Console.WriteLine("read-only instance property C2 accessing const: {0} \n", mc.C2);

        Console.WriteLine("instance property S2 accessing static: {0} \n", mc.S2);

        Console.WriteLine("instance property SV2 accessing static volatile: {0} \n", mc.SV2);

        Console.WriteLine("read-only instance property SR2 accessing static readonly: {0} \n", mc.SR2);   

        Console.WriteLine("instance property I2 accessing instance: {0} \n", mc.I2);

        Console.WriteLine("static instance IV2 accessing instance volatile: {0} \n", mc.IV2);

        Console.WriteLine("read-only static instance IR2 accessing instance readonly: {0} \n", mc.IR2);      
    }
}