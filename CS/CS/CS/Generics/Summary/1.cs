// Generic class


using System;

class G<T>
{
    T _t;

    public G(T _tp)
    {
        _t = _tp;
    }

    internal T ShowObject()
    {
        return _t;
    }

    internal void ShowType()
    {
        Console.WriteLine("The type is {0}", typeof(T));
    }
}

class MainClass
{
    static void Main()
    {
        G<int> intG = new G<int>(100);

        int intNumber = intG.ShowObject();

        Console.WriteLine("The value is {0}", intNumber);

        intG.ShowType();

        G<string> stringG = new G<string>("100%");

        string stringNumber = stringG.ShowObject();

        Console.WriteLine("The value is {0}", stringNumber);

        stringG.ShowType();
    }
}