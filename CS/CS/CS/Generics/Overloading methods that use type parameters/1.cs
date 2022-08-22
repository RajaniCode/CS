// Overloading methods that use type parameters

using System;

class G<T1, T2>
{
    public void overloadingMethod(T1 t1)
    {
        Console.WriteLine("\noverloadingMethod(T1 t1): Value is: {0}\n", t1);
    }

    public void overloadingMethod(T2 t2)
    {
        Console.WriteLine("\noverloadingMethod(T2 t2): Value is: {0}\n", t2);
    }
}

class MainClass
{
    static void Main()
    {
        G<int, double> Gis = new G<int, double>(); // INVALID: G<int, int> Gis = new G<int, int>();
        
        Gis.overloadingMethod(100);
    
        Gis.overloadingMethod(100.0);
    }
}