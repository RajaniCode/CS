// CS 7
/*
1. out variables
2. Tuples
3. Discards
4. Pattern Matching
5. ref locals and returns
6. Local Functions
7. Expression-bodied members
8. Throw expressions
9. Generalized async return types
10. Numeric literal syntax improvements
*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

struct PercentileDice
{
    public int Value { get; }
    public int Multiplier { get; }

    public PercentileDice(int multiplier, int value)
    {
        this.Value = value;
        this.Multiplier = multiplier;
    }
}

class Point
{
    public Point(double x, double y)
    {
        this.X = x;
        this.Y = y;
    }

    public double X { get; }
    public double Y { get; }

    // 2.6 Tuple Deconstruct method
    public void Deconstruct(out double x, out double y)
    {
        x = this.X;
        y = this.Y;
    }
}

class Discards
{   
    private (string, double, int, int, int, int) QueryCityDataForYears(string name, int year1, int year2)
    {
        int population1 = 0, population2 = 0;
        double area = 0;

        if (name == "New York City") 
        {
            area = 468.48; 
            if (year1 == 1960) 
            {
                population1 = 7781984;
            }
            if (year2 == 2010)
            {
                population2 = 8175133;
            }
            return (name, area, year1, population1, year2, population2);
        }
        return ("", 0, 0, 0, 0, 0);
   }
 
    public void Print()
    {
        Console.WriteLine("3. Discards");
        var (_, _, _, pop1, _, pop2) = QueryCityDataForYears("New York City", 1960, 2010);
        Console.WriteLine($"Population change, 1960 to 2010: {pop2 - pop1:N0}");
    }
}

class Features
{
    public void Print()
    {
        Console.WriteLine("Enter input:"); 
        var input = Console.ReadLine();
        // Previously, you would need to separate the declaration of the out variable and its initialization into two different statements
        // int answer;
        // if (int.TryParse(input, out answer))
         
        Console.WriteLine("1. out variables");
        // 1.1 out variables in the argument list of a method call, rather than writing a separate declaration statement
        // if (int.TryParse(input, out int answer))
        
        // 1.2 out variables as implicitly typed local variables
        if (int.TryParse(input, out var answer))
        {
            Console.WriteLine("Parsed input:" );
            Console.WriteLine(answer);
        }
        else
        {
            Console.WriteLine("Could not parse input");
        }
        
        Console.WriteLine("Enter input:");
        input = Console.ReadLine();

        // 1.3 out variables "leak" into the outer scope of the if statement
        if (!int.TryParse(input, out var outerScope))
        {
	    Console.WriteLine("Could not parse input");
        }
        Console.WriteLine("Parsed input:" );
        Console.WriteLine(outerScope);
        
        // CS 4.0 // Max 8 members
        // using System;
        var firstEightPrimes = Tuple.Create(2, 3, 5, 7, 11, 13, 17, 19);
        var secondEightPrimes = Tuple.Create(23, 29, 31, 37, 41, 43, 47, 53);
        var firstTwentyTwoPrimes = Tuple.Create(firstEightPrimes, secondEightPrimes, 59, 61, 67, 71, 73, 79);
        Console.WriteLine("First Prime Number:");
        Console.WriteLine(firstEightPrimes.Item1);
        Console.WriteLine("Eighth Prime Number:");
        Console.WriteLine(firstEightPrimes.Rest.Item1);
        Console.WriteLine("Sixteenth Prime Number:");
        Console.WriteLine(firstTwentyTwoPrimes.Item2.Rest.Item1);
        Console.WriteLine("Twenty-second Prime Number:");
        Console.WriteLine(firstTwentyTwoPrimes.Rest.Item1);
        
        Console.WriteLine("2. Tuples");
        // 2.1 Tuple by assigning each member to a value
        // The new tuples features require the System.ValueTuple type
        // You must add the NuGet package System.ValueTuple, available on the NuGet Gallery
        // using System.ValueTuple; 
        var upperCase = ("A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z");        
        var lowerCase = ("a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z");
        var mixedCase = (upperCase, lowerCase);
        Console.WriteLine("Tenth Lowercase Letter:");
        Console.WriteLine(mixedCase.Item2.Item10);
           
        // 2.2 Tuple provides semantic names to each of the members of the tuple
        (string Alpha, string Beta) letters = ("a", "b"); // The letters tuple contains fields referred to as Alpha and Beta
        Console.WriteLine("Letters:");
        Console.WriteLine((letters.Item1, letters.Item2));
        Console.WriteLine((letters.Alpha, letters.Beta));

        // 2.3 Tuple can specify the names of the fields on the right-hand side of the assignment
        var alphabet = (Alpha: "a", Beta: "b");
        Console.WriteLine("Alphabet:");
        Console.WriteLine((alphabet.Item1, alphabet.Item2));
        Console.WriteLine((alphabet.Alpha, alphabet.Beta));

        // 2.4 Tuple can specify names for the fields on both the left and right-hand side of the assignment
        // The line below generates a warning, CS8123
        // Warning that the names on the right side of the assignment, Alpha and Beta are ignored because they conflict with the names on the left side, First and Second
        #pragma warning disable 8123 // Suppress warning
        (string First, string Second) conflict = (Alpha: "a", Beta: "b");
        Console.WriteLine("Letters:");
        // Console.WriteLine((conflict.Item1, conflict.Item2));
        Console.WriteLine((conflict.First, conflict.First));
        // Will Not Work // Warning, CS8123 // Alpha and Beta are ignored
        // Console.WriteLine((conflict.Alpha, conflict.Beta));

        // 2.5 Tuple can define a data structure that carries more than one value
        // When you call the Range method, the return value is a tuple whose fields are Max and Min
        var odd = new int[] {1, 2, 3, 4, 5};
        var rangeMaxMin = Range(odd);
        Console.WriteLine("Max and Min in Range:");
        Console.WriteLine(rangeMaxMin);  
        var even = new int[] {1, 2, 3, 4, 5, 6};
        (int max, int min) = Range(even); // (int max, int min) = Range(odd); // (int max, int min) = rangeMaxMin;        
        Console.WriteLine("Max and Min in Range:");
        Console.WriteLine((max, min));  
        Console.WriteLine("Max in Range:");
        Console.WriteLine(max);  
        Console.WriteLine("Min in Range:");
        Console.WriteLine(min); 
        
        // 2.6 Tuple Deconstruct method
        // class 'Point' has a definition for 'Deconstruct'
        var p = new Point(3.14, 2.71);
        (double X, double Y) = p; 
        Console.WriteLine("X, Y:");
        Console.WriteLine((X, Y));

        // 2.7 Tuple not bound by the names defined in the Deconstruct method
        // Extract variables can be renamed as part of the assignment
        (double horizontalDistance, double verticalDistance) = p;
        Console.WriteLine("horizontalDistance, verticalDistance:");
        Console.WriteLine((horizontalDistance, verticalDistance));
 
        // 3. Discards
        Discards discard = new Discards();
        discard.Print();
        
        Console.WriteLine("4. Pattern Matching");
        // 4.1 Pattern matching is expression
        var numbers = new int[] {1, 2, 3, 4, 5};
        Console.WriteLine("Sum:");
        Console.WriteLine(DiceSum(numbers));
  
        // 4.1 Pattern matching is expression           
        var objects = new object[] {"1", 2, 3, 4, 5, null, 6.7};
        Console.WriteLine("Sum:");
        Console.WriteLine(DiceSum2(objects));

        // 4.2 Pattern matching switch statement updates
        Console.WriteLine("Sum:");
        Console.WriteLine(DiceSum3(objects));

        // 4.3 Pattern matching support constants
        Console.WriteLine("Sum:");
        try 
        {
            Console.WriteLine(DiceSum4(objects));
        }
        catch (InvalidOperationException ex) 
        {
            Console.WriteLine(ex.Message);
        }

        // 4.3 Pattern matching support constants
        var objs = new object[] {1, 2, 3, 4, 5};
        Console.WriteLine("Sum:");
        Console.WriteLine(DiceSum4(objs));

        // 4.3 Pattern matching support constants
        var nullobjs = new object[] {1, 2, 3, 4, null};
        Console.WriteLine("Sum:");
        Console.WriteLine(DiceSum4(nullobjs));

        // 4.4 Pattern matching for new type
        PercentileDice percentile = new PercentileDice(6, 10);
        var nullobjects = new object[] {1, 2, 3, 4, null, percentile};
        Console.WriteLine("Sum:");
        Console.WriteLine(DiceSum5(nullobjects));
    }
    
    // 2.5 Tuple can define a data structure that carries more than one value
    // The example method below returns the minimum and maximum values found in a sequence of integers
    // When you call the method, the return value is a tuple whose fields are Max and Min
    private (int Max, int Min) Range(IEnumerable<int> numbers)
    {
        int min = int.MaxValue;
        int max = int.MinValue;
        foreach(var n in numbers)
        {
            min = (n < min) ? n : min;
            max = (n > max) ? n : max;
        }
        return (max, min);
    }

    // 4.1 Pattern matching is expression
    public int DiceSum(IEnumerable<int> values)
    {   
        // using System.Linq;
        return values.Sum();
    }

    // 4.1 Pattern matching is expression
    public int DiceSum2(IEnumerable<object> values)
    {
        var sum = 0;
        foreach(var item in values)
        {
            if (item is int val) 
            {
                sum += val;
            }
            else if (item is IEnumerable<object> subList)
            {
                sum += DiceSum2(subList);
            }
        }
        return sum;
    }

    // 4.2 Pattern matching switch statement updates
    public int DiceSum3(IEnumerable<object> values)
    {
        var sum = 0;
        foreach (var item in values)
        {
            switch (item)
            {
                case int val:
                    sum += val;
                    break;
                case IEnumerable<object> subList:
                    sum += DiceSum3(subList);
                    break;
            }
        }
        return sum;
    }

    // 4.3 Pattern matching support constants
    public int DiceSum4(IEnumerable<object> values)
    {
        var sum = 0;
        foreach (var item in values)
        {
            switch (item)
            {
                case 0:
                    break;
                case int val:
                    sum += val;
                    break;
                case IEnumerable<object> subList when subList.Any():
                    sum += DiceSum4(subList);
                    break;
                case IEnumerable<object> subList:
                    break;
                case null:
                    break;
                default:
                    throw new InvalidOperationException("unknown item type");
            }
        }
        return sum;
    }

    // 4.4 Pattern matching for new type
    public int DiceSum5(IEnumerable<object> values)
    {
        var sum = 0;
        foreach (var item in values)
        {
            switch (item)
            {
                case 0:
                    break;
                case int val:
                    sum += val;
                    break;
                case PercentileDice dice:
                    sum += dice.Multiplier * dice.Value;
                    break;
                case IEnumerable<object> subList when subList.Any():
                    sum += DiceSum5(subList);
                    break;
                case IEnumerable<object> subList:
                    break;
                case null:
                    break;
                default:
                    throw new InvalidOperationException("unknown item type");
            }
        }
        return sum;
    }
}

class RefLocalsReturns
{ 
    // 5. ref locals and returns
    // This feature enables algorithms that use and return references to variables defined elsewhere
    // Example is working with large matrices, and finding a single location with certain characteristics
    // One method would return the two indices for a single location in the matrix:
    /*
    public (int i, int j) Find(int[,] matrix, Func<int, bool> predicate)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (predicate(matrix[i, j]))
                {
                    return (i, j);
                }
            }
        }
        return (-1, -1); // Not found
    }
    */
    // There are many issues with this code
    // First, it's a public method that's returning a tuple
    // The language supports this, but user defined types (either classes or structs) are preferred for public APIs
    // Second, this method is returning the indices to the item in the matrix. 
    // That leads callers to write code that uses those indices to dereference the matrix and modify a single element
    /*
    var indices = MatrixSearch.Find(matrix, (val) => val == 42);
    Console.WriteLine(indices);
    matrix[indices.i, indices.j] = 24;
    // Hence write a method that returns a reference to the element of the matrix that you want to change
    // This can only be accomplished by using unsafe code and returning a pointer to an int in previous versions      
    // Start by modifying the Find method declaration so that it returns a ref int instead of a tuple
    // Then, modify the return statement so it returns the value stored in the matrix instead of the two indices
    // Note that this won't compile as method declaration indicates ref return, the return statement specifies a value return
    /*
    public ref int Find2(int[,] matrix, Func<int, bool> predicate)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (predicate(matrix[i, j]))
                {
                    return matrix[i, j];
                }
            }
        }
        throw new InvalidOperationException("Not found");
    }
    */
    // When you declare that a method returns a ref variable, you must also add the ref keyword to each return statement
    // That indicates return by reference, and helps developers reading the code later remember that the method returns by reference    
    public ref int Find3(int[,] matrix, Func<int, bool> predicate)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (predicate(matrix[i, j]))
                {
                    return ref matrix[i, j];
                }
            }
        }

        int[,] x = new int[0, 0];
        throw new InvalidOperationException("Not found");
    }
    // Now that the method returns a reference to the integer value in the matrix, you need to modify where it's called
    /*
    var valItem = Find3(matrix, (val) => val == 42);
    Console.WriteLine(valItem);
    valItem = 24;
    Console.WriteLine(matrix[4, 2]);
    */
    // The second WriteLine statement in the example above prints out the value 42, not 24
    // The variable valItem is an int, not a ref int
    // The var keyword enables the compiler to specify the type, but will not implicitly add the ref modifier
    // Instead, the value referred to by the ref return is copied to the variable on the left-hand side of the assignment
    // The variable is not a ref local
    // In order to get the result you want, you need to add the ref modifier to the local variable declaration to make the variable a reference when the return value is a reference:
    /*
    ref var refItem = ref Find3(matrix, (val) => val == 42);
    Console.WriteLine(refItem);
    refItem = 24;
    Console.WriteLine(matrix[4, 2]);
    */
    // Now, the second WriteLine statement in the example above will print out the value 24, indicating that the storage in the matrix has been modified
    // The local variable has been declared with the ref modifier, and it will take a ref return
    // You must initialize a ref variable when it is declared, you cannot split the declaration and the initialization
}

