using System;
using MathematicsCore;
using MathematicsFramework;

class MathsClient
{
    public void Print()
    {
        MathsCore coreMaths = new MathsCore();
        Console.WriteLine(coreMaths.AddTwoIntegers(1, 2));

        MathsFramework frameworkMaths = new MathsFramework();
        Console.WriteLine(frameworkMaths.AddTwoIntegers(3, 4));
    }
}

class Program
{
    static void Main()
    {
        MathsClient clientMaths = new MathsClient();
        clientMaths.Print();
    }
}

