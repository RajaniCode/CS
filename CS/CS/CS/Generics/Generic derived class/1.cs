// Generic derived class


using System;

class BaseClass
{
    string s;

    public BaseClass(string sp)
    {
        s = sp;
    }

    public void methodstring()
    {
        Console.WriteLine("\nType is: {0}\n", s.GetType());
    }

    public string methods()
    {
        return s;
    }
}

class G<T> : BaseClass
{
    T t;
    
    public G(string s, T tp) : base(s)
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

class MainClass
{
    static void Main()
    {
        G<int> Gi = new G<int>("Hello", 100);

        Gi.methodstring();
        
        Console.WriteLine("\nObject value is: {0}\n", Gi.methods());

        Gi.methodT();
        
        Console.WriteLine("\nObject value is: {0}\n", Gi.methodt());
    }
}
