// CS 5
/*
async
await
*/

// async
// The async is the modifier used to mark a method as asynchronous

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

class Asynchronous
{
    public void Print()
    {
        Console.WriteLine("\nAsynchronous");
        Task asyncTask = FuncAsync();
        asyncTask.Wait();
        Console.WriteLine();
    }

    // async modifier used to define the asynchronous method
    public async Task FuncAsync()
    {
        await Task.Run(() => Console.WriteLine("Hello, World!"));
    }
}

class AsynchronousReturnTask
{
    public void Print()
    {
        Console.WriteLine("\nAsynchronous Return Task");
        Task<int[]> asynTask = DigitsAsync();
        var digits = asynTask.Result;
        digits.ToList().ForEach(Console.WriteLine);
        Console.WriteLine();
    }

    // If you use the Task<T> as the return type from the asynchronous method, the return expression must be implicitly convertible to type of T
    // Invocation of the task returning asynchronous method initially is the same as the synchronous function until the Common Language Runtime finds the first await expression
    async Task<int[]> DigitsAsync()
    {
        return await Task.Run(() =>
        {
            return new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        });
    }
}

class AsynchronousYield
{
    public void Print()
    {
        Console.WriteLine("\nAsynchronous Yield");
        Task asyncTask = YieldAsync();
        asyncTask.Wait();
        Console.WriteLine();
    }

    // Task.Yield creates an awaitable task that asynchronously yields back to the current context when awaited
    // A dictionary that maps thread IDs to the number of times that particular thread was encountered
    // For a million iteration, get the current thread’s ID and increment the appropriate element of histogram, then yield
    // The act of yielding will use a continuation to run the remainder of the method
    async Task YieldAsync()
    {
        var dict = new Dictionary<int, int>();
        Console.WriteLine("A dictionary that maps thread IDs to the number of times that particular thread was encountered:" );
        for(var i = 0; i < 1000000; i++)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            var counter = 0;
            dict[threadId] = dict.TryGetValue(threadId, out counter) ? counter + 1 : 1;
            await Task.Yield();
        }
        foreach(var keyValue in dict) 
        {
            Console.WriteLine(keyValue);
        }
    }
}

// await
// The await expression is used to suspend the execution of an asynchronous function until the awaited task completes its operation

class AsynchronousAwait
{
    public void Print()
    {
        Console.WriteLine("\nAsynchronous Await");
        Console.WriteLine("{0, 20}{1, 40}{2, 20}", "Method", "Description", "Thread Id");
        Console.WriteLine("{0, 20}{1, 40}{2, 20}", "Print", "Start Processing . . .", Thread.CurrentThread.ManagedThreadId);

        // Call async method
        Task asyncTask = EvenNumbersAsync();

        // For loop to simulate another process executing while the asynchronous operation is executing its task
        for(var i = 0; i < 1000000; i++)
        {
            if (i % 1000000 == 0)
            {
                Console.WriteLine("{0, 20}{1, 40}{2, 20}", "Print", "Another process is executing . . .", Thread.CurrentThread.ManagedThreadId);
            }
            else if (asyncTask.IsCompleted)
            {
                break;
            }
        }
        Console.WriteLine("{0, 20}{1, 40}{2, 20}", "Print", "Finished executing.", Thread.CurrentThread.ManagedThreadId);
    }

    async Task EvenNumbersAsync()
    {
        Console.WriteLine("{0, 20}{1, 40}{2, 20}", "EvenNumbersAsync", "Processing is continuing . . .", Thread.CurrentThread.ManagedThreadId);

        int limit = new Random().Next(100000);
        string range = string.Format("({0}, {1})", 1, limit);

        // Initialize and schedule a Task to run later
        Task<int> asyncTask = Task.Run(() => Enumerable.Range(1, limit).Count(x => x % 2 == 0));
        // The await statement await the Task to complete later by set up the continuation code block to execute after the Task finishes its job
        int count = await asyncTask;

        // Following code block will be used as the continuation code block for the asyncTask and it will be setup by the compiler
        Console.WriteLine("{0, 20}{1,40}{2, 20}", "EvenNumbersAsync", string.Format("In {0} Total: {1} On Thread", range, count), Thread.CurrentThread.ManagedThreadId);

        Console.WriteLine("{0, 20}{1, 40}{2, 20}", "EvenNumbersAsync", "Processing is finished.", Thread.CurrentThread.ManagedThreadId);
    }
}

