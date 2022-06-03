// overriding virtual in generic class


using System;

class G<T>
{
    public T t;
   
    public G(T tp)
    {
        t = tp;
    }

    public virtual T virtualMethodTt()
    {
        Console.WriteLine("\nvirtualMethodTt() in base class G<T>\n");
        Console.WriteLine("\nType is: {0}\n", typeof(T));
        return t;
    }
}

class G2<T> : G<T>
{
    public G2(T tp) : base(tp)
    {

    }

    public override T virtualMethodTt()
    {   
        Console.WriteLine("\nvirtualMethodTt() overridden in derived class G2<T>\n");
        Console.WriteLine("\nType is: {0}\n", typeof(T));
        return t;
    }
    
}

class MainClass
{
    static void Main()
    {
        G<string> Gi  = new G<string>("Hello");
        
        Console.WriteLine("\nObject value is: {0}\n", Gi.virtualMethodTt());

        G2<int> G2i = new G2<int>(100);
        
        Console.WriteLine("\nObject value is: {0}\n", G2i.virtualMethodTt());
    }
}

        

    