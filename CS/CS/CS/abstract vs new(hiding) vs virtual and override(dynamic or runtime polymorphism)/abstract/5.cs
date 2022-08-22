// abstract class

// abstract class constructors can be overloaded using derived class constructor with base()


using System;

abstract class BaseClass 
{
    public static int s = 1;
    public int i = 2;
    
    public BaseClass()
    {
       s = 555;
       i= 777;
    }

    public BaseClass(int a)
    {
        s = a;
        i = a;
    }

    public BaseClass(int a, int b)
    {
        s = a;
        i = b;
    }

    public void instanceMethod() 
    {       
        Console.WriteLine("instanceMethod() in abstract BaseClass: s = {0}, i = {1}\n", s, i); 
    }

    public static void staticMethod(BaseClass bcp) 
    {       
        Console.WriteLine("staticMethod() in abstract BaseClass: s = {0}, bcp.i = {1}\n", s, bcp.i); 
    }
    
    public abstract void abstractMethod();

    public virtual void virtualMethod()
    {
        Console.WriteLine("virtualMethod() in abstract BaseClass: s = {0}, i = {1}\n", s, i);
    }
}

class DerivedClass : BaseClass
{
    public DerivedClass()
    {

    }

    public DerivedClass(int a) : base(a)
    {

    }

    public DerivedClass(int a, int b) : base(a, b)
    {

    }

    public new void instanceMethod() 
    {       
        Console.WriteLine("instanceMethod() in Derived Class: s = {0}, i = {1}\n", s, i); 
    }

    public new static void staticMethod(BaseClass bcp) 
    {       
        Console.WriteLine("staticMethod() in Derived Class: s = {0}, bcp.i = {1}\n", s, bcp.i); 
    }
    

    public override void abstractMethod() 
    {
        Console.WriteLine("abstractMethod() in Derived Class: s = {0}, i = {1}\n", s, i);
    } 

    public override void virtualMethod()
    {
        Console.WriteLine("virtualMethod() in Derived Class: s = {0}, i = {1}\n", s, i);
    }     
}

class MainClass
{
    static void Main()
    {
       BaseClass[] bc = new BaseClass[3];       // reference array of abstract class 
       bc[0] = new DerivedClass();               
       bc[1] = new DerivedClass(100);           // parameters for constructors 
       bc[2] = new DerivedClass(3,4);           // parameters for constructors
       

       for(int i=0; i<bc.Length; i++) 
           bc[i].instanceMethod();

       Console.WriteLine("\n");
            
       for(int i=0; i<bc.Length; i++) 
           BaseClass.staticMethod(bc[i]); 

       Console.WriteLine("\n");

       for(int i=0; i<bc.Length; i++) 
           bc[i].abstractMethod(); 
        
       Console.WriteLine("\n");

       for(int i=0; i<bc.Length; i++) 
           bc[i].virtualMethod();
     }
}