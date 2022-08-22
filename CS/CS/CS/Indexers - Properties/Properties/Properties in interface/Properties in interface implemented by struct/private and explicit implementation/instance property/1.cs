// instance properties in interface, private and explicit implementation by struct

// instance property can access [const as read-only instance property] DIRECTLY  

// instance property can access [static/instance fields] including [static/instance volatile] AND [static/instance readonly as read-only static property] DIRECTLY 

// instance constructor can access [static/instance fields] including [static/instance volatile] AND [instance readonly] DIRECTLY 
// BUT CANNOT access [*static readonly] AT ALL
 

using System;

interface MyInterface
{
    int C
    {
        get;
    }

    int S
    {
        get;
        set;
    }

    int SV
    {
        get;
        set;
    }
    
    int SR
    {
        get;
    }

    int I
    {
        get;
        set;
    }
   
    int IV
    {
        get;
        set;
    }

    int IR
    {
        get;
    }
}

struct MyStruct : MyInterface
{
    const int c = 1;
   
    static int s = 2;
    
    static int sv = 3;
    
    static readonly int sr = 4; 

    int i; // cannot have instance field initializers in structs
    
    volatile int iv; // cannot have instance field initializers in structs

    readonly int ir; // cannot have instance field initializers in structs


    int MyInterface.C  
    {        
        get
        {
           return c;
        }     
    }

    int MyInterface.S 
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
     
    int MyInterface.SV  
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

    int MyInterface.SR  
    {        
        get
        {
           return sr;
        }       
    }

  

    int MyInterface.I 
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
     
    int MyInterface.IV  
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

    int MyInterface.IR  
    {        
        get
        {
           return ir;
        }       
    }
    
    public MyStruct(string sp) // ONLY parameterized nstance constructor in struct
    {
        s = 20;
        sv = 30;
        // sr = 40; // *NOT POSSIBLE because static readonly ONLY is static constructor
        i = 50;
        iv = 60;
        ir = 70; 
        Console.WriteLine("\ninstance parameterless constructor invoked by calling parameterless constructor call\n");
    }    
}

struct MainStruct
{
    static void Main()
    {
        MyStruct ms = new MyStruct("parameterized");

        MyInterface mi = (MyInterface)ms;

        Console.WriteLine("read-only instance property C accessing const: {0} \n", mi.C);

        mi.S = 200; 
         
        Console.WriteLine("instance property S accessing static: {0} \n", mi.S);

        mi.SV = 300;

        Console.WriteLine("instance property SV accessing static volatile: {0} \n", mi.SV);

        Console.WriteLine("read-only instance property SR accessing static readonly: {0} \n", mi.SR);   

        mi.I = 500; 
         
        Console.WriteLine("instance property I accessing instance: {0} \n", mi.I);

        mi.IV = 600;

        Console.WriteLine("instance property IV accessing instance volatile: {0} \n", mi.IV);

        Console.WriteLine("read-only instance property IR accessing instance readonly: {0} \n", mi.IR);       
    }
}