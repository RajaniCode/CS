// runtime type identification // as operator

using System;

class A
{
 
}

class B : A
{
    static void Main()
    {
        A a = new A();
        B b = new B();
 
        
        b = a as B;  // cast, if possible

        if(b==null)
            Console.WriteLine("a cannot be cast as B");
        else
            Console.WriteLine("a can be cast as B"); // possible if // a = b; b = a as B;  
    }
}   

        