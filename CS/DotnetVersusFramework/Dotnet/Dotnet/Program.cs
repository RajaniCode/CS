using System;
using MathematicsDotnet;
using MathematicsFramework;

class MathsClient
{
    public void Print()
    {
        MathsDotnet dotnetMaths = new();
        Console.WriteLine(dotnetMaths.AddTwoIntegers(1, 2));

        MathsFramework frameworkMaths = new();
        Console.WriteLine(frameworkMaths.AddTwoIntegers(3, 4));
    }
}

class Program
{
    static void Main()
    {
        MathsClient clientMaths = new();
        clientMaths.Print();
    }
}

