// Properties in class // static properties in static class // static property [except read-only] can be assigned in static constructor

// static property [except read-only] can be assigned in static constructor 


using System;

static class MyClass
{
    const int c = 1;
   
    static int s = 2;
    
    static int sv = 3;
    
    static readonly int sr = 4; 

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

    static MyClass()
    {
        Console.WriteLine("\nexplicit static parameterless constructor atomatically invoked\n");

        s = 20;
        sv = 30;
        sr = 40;
        
        S = 2000;
        SV = 3000;       
    }                
}

static class MainClass // can be static
{
    static void Main()
    {
        Console.WriteLine("read-only static property C accessing const: {0} \n", MyClass.C);
             
        Console.WriteLine("static property S accessing static: {0} \n", MyClass.S);

        Console.WriteLine("static property SV accessing static volatile: {0} \n", MyClass.SV);

        Console.WriteLine("read-only static property SR accessing static readonly: {0} \n", MyClass.SR);             
    }
}