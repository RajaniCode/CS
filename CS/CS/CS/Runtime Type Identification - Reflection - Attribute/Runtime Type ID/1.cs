// runtime type identification // is operator

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


        if(a is A)
            Console.WriteLine("a is an A");
        else
            Console.WriteLine("a is not an A");

        if(b is A)
            Console.WriteLine("b is an A");
        else
            Console.WriteLine("b is not an A");

        if(a is B)
            Console.WriteLine("a is a B");
        else
            Console.WriteLine("a is not a B"); 

        if(b is B)
            Console.WriteLine("b is a B");
        else
            Console.WriteLine("b is not a B"); 
  
        if(a is object)
            Console.WriteLine("a is an object");
        else
            Console.WriteLine("a is not an object"); 

        if(b is object)
            Console.WriteLine("b is an object");
        else
            Console.WriteLine("b is not an object"); 
    }
}