class RefLocalsReturnsClient
{
    public void Print()
    { 
        // 5. ref locals and returns
        // The C# language has three other rules that protect you from misusing the ref locals and returns:
        // You cannot assign a standard method return value to a ref local variable.
        // That disallows statements like ref int i = sequence.Count();
        // You cannot return a ref to a variable whose lifetime does not extend beyond the execution of the method.
        // That means you cannot return a reference to a local variable or a variable with a similar scope.
        // ref locals and returns can't be used with async methods.
        // The compiler can't know if the referenced variable has been set to its final value when the async method returns.
        // The addition of ref locals and ref returns enable algorithms that are more efficient by avoiding copying values, or performing dereferencing operations multiple times.
        Console.WriteLine("5. ref locals and returns");      
        int[,] matrix = new int[5, 5]; 
        int rowLength = matrix.GetLength(0);
        int colLength = matrix.GetLength(1);
        /*
        matrix[0, 0] = 0;
        matrix[0, 1] = 1;
        matrix[0, 2] = 2;
        matrix[0, 3] = 3;
        matrix[0, 4] = 4; 
        matrix[1, 0] = 10;
        matrix[1, 1] = 11;
        matrix[1, 2] = 12;
        matrix[1, 3] = 13;
        matrix[1, 4] = 14;
        matrix[2, 0] = 20;
        matrix[2, 1] = 21;
        matrix[2, 2] = 21;
        matrix[2, 3] = 23;
        matrix[2, 4] = 24;
        matrix[3, 0] = 30;
        matrix[3, 1] = 31;
        matrix[3, 2] = 32;
        matrix[3, 3] = 33;
        matrix[3, 4] = 34;
        matrix[4, 0] = 40;
        matrix[4, 1] = 41;
        matrix[4, 2] = 42;
        matrix[4, 3] = 43;
        matrix[4, 4] = 44;  
        */    
        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < colLength; j++)
            {
                matrix[i, j] = (i * 10) + j;
            }
        }
        /*
        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < colLength; j++)
            {
                Console.Console.WriteLine("matrix[{0}, {1}] = {2}", i, j, matrix[i, j]);
            }
        }
        */           
        Console.WriteLine("local");
        RefLocalsReturns refLocalReturn = new RefLocalsReturns();       
        var valItem = refLocalReturn.Find3(matrix, (val) => val == 42);
        Console.WriteLine(valItem);
        valItem = 24;
        Console.WriteLine(matrix[4, 2]);

        Console.WriteLine("ref"); 
        ref var refItem = ref refLocalReturn.Find3(matrix, (val) => val == 42);
        Console.WriteLine(refItem);
        refItem = 24;
        Console.WriteLine(matrix[4, 2]);       
    }
}

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
    Console.WriteLine("iterator created");
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
            Console.WriteLine("6. Local Functions");
            // Task<string> asyncTaskMessage = FirstWork(address);
            // string interimResult = await asyncTaskMessage;
            // string interimResult = await FirstWork(address);
            var interimResult = await FirstWork(address);
            // Console.WriteLine(interimResult);

            // Task<int> asyncTaskNumber = SecondStep(index, name);
            // int secondResult = await asyncTaskNumber;
            // int secondResult = await SecondStep(index, name);
            var secondResult = await SecondStep(index, name);
            // Console.WriteLine(secondResult);

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
            Console.WriteLine(ex.StackTrace);
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
        Console.WriteLine("iterator created");
        foreach (var thing in resultSet)
        {
            Write($"{thing}, ");
        }
        */
        IEnumerable<char> resultSet = AlphabetSubset3('a', 'f');
        // var resultSet = AlphabetSubset3('a', 'f');
        Console.WriteLine("iterator created");
        IEnumerator<char> enumerator = resultSet.GetEnumerator();
        // var enumerator = resultSet.GetEnumerator();       
        // IEnumerable<char> Count
        var count = resultSet.Count();        
        var counter = 0;
        while (enumerator.MoveNext())
        { 
            counter++;
            Console.Write(counter < count ? $"{enumerator.Current}, " : $"{enumerator.Current}");            
        }
        Console.WriteLine();
        
        string address = CultureInfo.CurrentCulture.Name;
        Console.WriteLine(address);
        int index = 9;        
        string name = Convert.ToString(DateTime.Now.DayOfWeek);
        Console.WriteLine(name);  
        Task<string> asyncTask = PerformLongRunningWork(address, index, name);
        var result = asyncTask.Result;
        Console.WriteLine(result);
    }
}

