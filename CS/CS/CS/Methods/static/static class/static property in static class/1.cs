// Properties in class // static properties in static class [ONLY static members]

// staic property can access [const as read-only static property] DIRECTLY  

// staic property can access [static fields] including [static volatile] AND [static readonly as read-only static property] DIRECTLY 

// static constructor can access [static fields] including [static volatile] AND [static readonly] DIRECTLY 


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
        s = 20;
        sv = 30;
        sr = 40;
        Console.WriteLine("\nexplicit static parameterless constructor atomatically invoked\n");
    }    
}

static class MainClass // can be static
{
    static void Main()
    {
        Console.WriteLine("read-only static property C accessing const: {0} \n", MyClass.C);

        MyClass.S = 200; 
         
        Console.WriteLine("static property S accessing static: {0} \n", MyClass.S);

        MyClass.SV = 300;

        Console.WriteLine("static property SV accessing static volatile: {0} \n", MyClass.SV);

        Console.WriteLine("read-only static property SR accessing static readonly: {0} \n", MyClass.SR);            
    }
}