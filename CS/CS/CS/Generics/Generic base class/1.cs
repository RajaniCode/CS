// Generic base class


using System;

class G<T>
{
    T t;
   
    public G(T tp)
    {
        t = tp;
    }

    public void methodT()
    {
        Console.WriteLine("\nType is: {0}\n", typeof(T));
    }

    public T methodt()
    {
        return t;
    }
}

class G2<T> : G<T>
{
    public G2(T tp) : base(tp)
    {
        
    }           
}

class MainClass
{
    static void Main()
    {
        G2<string> G2s = new G2<string>("Hello");

        G2s.methodT();

        Console.WriteLine("\nObject value is: {0}\n", G2s.methodt()); 
    }
}