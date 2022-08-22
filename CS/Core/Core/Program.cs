using System;
// using System.Linq;
// using System.Threading;
// using System.Threading.Tasks;

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
        Sandbox box = new Sandbox();
        box.Print();
    }

    /*
    static async Task Main()
    {
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