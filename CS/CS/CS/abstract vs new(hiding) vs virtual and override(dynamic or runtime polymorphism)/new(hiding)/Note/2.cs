// virtaul and new // can hide only non-abstract


using System;

class A1
{
    public virtual void method() {}    
}

class A2 : A1
{
    public virtual new void method() {}       
}
   
class A3 : A2
{
    public override void method()
    {
        Console.WriteLine("method() overridden");      
    }  
}

class MainClass
{
    static void Main()
    {
        A3 a3 = new A3();
        a3.method();
    }
}