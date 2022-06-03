// Generic class // using constraint to establish relationship between two type parameters

using System;

class A
{

}

class B : A
{

}

class G<T1, T2> where T2 : T1
{

}

class MainClass
{
    static void Main()
    {
        G<A, B> GAB = new G<A, B>();

        // G<B, A> GBA = new G<B, A>(); // NOT POSSIBLE because A doen't extent B
    } 
}
    