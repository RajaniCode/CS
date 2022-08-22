// Generic class with two type parameters


using System;

class G<T1, T2>
{
    T1 t1;

    T2 t2;

    public G(T1 t1p, T2 t2p)
    {
        t1 = t1p;
        t2 = t2p;
    }

    public void methodT()
    {
        Console.WriteLine("\nType is: {0}\n", typeof(T1));
        Console.WriteLine("\nType is: {0}\n", typeof(T2));
    }

    public T1 methodt1()
    {
        return t1;
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
        G<int, string> Gis;
        Gis = new G<int, string>(100, "Bill");

        Gis.methodT();

        Console.WriteLine("\nObject value is: {0}\n", Gis.methodt1());

        Console.WriteLine("\nObject value is: {0}\n", Gis.methodt2());
    }
}
        
     