class ExpressionBodiedMembers
{
    // 7. Expression-bodied members

    // Expression-bodied constructor
    public ExpressionBodiedMembers(string label) => this.Label = label;

    // Expression-bodied finalizer
    // This example does not need a finalizer, but it is shown to demonstrate the syntax. 
    // You should not implement a finalizer in your class unless it is necessary to release unmanaged resources. 
    // You should also consider using the SafeHandle class instead of managing unmanaged resources directly.
    ~ExpressionBodiedMembers() => Console.Error.WriteLine("Finalized!");

    private string lbl;

    // Expression-bodied get / set accessors.
    public string Label
    {
        get => lbl;
        set => this.lbl = value ?? "Default label";
    }
}

class ExpressionBodiedMembersClient
{
    public void Print()
    {
        ExpressionBodiedMembers expressionBodiedMember = new ExpressionBodiedMembers("7. Expression-bodied members");
        Console.WriteLine(expressionBodiedMember.Label);
    }
}

class ThrowExpressions
{
    private string nam;

    // 8. Throw expressions

    // In C#, throw has always been a statement. Because throw is a statement, not an expression, there were C# constructs where you could not use it.
    // These included conditional expressions, null coalescing expressions, and some lambda expressions. The addition of expression-bodied members adds more locations where throw expressions would be useful. 
    // So that you can write any of these constructs, C# 7.0 introduces throw expressions.
    // The syntax is the same as you've always used for throw statements. The only difference is that now you can place them in new locations, such as in a conditional expression:
    // throw statements in a conditional expression:
    public string Name
    {
        get => nam;
        set => nam = value ?? throw new ArgumentNullException(paramName: nameof(value), message: "New name must not be null");
    }

