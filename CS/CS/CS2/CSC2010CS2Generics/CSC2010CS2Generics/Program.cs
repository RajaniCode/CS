using System;

class G
{
    object obj;

    public G(object obj)
    {
        this.obj = obj;
    }

    public object GetObject()
    {
        return obj;
    }

    public void ShowType()
    {
        Console.WriteLine("Type: " + obj.GetType());
    }
}

//Generics
class G<T>
{
    T obj;

    public G(T obj)
    {
        this.obj = obj;
    }

    public T GetObject()
    {
        return obj;
    }

    public void ShowType()
    {
        Console.WriteLine("Type: " + typeof(T));
    }
}

class MainApp
{
    static void Main()
    {
        G g = new G("Hello World!");
        string s = (string)g.GetObject();
        Console.WriteLine("Object: " + s);
        g.ShowType();

        g = new G(100);
        int i = (int)g.GetObject();
        Console.WriteLine("Object: " + i);
        g.ShowType();

        G<string> gs = new G<string>("Hello World!");
        s = gs.GetObject();
        Console.WriteLine("Object: " + s);
        gs.ShowType();

        G<int> gi = new G<int>(100);
        i = gi.GetObject();
        Console.WriteLine("Object: " + i);
        gi.ShowType();

        Console.ReadKey();
    }
}

