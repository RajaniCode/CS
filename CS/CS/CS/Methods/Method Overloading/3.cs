// Method Overloading // instance method // Note: return type difference is not enough


using System;

class MyClass
{
    public void myMethod(sbyte a)
    {
        Console.WriteLine("Parameter sbyte: a = {0}", a);
    }

    public void myMethod(byte a)
    {
        Console.WriteLine("Parameter byte: a = {0}", a);
    }

    public void myMethod(short a)
    {
        Console.WriteLine("Parameter short: a = {0}", a);
    }
  
    public void myMethod(ushort a)
    {
        Console.WriteLine("Parameters ushort: a = {0}", a);
    }

    public void myMethod(int a)
    {
        Console.WriteLine("Parameter int: a = {0}", a);
    }

    public void myMethod(uint a)
    {
        Console.WriteLine("Parameter unint: a = {0}", a);
    }   

    public void myMethod(long a)
    {
        Console.WriteLine("Parameter long: a = {0}", a);
    } 
    
    public void myMethod(ulong a)
    {
        Console.WriteLine("Parameter ulong: a = {0}", a);
    } 

    public void myMethod(float a)
    {
        Console.WriteLine("Parameter float: a = {0}", a);
    } 
    
    public void myMethod(double a)
    {
        Console.WriteLine("Parameter double: a = {0}", a);
    }

    public void myMethod(decimal a)
    {
        Console.WriteLine("Parameter decimal: a = {0}", a);
    }  
}


class MainClass
{
    static void Main()
    {
        MyClass mc = new MyClass();
    
        Console.WriteLine("# 1");
        mc.myMethod(0);  // Note: will call only int
        mc.myMethod(-1); // Note: will call only int 
       
        Console.WriteLine("# 2");
        mc.myMethod(0.0);  // Note: will call only double
        mc.myMethod(-1.0); // Note: will call only double                  
    }
}