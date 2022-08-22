using System;
using MathematicsFramework;

class MathsClient
{
    public void Print()
    {
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

        Console.WriteLine("Press any key to close this window . . .");
        Console.ReadKey();
    }
}