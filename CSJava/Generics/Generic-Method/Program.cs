using System;

class GenericMethod
{
    public void SetString(string s)
    {
        s += ", World!";
        Console.WriteLine ("SetString:" + s);
    }

    public void SetInt(int i)
    {
        i *= 100;
        Console.WriteLine("SetInt:" + i);
    }
    
    public void Method <T>(T t)
    {
        switch (t.GetType().Name)
        {
            case "String":
                SetString(Convert.ToString(t));
                break;
            case "Int32":
                SetInt (Convert.ToInt32(t));
                break;
            default:
                break;
        }
        /*
        if (t is String)
        {
            SetString(Convert.ToString(t));            
        }
        else if(t is int)
        {
            SetInt (Convert.ToInt32(t));
        }
        */
        Console.WriteLine(t.GetType().Name);
    }
}

class Program
{
    static void Main()
    {
        GenericMethod methodGeneric = new GenericMethod();
        string s = "Hello";
        int i = 1;
        methodGeneric.Method<string>(s);
        methodGeneric.Method<int>(i);
    }
}