class AsynchronousReturnVoid
{
    public void Print()
    {
        Console.WriteLine("\nAsynchronous Return Void");
        FireAsync();
        for(var i = 0; i < 1000000; i++)
        {
            if(i % 100000 == 0)
            {
                Console.Write(".");            
            }
        }
        Console.WriteLine();
     }

    // The difference between a void return and task return from the asynchronous method is that the asynchronous method that returns void cannot be awaited
    async void FireAsync()
    {
        Task asyncTask = Task.Run(() =>
        {
            Enumerable.Range(1, 5).ToList().ForEach(itemOuter =>
            {
                int limit = new Random().Next(100000);
                int result = Enumerable.Range(itemOuter, limit).Count(x =>
                {
                    return x % 2 == 0;
                });
                Console.WriteLine("\nProcessing and processed result {0}.\n", result);             
            });
        });
        await asyncTask; 
    }
}

class AsynchronousMultipleAwait
{
    public void Print()
    {
        Console.WriteLine("\nAsynchronous Multiple Await");
        MultipleAwaitAsync();
        for(var i = 0; i < 1000000; i++)
        {
            if(i % 100000 == 0)
            {
                Console.Write(">");
            }
        }         
        Console.WriteLine("\nOperation is completed\n");
    }

    async void MultipleAwaitAsync()    
    {
        await EvenNumbersAsync();
        await EvenNumbersAsync();    
    }

    public async Task EvenNumbersAsync()
    {
        int limit = new Random().Next(100000);
        Task<int> asyncTask = Task.Run( () => Enumerable.Range(1, limit).Count( x => x % 2 == 0));
        await asyncTask;
        Console.WriteLine("\n" + asyncTask.Result + "\n");
    }
}

class AsynchronousCancelToken
{
    public void Print()
    {
        Console.WriteLine("\nAsynchronous Cancel Token");
        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

        // Initialize the Task with the cancel Token from the CancellationTokenSource
        Task asyncTask = EvenNumbersAsync(cancelTokenSource.Token);

        // Following for-loop simulates another process
        for(var i = 0; i < 1000000; i++)
        {
            if(i == 100000)
            {
                // Call the Cancel method to cancel the task when the Task is executing
                cancelTokenSource.Cancel();
                break;
            }
        }
        Console.WriteLine("Cancel");
        Console.WriteLine("Is Task Completed: {0}", asyncTask.IsCompleted);
    } 

    async Task EvenNumbersAsync(CancellationToken cancelToken)
    {
        int limit = new Random().Next(100000);
        
        // Pass the cancel token to the Task
        Task<int> asyncTask = Task.Run(() => Enumerable.Range(1, limit).Count(x => x % 2 == 0), cancelToken);
        await asyncTask;
    }
}

class AsynchronousProgressReport
{
    public void Print()
    {
        Console.WriteLine("\nAsynchronous Progress Report");
        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

        Progress<int> progressReport = new Progress<int>((status) =>
        {
            Console.WriteLine(status + " %");
        });

        // Initialize the Task with the cancel Token from the CancellationTokenSource
        Task asyncTask = EvenNumbersAsync(cancelTokenSource.Token, progressReport);

        for(var i = 0; i < 1000000; i++)
        {
            if(i == 100000)
            {
                cancelTokenSource.Cancel();
                break;
            }
        }
        Console.WriteLine("Cancel");
        Console.WriteLine("Is Task Completed: {0}", asyncTask.IsCompleted);
    }

    async Task EvenNumbersAsync(CancellationToken cancelToken, IProgress<int> onProgressChanged)
    {
        int limit = new Random().Next(100);

        Task<int> asyncTask = Task.Run(() => Enumerable.Range(1, limit).Count(x =>
        {
            onProgressChanged.Report((x * 100) / x);
            return x % 2 == 0;
        }), cancelToken);
        await asyncTask; 
    }
}

class AsynchronousWhenAll
{
    public void Print()
    {
        Console.WriteLine("\nAsynchronous WhenAll");
        Task<int> asyncTask = WhenAllAsync();
        
        while(true)
        {
            if (asyncTask.IsCompleted)
            {
                Console.WriteLine("Finished: {0}", asyncTask.Result);
                break;            
            }
            Console.Write(".");
        }
    }

    async Task<int> WhenAllAsync()
    {
        int[] combinedResult = await Task.WhenAll(CountEvenNumbersAsync(), CountEvenNumbersAsync(), CountEvenNumbersAsync());
        return combinedResult.Sum();
    }

    async Task<int> CountEvenNumbersAsync()
    {
        return await Task.Run(() => Enumerable.Range(1, 100000).Count(x => x % 2 == 0));
    }
}