    // throw expressions in initialization expressions:
    private static ConfigResource loadedConfig = ConfigResource.LoadConfigResourceOrDefault() ?? throw new InvalidOperationException("Could not load config");
    // Previously, the above initializations (in property and field) would need to be in a constructor, with the throw statements in the body of the constructor:
    /*  
    public ThrowExpressions()
    {
        loadedConfig = LoadConfigResourceOrDefault();
        if (loadedConfig == null)
        {
            throw new InvalidOperationException("Could not load config");
        }
    }
    */
    // Both of the preceding constructs will cause exceptions to be thrown during the construction of an object. 
    // Those are often difficult to recover from. 
    // For that reason, designs that throw exceptions during construction are discouraged.
}

class ConfigResource
{
    public static ConfigResource LoadConfigResourceOrDefault() 
    {
        return new ConfigResource();
    }
}

class ThrowExpressionsClient
{
    public void Print()
    {
        ThrowExpressions throwExpression = new ThrowExpressions();
        throwExpression.Name = "8. Throw expressions";
        Console.WriteLine(throwExpression.Name);
    }
}

class GeneralizedAsyncReturnTypes
{
    // 9. Generalized async return types
    // Returning a Task object from async methods can introduce performance bottlenecks in certain paths. 
    // Task is a reference type, so using it means allocating an object. 
    // In cases where a method declared with the async modifier returns a cached result, or completes synchronously, the extra allocations can become a significant time cost in performance critical sections of code. 
    // It can become very costly if those allocations occur in tight loops.
    // The new language feature means that async methods may return other types in addition to Task, Task<T> and void. The returned type must still satisfy the async pattern, meaning a GetAwaiter method must be accessible. 
    // As one concrete example, the ValueTask type has been added to the .NET framework to make use of this new language feature:
    // You need to add the NuGet package System.Threading.Tasks.Extensions in order to use the ValueTask<TResult> type.
    public async ValueTask<int> Func()
    {
        await Task.Delay(100);
        return 5;
    }

