// Properties in class // instance properties

// instance property can access [const as read-only instance property] DIRECTLY  

// instance property can access [static/instance fields] including [static/instance volatile] AND [static/instance readonly as read-only static property] DIRECTLY 

// instance constructor can access [static/instance fields] including [static/instance volatile] AND [instance readonly] DIRECTLY 
// BUT CANNOT access [*static readonly] AT ALL
 

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
    
    public MyClass()
    {
        s = 20;
        sv = 30;
        // sr = 40; // *NOT POSSIBLE because static readonly ONLY is static constructor
        i = 50;
        iv = 60;
        ir = 70; 
        Console.WriteLine("\nexplicit instance parameterless constructor invoked by calling parameterless constructor call\n");
    }    
}

class MainClass
{
    static void Main()
    {
        MyClass mc = new MyClass();

        Console.WriteLine("read-only instance property C accessing const: {0} \n", mc.C);

        mc.S = 200; 
         
        Console.WriteLine("instance property S accessing static: {0} \n", mc.S);

        mc.SV = 300;

        Console.WriteLine("instance property SV accessing static volatile: {0} \n", mc.SV);

        Console.WriteLine("read-only instance property SR accessing static readonly: {0} \n", mc.SR);   

        mc.I = 500; 
         
        Console.WriteLine("instance property I accessing instance: {0} \n", mc.I);

        mc.IV = 600;

        Console.WriteLine("instance property IV accessing instance volatile: {0} \n", mc.IV);

        Console.WriteLine("read-only instance property IR accessing instance readonly: {0} \n", mc.IR);       
    }
}