// instance properties in interface, private and explicit implementation by class 

// instance property [except read-only] can be assigned in static constructor 
// USING: mc CREATED INSIDE class as: static MyClass mc = new MyClass(); 
// **{AND USING: mi CREATED INSIDE static constructor as: MyInterface mi = (MyInterface)mc;}**
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

class MyClass : MyInterface 
{
    const int c = 1;
   
    static int s = 2;
    
    static int sv = 3;
    
    static readonly int sr = 4; 

    int i = 5;
    
    volatile int iv = 6;

    readonly int ir = 7;


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

    static MyClass mc = new MyClass();

    static MyClass()
    {
        Console.WriteLine("\nexplicit static parameterless constructor atomatically invoked\n");
      
        MyInterface mi = (MyInterface)mc; // **NOTE
        
        mi.S = 2000;
        mi.SV = 3000;
        mi.I = 5000;  // NO EFFECT
        mi.IV = 6000; // NO EFFECT
    }
    
    public MyClass()
    {
       Console.WriteLine("\nexplicit instance parameterless constructor invoked by parameterless constructor call\n");    
    }    
}

class MainClass
{
    static void Main()
    {
        MyClass mc = new MyClass();

        MyInterface mi = (MyInterface)mc; 

        Console.WriteLine("read-only instance property C accessing const: {0} \n", mi.C);

        Console.WriteLine("instance property S accessing static: {0} \n", mi.S);

        Console.WriteLine("instance property SV accessing static volatile: {0} \n", mi.SV);

        Console.WriteLine("read-only instance property SR accessing static readonly: {0} \n", mi.SR);   
         
        Console.WriteLine("instance property I accessing instance: {0} \n", mi.I);

        Console.WriteLine("instance property IV accessing instance volatile: {0} \n", mi.IV);

        Console.WriteLine("read-only instance property IR accessing instance readonly: {0} \n", mi.IR);       
    }
}