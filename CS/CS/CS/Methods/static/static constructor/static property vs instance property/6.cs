// Properties in class // instance properties

// instance property [except read-only] can be assigned in static constructor 
// USING: mc CREATED INSIDE class as: static MyClass mc = new MyClass(); 
// [NOT USEFUL for instance property accessing instance fields (including instance volatile)]
// [NOT USEFUL if simultaneously assigned in instance constructor]

// instance property [except read-only] can be assigned in instance constructor


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

    static MyClass mc = new MyClass();

    static MyClass()
    {
        Console.WriteLine("\nexplicit static parameterless constructor atomatically invoked\n");
      
        mc.S = 2000;  // NO EFFECT
        mc.SV = 3000; // NO EFFECT
        mc.I = 5000;  // NO EFFECT
        mc.IV = 6000; // NO EFFECT
    }
    
    public MyClass()
    {
        Console.WriteLine("\nexplicit instance parameterless constructor invoked by parameterless constructor call\n");    
        S = 2222;
        SV = 3333;
        I = 5555;  
        IV = 6666; 
    }    
}

class MainClass
{
    static void Main()
    {
        MyClass mc = new MyClass();

        Console.WriteLine("read-only instance property C accessing const: {0} \n", mc.C);

        Console.WriteLine("instance property S accessing static: {0} \n", mc.S);

        Console.WriteLine("instance property SV accessing static volatile: {0} \n", mc.SV);

        Console.WriteLine("read-only instance property SR accessing static readonly: {0} \n", mc.SR);   
         
        Console.WriteLine("instance property I accessing instance: {0} \n", mc.I);

        Console.WriteLine("instance property IV accessing instance volatile: {0} \n", mc.IV);

        Console.WriteLine("read-only instance property IR accessing instance readonly: {0} \n", mc.IR);       
    }
}