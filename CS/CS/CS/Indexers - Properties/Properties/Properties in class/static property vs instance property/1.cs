// Properties in class // static properties

// staic property can access [const as read-only static property] DIRECTLY  

// staic property can access ONLY [static fields] including [static volatile] AND [static readonly as read-only static property] DIRECTLY 

// static constructor can access ONLY [static fields] including [static volatile] AND [static readonly] DIRECTLY 
 

// staic property can access [instance fields] including [instance volatile] AND [instance readonly as read-only static property] 
// USING mc CREATED INSIDE class as: static MyClass mc = new MyClass(); 

// static constructor can access [instance fields] including [instance volatile] BUT CANNOT access [*instance readonly] AT ALL  
// USING mc CREATED INSIDE class as: static MyClass mc = new MyClass(); 


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

    static MyClass mc = new MyClass();

    public static int I 
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
     
    public static int IV  
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

    public static int IR  
    {        
        get
        {
           return mc.ir;
        }       
    }
    
    static MyClass()
    {
        s = 20;
        sv = 30;
        sr = 40;
        mc.i = 50;
        mc.iv = 60;
        // mc.ir = 70; // *NOT POSSIBLE because instance readonly ONLY in instance constructor
        Console.WriteLine("\nexplicit static parameterless constructor atomatically invoked\n");
    }    
}

class MainClass
{
    static void Main()
    {
        Console.WriteLine("read-only static property C accessing const: {0} \n", MyClass.C);

        MyClass.S = 200; 
         
        Console.WriteLine("static property S accessing static: {0} \n", MyClass.S);

        MyClass.SV = 300;

        Console.WriteLine("static property SV accessing static volatile: {0} \n", MyClass.SV);

        Console.WriteLine("read-only static property SR accessing static readonly: {0} \n", MyClass.SR);   

        MyClass.I = 500; 
         
        Console.WriteLine("static property I accessing instance: {0} \n", MyClass.I);

        MyClass.IV = 600;

        Console.WriteLine("static property IV accessing instance volatile: {0} \n", MyClass.IV);

        Console.WriteLine("read-only static property IR accessing instance readonly: {0} \n", MyClass.IR);       
    }
}