// instance properties in interface, private and explicit implementation by struct

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

struct MyStruct : MyInterface 
{
    const int c = 1;
   
    static int s = 2;
    
    static int sv = 3;
    
    static readonly int sr = 4; 

    int i; // cannot have instance field initializers in structs
    
    volatile int iv; // cannot have instance field initializers in structs

    readonly int ir; // cannot have instance field initializers in structs

    int MyInterface.C1  
    {        
        get
        {
           return c;
        }     
    }

    int MyInterface.S1 
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
     
    int MyInterface.SV1  
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

    int MyInterface.SR1  
    {        
        get
        {
           return sr;
        }       
    }  

    int MyInterface.I1 
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
     
    int MyInterface.IV1  
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

    int MyInterface.IR1  
    {        
        get
        {
           return ir;
        }       
    }

    int MyInterface.C2  
    {        
        get
        {
           return c;
        }     
    }

    int MyInterface.S2 
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
     
    int MyInterface.SV2  
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

   int MyInterface.SR2  
    {        
        get
        {
           return sr;
        }       
    }  

    int MyInterface.I2 
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
     
    int MyInterface.IV2  
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

    int MyInterface.IR2  
    {        
        get
        {
           return ir;
        }       
    }
 
    static MyStruct ms = new MyStruct();

    static MyStruct()
    {
        s = 201;
        sv = 301;
        sr = 401;
        ms.i = 501;
        ms.iv = 601;
        // ms.ir = 701; // *NOT POSSIBLE because instance readonly ONLY in instance [parameterized in struct] constructor
        Console.WriteLine("\nstatic parameterless constructor atomatically invoked\n");
    } 

    // In struct instance fields (including instance volatile and instance readonly) must be fully assigned before control leaves
    // parameterized instance constructor OR : this()
    public MyStruct(string sp)
    {
        s = 202;
        sv = 302;
        // sr = 402; // *NOT POSSIBLE because static readonly ONLY in struct constructor
        i = 502;
        iv = 602;
        ir = 702; 
        Console.WriteLine("\ninstance parameterless constructor invoked by calling parameterless constructor call\n");
    }         
}

struct MainStruct
{
    static void Main()
    {
        MyStruct ms = new MyStruct("parameterized");

        MyInterface mi = (MyInterface)ms;

        Console.WriteLine("read-only instance property C1 accessing const: {0} \n", mi.C1);
                
        Console.WriteLine("instance property S1 accessing static: {0} \n", mi.S1);
       
        Console.WriteLine("instance property SV1 accessing static volatile: {0} \n", mi.SV1);

        Console.WriteLine("read-only instance property SR1 accessing static readonly: {0} \n", mi.SR1);   
           
        Console.WriteLine("instance property I1 accessing instance: {0} \n", mi.I1);

        Console.WriteLine("static instance IV1 accessing instance volatile: {0} \n", mi.IV1);

        Console.WriteLine("read-only static instance IR1 accessing instance readonly: {0} \n", mi.IR1);
        

        Console.WriteLine("read-only instance property C2 accessing const: {0} \n", mi.C2);

        Console.WriteLine("instance property S2 accessing static: {0} \n", mi.S2);

        Console.WriteLine("instance property SV2 accessing static volatile: {0} \n", mi.SV2);

        Console.WriteLine("read-only instance property SR2 accessing static readonly: {0} \n", mi.SR2);   

        Console.WriteLine("instance property I2 accessing instance: {0} \n", mi.I2);

        Console.WriteLine("static instance IV2 accessing instance volatile: {0} \n", mi.IV2);

        Console.WriteLine("read-only static instance IR2 accessing instance readonly: {0} \n", mi.IR2);   
    }
}