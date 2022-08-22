// Non-generic class


using System;

class NonG
{
    object _object;

    public NonG(object _objectp)
    {
        _object = _objectp;
    }

    internal object ShowObject()
    {
        return _object;
    }

    internal void ShowType()
    {
        Console.WriteLine("The type is {0}", _object.GetType());    // Note
    }
}

class MainClass
{
    static void Main()
    {
        NonG intNonG = new NonG(100);

        int intNumber = (int)intNonG.ShowObject(); // Note

        Console.WriteLine("The value is {0}", intNumber);

        intNonG.ShowType();

        NonG stringNonG = new NonG("100%");

        string stringNumber = (string)stringNonG.ShowObject(); // Note

        Console.WriteLine("The value is {0}", stringNumber);

        stringNonG.ShowType();
    }
}