    public ValueTask<int> CachedFunc()
    {
        return (cache) ? new ValueTask<int>(cacheResult) : new ValueTask<int>(LoadCache());
    }    

    private bool cache = false;
    private int cacheResult;

    private async Task<int> LoadCache()
    {
        // simulate async work:
        await Task.Delay(100);
        cacheResult = 100;
        cache = true;
        return cacheResult;
    }

    public void Print()
    {
        Console.WriteLine("9. Generalized async return types");
        Task<int> asyncTask = LoadCache();
        Console.WriteLine(asyncTask.Result);
    }
}

class NumericLiteralSyntaxImprovements
{
    // 10. Numeric literal syntax improvements

    // While creating bit masks, or whenever a binary representation of a number makes the most readable code, write that number in binary:
    public const int One =  0b0001;
    public const int Two =  0b0010;
    public const int Four = 0b0100;
    public const int Eight = 0b1000;
    // The 0b at the beginning of the constant indicates that the number is written as a binary number.

    // Binary numbers can get very long, so it's often easier to see the bit patterns by introducing the _ as a digit separator:
    public const int Sixteen =   0b0001_0000;
    public const int ThirtyTwo = 0b0010_0000;
    public const int SixtyFour = 0b0100_0000;
    public const int OneHundredTwentyEight = 0b1000_0000;

