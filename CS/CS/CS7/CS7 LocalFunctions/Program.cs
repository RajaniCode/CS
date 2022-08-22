using static System.Console;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Globalization;

class LocalFunctions
{   
    // 6. Local Functions
    // Many designs for classes include methods that are called from only one location.
    // These additional private methods keep each method small and focused. 
    // However, they can make it harder to understand a class when reading it the first time. 
    // These methods must be understood outside of the context of the single calling location.
    // For those designs, local functions enable you to declare methods inside the context of another method. 
    // This makes it easier for readers of the class to see that the local method is only called from the context in which is it declared.
    // There are two very common use cases for local functions: public iterator methods and public async methods. Both types of methods generate code that reports errors later than programmers might expect. In the case of iterator methods, any exceptions are observed only when calling code that enumerates the returned sequence. In the case of async methods, any exceptions are only observed when the returned Task is awaited.
    // Let's start with an iterator method:
    /*
    public IEnumerable<char> AlphabetSubset(char start, char end)
    {
        if ((start < 'a') || (start > 'z'))
        {
            throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
        }

        if ((end < 'a') || (end > 'z'))
        {
            throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");
        }

        if (end <= start)
        {
            throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");
        }

        for (var c = start; c < end; c++)
        {
            yield return c;
        }
    }  
    */
    // Examine the code below that calls the iterator method incorrectly
    /*
    var resultSet = AlphabetSubset('f', 'a');
    WriteLine("iterator created");
    foreach (var thing in resultSet)
    {
        Write($"{thing}, ");
    }
    */    

    // Refactor
    // The exception is thrown when resultSet is iterated, not when resultSet is created. 
    // In this contained example, most developers could quickly diagnose the problem. 
    // However, in larger codebases, the code that creates an iterator often isn't as close to the code that enumerates the result.
    // You can refactor the code so that the public method validates all arguments, and a private method generates the enumeration:
    /*
    public IEnumerable<char> AlphabetSubset2(char start, char end)
    {
        if ((start < 'a') || (start > 'z'))
        {
            throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
        }
        if ((end < 'a') || (end > 'z'))
        {
            throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");
        }        
        if (end <= start)
        {
            throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");
        }
        return alphabetSubsetImplementation(start, end);
    }        
    private IEnumerable<char> alphabetSubsetImplementation(char start, char end)
    { 
        for (var c = start; c < end; c++)
        {
            yield return c;
        }
    }
    */    
    // This refactored version will throw exceptions immediately because the public method is not an iterator method; only the private method uses the yield return syntax. 
    // However, there are potential problems with this refactoring.
    // The private method should only be called from the public interface method, because otherwise all argument validation is skipped. Readers of the class must discover this fact by reading the entire class and searching for any other references to the alphabetSubsetImplementation method.

    // Refactor again
    // You can make that design intent more clear by declaring the alphabetSubsetImplementation as a local function inside the public API method:
    public IEnumerable<char> AlphabetSubset3(char start, char end)
    {
        if ((start < 'a') || (start > 'z'))
        {
            throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
        }
        if ((end < 'a') || (end > 'z'))
        {  
            throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");
        }        
        if (end <= start)
        {
            throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}"); // Unhandled Exception: System.ArgumentException: end must be greater than start
        }     
        return alphabetSubsetImplementation();

        // 6. Local Functions
        IEnumerable<char> alphabetSubsetImplementation()
        {
            for (var c = start; c < end; c++)
            {
                yield return c;
            }
        }
    }
    // The version above makes it clear that the local method is referenced only in the context of the outer method
    // The rules for local functions also ensure that a developer can't accidentally call the local function from another location in the class and bypass the argument validation
  
    // The same technique can be employed with async methods to ensure that exceptions arising from argument validation are thrown before the asynchronous work begins
    public Task<string> PerformLongRunningWork(string address, int index, string name)
    {
        if (string.IsNullOrWhiteSpace(address))
        {
            throw new ArgumentException(message: "An address is required", paramName: nameof(address));
        }
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(paramName: nameof(index), message: "The index must be non-negative");
        }
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(message: "You must supply a name", paramName: nameof(name));
        }        
        return longRunningWorkImplementation();
    
        async Task<string> longRunningWorkImplementation()
        {
            WriteLine("6. Local Functions");
            // Task<string> asyncTaskMessage = FirstWork(address);
            // string interimResult = await asyncTaskMessage;
            // string interimResult = await FirstWork(address);
            var interimResult = await FirstWork(address);
            // WriteLine(interimResult);

            // Task<int> asyncTaskNumber = SecondStep(index, name);
            // int secondResult = await asyncTaskNumber;
            // int secondResult = await SecondStep(index, name);
            var secondResult = await SecondStep(index, name);
            // WriteLine(secondResult);

            // return string.Format("The results are {0} and {1}. Enjoy.", interimResult, secondResult);
            return $"The results are {interimResult} and {secondResult}. Enjoy."; 
        }
    }
    
    private async Task<string> FirstWork(string address)
    {
        string locale = string.Empty; 
        try
        {
            // Task.FromResult is a placeholder for actual work that returns a string.
            locale = await Task.FromResult<string>(address);
        }                    
        catch (Exception ex)
        {
            WriteLine(ex.StackTrace);
        }
        return locale;        
    }
    
    private async Task<int> SecondStep(int index, string name)
    {
        int workingHours = 0;
        // Task.FromResult is a placeholder for actual work that returns a string.  
        var dayOfWeek = await Task.FromResult<string>(name);
        if (!dayOfWeek.StartsWith("S"))
        {
            workingHours = index;
        }
        return workingHours;  
    } 
    
    // The local method is referenced only in the context of the outer method
    // The rules for local functions also ensure that a developer can't accidentally call the local function from another location in the class and bypass the argument validation
    public void Print()
    {
        // Examine the code below that calls the iterator method incorrectly
        /*
        var resultSet = AlphabetSubset3('f', 'a');
        WriteLine("iterator created");
        foreach (var thing in resultSet)
        {
            Write($"{thing}, ");
        }
        */
        IEnumerable<char> resultSet = AlphabetSubset3('a', 'f');
        // var resultSet = AlphabetSubset3('a', 'f');
        WriteLine("iterator created");
        IEnumerator<char> enumerator = resultSet.GetEnumerator();
        // var enumerator = resultSet.GetEnumerator();       
        // IEnumerable<char> Count
        var count = resultSet.Count();        
        var counter = 0;
        while (enumerator.MoveNext())
        { 
            counter++;
            Write(counter < count ? $"{enumerator.Current}, " : $"{enumerator.Current}");            
        }
        WriteLine();
        
        string address = CultureInfo.CurrentCulture.Name;
        WriteLine(address);
        int index = 9;        
        string name = Convert.ToString(DateTime.Now.DayOfWeek);
        WriteLine(name);  
        Task<string> asyncTask = PerformLongRunningWork(address, index, name);
        var result = asyncTask.Result;
        WriteLine(result);
    }
}

class Program
{
    static void Main()
    {
        LocalFunctions localFunction = new LocalFunctions();
        localFunction.Print();
    }
}