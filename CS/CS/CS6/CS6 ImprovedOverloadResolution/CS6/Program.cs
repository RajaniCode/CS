using static System.Console;
using System.Threading.Tasks; 

// 12. Improved overload resolution
class ImprovedOverloadResolution
{
    // This last feature is one you probably won't notice. There were constructs where the previous version of the C# compiler may have found some method calls involving lambda expressions ambiguous. Consider this method:
    static Task DoThings() 
    {
        return Task.FromResult(0); 
    }

    public void Print()
    {
        // In earlier versions of C#, calling that method using the method group syntax would fail
        Task.Run(DoThings);  // The C# 6 compiler correctly determines that Task.Run(Func<Task>()) is a better choice

        // The earlier compiler could not distinguish correctly between Task.Run(Action) and Task.Run(Func<Task>())
        // In previous versions, you'd need to use a lambda expression as an argument        
        Task t = Task.Run(() => DoThings());
        WriteLine("12. Improved overload resolution");
        WriteLine(t.IsCompleted);        
    } 
}

class Program
{
    static void Main()
    {
        ImprovedOverloadResolution overloadResolution = new ImprovedOverloadResolution();
        overloadResolution.Print();
    }
}