    // The digit separator can appear anywhere in the constant. For base 10 numbers, it would be common to use it as a thousands separator:
    public const long BillionsAndBillions = 100_000_000_000;

    // The digit separator can be used with decimal, float and double types as well:
    public const double AvogadroConstant = 6.022_140_857_747_474e23;
    public const decimal GoldenRatio = 1.618_033_988_749_894_848_204_586_834_365_638_117_720_309_179M; 

    public void Print()
    {
        Console.WriteLine("10. Numeric literal syntax improvements");
        Console.WriteLine("write number in binary");
        Console.WriteLine(One);
        Console.WriteLine(Two);
        Console.WriteLine(Four);
        Console.WriteLine(Eight);
        Console.WriteLine("_ as a digit separator:");
        Console.WriteLine(Sixteen);
        Console.WriteLine(ThirtyTwo);
        Console.WriteLine(SixtyFour);
        Console.WriteLine(OneHundredTwentyEight);
        Console.WriteLine("thousands separator:");
        Console.WriteLine(BillionsAndBillions);
        Console.WriteLine("digit separator can be used with decimal, float and double types ");
        Console.WriteLine(AvogadroConstant);
        Console.WriteLine(GoldenRatio);
    }
}

class Program
{
    static void Main()
    {
        Features feature = new Features();
        feature.Print();

        RefLocalsReturnsClient refLocalReturnClient = new RefLocalsReturnsClient();
        refLocalReturnClient.Print();

        LocalFunctions localFunction = new LocalFunctions();
        localFunction.Print();

        ExpressionBodiedMembersClient expressionBodiedMembers = new ExpressionBodiedMembersClient();
        expressionBodiedMembers.Print();

        ThrowExpressionsClient throwExpressions = new ThrowExpressionsClient();
        throwExpressions.Print();

        GeneralizedAsyncReturnTypes generalizedAsyncReturnType = new GeneralizedAsyncReturnTypes();
        generalizedAsyncReturnType.Print();

        NumericLiteralSyntaxImprovements numericLiteralSyntaxImprovement = new NumericLiteralSyntaxImprovements();
        numericLiteralSyntaxImprovement.Print();
    }
}

