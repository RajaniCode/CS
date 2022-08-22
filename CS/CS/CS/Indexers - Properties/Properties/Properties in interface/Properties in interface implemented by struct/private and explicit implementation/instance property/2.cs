// instance properties in interface, private and explicit implementation by struct

// instance property [except read-only] can be assigned in static constructor 
// USING: ms CREATED INSIDE struct as: static MyStruct ms = new MyStruct(); 
// **{AND USING: mi CREATED INSIDE static constructor as: MyInterface mi = (MyInterface)ms;}**
// [NOT USEFUL for instance property accessing instance fields (including instance volatile)]
// [NOT USEFUL if simultaneously assigned in instance constructor]


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

    static MyStruct ms = new MyStruct();

    static MyStruct()
    {
        Console.WriteLine("\nexplicit static parameterless constructor atomatically invoked\n");
      
        MyInterface mi = (MyInterface)ms;

        mi.S = 2000;
        mi.SV = 3000;
        mi.I = 5000;  // NO EFFECT
        mi.IV = 6000; // NO EFFECT
    }
    
    // In struct instance fields (including instance volatile and instance readonly) must be fully assigned before control leaves
    // parameterized instance constructor OR : this()
    public MyStruct(string sp) : this()
    {
        Console.WriteLine("\nparameterized instance constructor invoked by calling parameterless constructor call\n");    
    }    
}

struct MainStruct
{
    static void Main()
    {
        MyStruct ms = new MyStruct("parameterized");

        MyInterface mi =(MyInterface)ms;

        Console.WriteLine("read-only instance property C accessing const: {0} \n", mi.C);

        Console.WriteLine("instance property S accessing static: {0} \n", mi.S);

        Console.WriteLine("instance property SV accessing static volatile: {0} \n", mi.SV);

        Console.WriteLine("read-only instance property SR accessing static readonly: {0} \n", mi.SR);   
         
        Console.WriteLine("instance property I accessing instance: {0} \n", mi.I);

        Console.WriteLine("instance property IV accessing instance volatile: {0} \n", mi.IV);

        Console.WriteLine("read-only instance property IR accessing instance readonly: {0} \n", mi.IR);       
    }
}