// Properties in class // static properties // static property [except read-only] can be assigned in static constructor

// static property [except read-only] can be assigned in static constructor 

// static property [except read-only] &
// [**EXCEPT that accessing instance field (including instance volatile) [throws System.NullReferenceException]] *{NOT IN struct}* 
// can be assigned in instance constructor


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
        Console.WriteLine("\nexplicit static parameterless constructor atomatically invoked\n");

        s = 20;
        sv = 30;
        sr = 40;
        mc.i = 50;
        mc.iv = 60;
        // mc.ir = 70; // NOT POSSIBLE because ir is instance readonly [which can be accessed ONLY in instance constructor]
        
        S = 2000;
        SV = 3000;
        I = 5000;
        IV = 6000;
    } 

    public MyClass()
    {  
        Console.WriteLine("\nexplicit instance parameterless constructor invoked by instance parameterless constructor call\n");       
        
        MyClass mc = this;
        S = 2222;
        SV = 3333;
        // I = 5555;  // *NOT POSSIBLE because throws System.NullReferenceException
        // IV = 6666; // *NOT POSSIBLE because throws System.NullReferenceException   
    }             
}

class MainClass
{
    static void Main()
    {
        Console.WriteLine("read-only static property C accessing const: {0} \n", MyClass.C);
             
        Console.WriteLine("static property S accessing static: {0} \n", MyClass.S);

        Console.WriteLine("static property SV accessing static volatile: {0} \n", MyClass.SV);

        Console.WriteLine("read-only static property SR accessing static readonly: {0} \n", MyClass.SR); 
       
        Console.WriteLine("static property I accessing instance: {0} \n", MyClass.I);

        Console.WriteLine("static property IV accessing instance volatile: {0} \n", MyClass.IV);

        Console.WriteLine("read-only static property IR accessing instance readonly: {0} \n", MyClass.IR);    

        MyClass mc = new MyClass();

        Console.WriteLine("read-only static property C accessing const: {0} \n", MyClass.C);
             
        Console.WriteLine("static property S accessing static: {0} \n", MyClass.S);

        Console.WriteLine("static property SV accessing static volatile: {0} \n", MyClass.SV);

        Console.WriteLine("read-only static property SR accessing static readonly: {0} \n", MyClass.SR); 
       
        Console.WriteLine("static property I accessing instance: {0} \n", MyClass.I);

        Console.WriteLine("static property IV accessing instance volatile: {0} \n", MyClass.IV);

        Console.WriteLine("read-only static property IR accessing instance readonly: {0} \n", MyClass.IR);               
    }
}