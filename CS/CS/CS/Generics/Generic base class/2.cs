// Generic base class // derived class can add its own types


using System;

class G<T>
{
    public T t;
   
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

class G2<T, T2> : G<T> 
{
    T2 t2;

    public G2(T tp, T2 tp2) : base(tp)
    {
        t2 = tp2; 
    }

    public void methodT2()
    {
        Console.WriteLine("\nType is: {0}\n", typeof(T2));
    }

    public T2 methodt2()
    {
        return t2;
    }           
}

class MainClass
{
    static void Main()
    {
        G2<string, int> G2si = new G2<string, int>("Hello", 100);

        G2si.methodT();

        Console.WriteLine("\nObject value is: {0}\n", G2si.methodt()); 

        G2si.methodT2();

        Console.WriteLine("\nObject value is: {0}\n", G2si.methodt2()); 
    }
}