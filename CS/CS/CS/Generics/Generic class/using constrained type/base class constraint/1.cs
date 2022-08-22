// Generic class // using constrained type // using base class constraint


using System;

class A
{
    public void methodA()
    {
        Console.WriteLine("\nmethodA()\n");
    }
}

class B : A
{

}

class C
{

}

class G<T> where T : A // Note
{
    T t;

    public G(T tp)
    {
        t = tp;
    }
    
    public void methodT()
    {
        t.methodA(); // Note
    }
}

class MainClass
{
    static void Main()
    {
        A a = new A();
        B b = new B();
        C c = new C();
     
        G<A> GA = new G<A>(a);

        G<B> GB = new G<B>(b);    // POSSIBLE because B inherits A

        // G<C> GC = new G<C>(c); // NOT POSSIBLE because c does not inherit A


        GA.methodT();

        GB.methodT();
    }
}

  
