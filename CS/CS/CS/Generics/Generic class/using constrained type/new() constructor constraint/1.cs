// Generic class // using constrained type // using new() constructor constraint


using System;

class A
{

}

class B : A
{

}

class C
{

}

class G<T> where T : new() // Note
{
    T t;

    public G()
    {
        t = new T(); // Can create an instance of the variable type 'T' ONLY if it has the new() constraint
    }
    
    public void methodT()
    {
        Console.WriteLine("methodT() in G<T>"); 
    }
}

class MainClass
{
    static void Main()
    {
        A a = new A();
        B b = new B();
        C c = new C();
     
        G<A> GA = new G<A>();

        G<B> GB = new G<B>();    

        G<C> GC = new G<C>(); 


        GA.methodT();

        GB.methodT();

        GC.methodT();
    }
}

  