class AsynchronousExceptionInWhenAll
{
    public void Print()
    {
        Console.WriteLine("\nAsynchronous Exception in WhenAll");
        Task<int> asyncTask = WhenAllAsync();

        while(true)
        {
            if (asyncTask.IsCompleted)
            {
                Console.WriteLine("Finished: {0}", asyncTask.Result);
                break;
            }
            Console.Write(".");        
        }
    }

    async Task<int> WhenAllAsync()
    {
        int sum = 0;
        try
        {
            int[] combinedResult = await Task.WhenAll(CountEvenNumbersAsync(),ThrowExceptionAsync(),CountEvenNumbersAsync());
            sum = combinedResult.Sum();
        }
        catch (Exception e) 
        {
            Console.WriteLine(e.StackTrace);
        }
        return sum;
    }

    async Task<int> ThrowExceptionAsync()
    {
        int random = new Random().Next(1000);
        bool isRandomEven = random % 2 == 0 ? true : false;
        Console.WriteLine("\n{0} Is Even: {1}", random, isRandomEven);
        return await Task.Run(() =>
        {
            if(isRandomEven)
            {
                throw new Exception("\nThrowing Exception in ThrowExceptionAsync()\n");
            }
            return Enumerable.Range(1, 100000).Count(x => x % 2 == 0);
        });
    }

    async Task<int> CountEvenNumbersAsync()
    {
        return await Task.Run(() =>
        {
            int result = Enumerable.Range(1, 100000).Count(x => x % 2 == 0);
            Console.WriteLine(result);
            return result;        
        });
    }
}

class AsynchronousWhenAny
{
    public void Print()
    {
        Console.WriteLine("\nAsynchronous WhenAny");
        Task<int> asyncTask = WhenAnyAsync();
        
        while(true)
        {
            if(asyncTask.IsCompleted)
            {
                Console.WriteLine("Finished: {0}", asyncTask.Result);
                break;            
            }
            Console.Write(".");
        }
    }

    async Task<int> WhenAnyAsync()
    {
        Task<int> firstCompleted = await Task.WhenAny(CountEvenNumbersAsync(), CountEvenNumbersAsync(), CountEvenNumbersAsync());
        return firstCompleted.Result;
    }

    async Task<int> CountEvenNumbersAsync()
    {
        return await Task.Run(() => Enumerable.Range(1, 100000).Count(x => x % 2 == 0));
    }
}

class AsynchronousTaskDelay
{
    public void Print()
    {
        Console.WriteLine("\nAsynchronous Task Delay");
        Task asyncTask = DelayWithWhenAnyAsync();

        while(true)
        {
            if (asyncTask.IsCompleted)
            {
                Console.WriteLine("Finished Delay");
                break;
            }
            Console.Write(".");        
        }
    }

    async Task DelayWithWhenAnyAsync()
    {
        await Task.WhenAny(Task.Delay(1), Task.Delay(2000));
    } 
}

class Program
{
    static void Main()
    {
        Asynchronous asynchrony = new Asynchronous();
        asynchrony.Print();
        
        AsynchronousReturnTask asyncReturnTask = new AsynchronousReturnTask();
        asyncReturnTask.Print();

        AsynchronousYield yieldAsync = new AsynchronousYield();
        yieldAsync.Print();

        AsynchronousAwait asyncAwait = new AsynchronousAwait();
        asyncAwait.Print();

        AsynchronousReturnVoid asyncReturnVoid = new AsynchronousReturnVoid();
        asyncReturnVoid.Print();

        AsynchronousMultipleAwait asyncMultipleAwait = new AsynchronousMultipleAwait();
        asyncMultipleAwait.Print();

         AsynchronousCancelToken asyncCancelToken = new AsynchronousCancelToken();
        asyncCancelToken.Print();

        AsynchronousProgressReport asyncProgressReport = new AsynchronousProgressReport();
        asyncProgressReport.Print();

        AsynchronousWhenAll asyncWhenAll = new AsynchronousWhenAll();
        asyncWhenAll.Print();

        AsynchronousExceptionInWhenAll asyncExceptionInWhenAll = new AsynchronousExceptionInWhenAll();
        asyncExceptionInWhenAll.Print();

        AsynchronousWhenAny asyncWhenAny = new AsynchronousWhenAny();
        asyncWhenAny.Print();

        AsynchronousTaskDelay asyncTaskDelay = new AsynchronousTaskDelay();
        asyncTaskDelay.Print();
    }
}

/*
Courtesy:
https://docs.microsoft.com
*/