using System;
// using System.Linq;
// using System.Threading;
// using System.Threading.Tasks;
using System.Runtime.InteropServices;

class Sandbox
{
    public void Print()
    {
        Console.WriteLine("Hello World!");
    }
}

class Program
{
    static void Main()
    {
	// Environment.Version property returns the .NET runtime version for .NET 5+ and .NET Core 3.x
	// Not recommend for .NET Framework 4.5+
	Console.WriteLine($"Environment.Version: {Environment.Version}");
	// RuntimeInformation.FrameworkDescription property gets the name of the .NET installation on which an app is running
	// .NET 5+ and .NET Core 3.x // .NET Framework 4.7.1+ // Mono 5.10.1+
	Console.WriteLine($"RuntimeInformation.FrameworkDescription: {RuntimeInformation.FrameworkDescription}");
	Console.WriteLine();

        // Sandbox box = new(); // mono // mcs
        Sandbox box = new Sandbox();
        box.Print();
    }

    /*
    static async Task Main()
    {
        // Sandbox box = new();
        Sandbox box = new Sandbox();
        box.Print();

        Task taskAsync = Task.Run(() => Enumerable.Range(1, new Random().Next(100)).Count(x => x % 2 == 0));
        // Task taskAsync =  Task.Run(() => Thread.Sleep(1000)); // Task taskAsync = Task.Run(() => Task.Delay(1000));
        Console.WriteLine(taskAsync.IsCompleted);
        await taskAsync;
        Console.WriteLine(taskAsync.IsCompleted);
    }
    */
}