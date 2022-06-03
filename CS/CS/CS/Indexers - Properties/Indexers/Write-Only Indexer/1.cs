using System;
using System.Collections.Generic;

class Sample
{
    private List<string> Lst = new List<string>();

    public void Add(string item)
    {
        Lst.Add(item);
    }

    public string GetItem(int index)
    {
        return Lst[index];
    }

    public string this[int index]
    {
        set
        {
            if (Lst.Count > index)
            {
                Lst[index] = value;
            }
            else
            {
                throw new Exception("Index does not exist");
            }
        }
    }
}

class MainApp
{
    static void Main(string[] args)
    {
        Sample Smple = new Sample();

        Smple.Add("foo");

        Console.WriteLine("item foo added");

        Console.WriteLine("1st item value is " + Smple.GetItem(0));

        Console.WriteLine("now changing it to fii by indexer");

        Smple[0] = "fii";

        Console.WriteLine("1st item value is " + Smple.GetItem(0));
    }
}
