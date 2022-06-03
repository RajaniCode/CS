// Method Overloading // ref and out //  cannot define overloaded methods that differ only on ref and out


using System;

class MyClass
{
    
    public void myMethod(ref int ap)
    {  
        ap = ap * ap;            
    }

    public void myMethod(int ap, out int bp) 
    {  
        ap = -ap; // Note: no effect
        bp = 10; // Note: should be assigned, not unassigned like bp = - bp;           
    }
} 


class MainClass
{
    static void Main()
    {
        int a = 5;
         
        MyClass mc = new MyClass();
   
        Console.WriteLine("Before passing: a = {0}", a);

        mc.myMethod(ref a);        
   
        Console.WriteLine("After passing (ref a): a = {0}", a);

        int b; // Note: unassigned

        mc.myMethod(a, out b);

        Console.WriteLine("After passing (a, out b) a = {0}, b = {1}", a, b);
    }
}
    
