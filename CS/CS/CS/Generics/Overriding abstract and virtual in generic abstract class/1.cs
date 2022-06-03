// overriding abstract and virtual in generic abstract class


using System;

abstract class G<T>
{
    public T t;
   
    public G(T tp)
    {
        t = tp;
    }

    public abstract T abstractMethodTt();

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

    public override T abstractMethodTt()
    {
        Console.WriteLine("\nabstractMethodTt() overridden in derived class G2<T>\n");
        Console.WriteLine("\nType is: {0}\n", typeof(T));
        return t;
    }

    public override T virtualMethodTt()
    {      
        Console.WriteLine("\nvirtualMethodTt() overridden in derived class G2<T>\n");
        Console.WriteLine("\nType is: {0}\n", typeof(T));
        return t;
    }  

    public void basevirtualMethodTt()
    {
        Console.WriteLine(base.virtualMethodTt());        
    }
}

class MainClass
{
    static void Main()
    {
        G<string> Gi;
    
        Gi = new G2<string>("Hello"); // Note
        
        Console.WriteLine("\nObject value is: {0}\n", Gi.virtualMethodTt());
        Console.WriteLine("\nObject value is: {0}\n", Gi.abstractMethodTt());
    

        G2<int> G2i = new G2<int>(100);
        
        Console.WriteLine("\nObject value is: {0}\n", G2i.virtualMethodTt());
        Console.WriteLine("\nObject value is: {0}\n", G2i.abstractMethodTt());
        
        G2i. basevirtualMethodTt();
    }
}

        

    