// Output
/*
Enter input:
1. out variables
Parsed input:
100
Enter input:
Parsed input:
200
First Prime Number:
2
Eighth Prime Number:
19
Sixteenth Prime Number:
53
Twenty-second Prime Number:
79
2. Tuples
Tenth Lowercase Letter:
j
Letters:
(a, b)
(a, b)
Alphabet:
(a, b)
(a, b)
Letters:
(a, a)
Max and Min in Range:
(5, 1)
Max and Min in Range:
(6, 1)
Max in Range:
6
Min in Range:
1
X, Y:
(3.14, 2.71)
horizontalDistance, verticalDistance:
(3.14, 2.71)
3. Discards
Population change, 1960 to 2010: 393,149
4. Pattern Matching
Sum:
15
Sum:
14
Sum:
14
Sum:
unknown item type
Sum:
15
Sum:
10
Sum:
70
5. ref locals and returns
local
42
42
ref
42
24
iterator created
a, b, c, d, e
en-US
Wednesday
6. Local Functions
The results are en-US and 9. Enjoy.
7. Expression-bodied members
8. Throw expressions
9. Generalized async return types
100
10. Numeric literal syntax improvements
write number in binary
1
2
4
8
_ as a digit separator:
16
32
64
128
thousands separator:
100000000000
digit separator can be used with decimal, float and double types 
6.022140857747474E+23
1.6180339887498948482045868344
Last Run:	12:49:09 pm
Compile:	0.023s
Execute:	0.16s
Memory:	1.67Mb
CPU:	0.183s
*/

/*
Courtesy:
https://docs.microsoft.com
*/