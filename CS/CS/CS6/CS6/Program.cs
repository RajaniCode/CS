// CS 6
/*
1. Read-only Auto-properties
2. Auto-Property Initializers
3. Expression-bodied function members
4. using static
5. Null-conditional operators
6. String Interpolation
7. Exception filters
8. nameof Expressions
9. await in catch and finally blocks
10. Index initializers
11. Extension methods for collection initializers
12. Improved overload resolution
13. Deterministic compiler output
*/

// 4. using static
// You can import all the methods of a single class into the current namespace
// Import static members of the type direcly into scope
// You must use the fully qualified class name
using static System.Console;
// using static and extension methods 
// Extension methods are only in scope when called using the extension method invocation syntax, not when called as a static method
// This imports all the methods in the Enumerable class
// However, the extension methods are only in scope when called as extension methods
// They are not in scope if they are called using the static method syntax
using static System.Linq.Enumerable;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Pet
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public class Point
{  
    // 1. Read-only auto-properties 
    // Getter only auto properties // For immutable type // Can be set only in constructor
    // Previous versions of CS
    // public string X { get; private set; }
    // public string Y { get; private set; }
    public int X { get; }
    public int Y { get; }

    public Point() { }
    
    // 1. Read-only auto-properties 
    // You can write initialization expressions to set the initial value of an auto-property
    // Getter only auto properties // For immutable type // Can be set only in constructor
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
       
    // 1. Read-only auto-properties
    // Property with a single return statement
    // Previous versions of CS
    /*
    public double Distance
    {
        get { return System.Math.Sqrt(X * X + Y * Y); }
    }
    */
    // 2. Auto-Property Initializers 
    public double Distance => System.Math.Sqrt(X * X + Y * Y); // Write initialization expressions to set the initial value of an auto-property
    
    // 3. Expression-bodied function members
    // You can author one-line methods using lambda expressions
    // Method with a single return statement
    // 6. String Interpolation
    // You can write string formatting expressions using inline expressions instead of positional arguments
    // Previous versions of CS
    /*
    public override string ToString()
    {
        return string.Format("({0}, {1})", X, Y); // 6. String Interpolation // Previous versions of CS
    }
    */ 
    // public override string ToString() => string.Format("({0}, {1})", X, Y); // 6. String Interpolation // Previous versions of CS
    // OR
    public override string ToString() => $"{X}, {Y}"; // 6. String Interpolation

    // 3. Expression-bodied function members
    // Expression-bodied members in read only properties as well          
    public string Coordinates => $"{X}, {Y}"; 

    // Operator with a single return statement
    // Previous versions of CS
    /*
    public static Point operator +(Point p1, Point p2)
    {
        return new Point(p1.X + p2.X, p1.Y + p2.Y);
    }
    */
    public static Point operator +(Point p1, Point p2) => new Point(p1.X + p2.X, p1.Y + p2.Y);

    public void Show()
    {
        WriteLine("Operator: ({0}, {1})", X, Y);
    }
}

// 2. Auto-Property Initializers
// 11. Extension methods for collection initializers
// Consistent accessibility // public class Student
class Student
{
    public string firstName;
    public string lastName;

    public Student(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    // 6. String Interpolation
    // Pre=CS 6
    /*
    public string FullName
    {
        get
        {
            return string.Format("{0} {1}", firstName, lastName);
        }
    }
    */
    // CS 6
    public string FullName => $"{firstName} {lastName}";

    // 2. Auto-Property Initializers
    public ICollection<double> Grades { get; } = new List<double>();
    public Standing YearInSchool { get; set; } = Standing.Freshman; // 2. Auto-Property Initializers // static

    public bool MakesDeansList()
    {
        return Grades.All(g => g > 3.5) && Grades.Any();
        // Code below generates CS0103: 
        // The name 'All' does not exist in the current context.
        //return All(Grades, g => g > 3.5) && Grades.Any();
    }

    // 6. String Interpolation
    public string GetFormattedGradePoint() => $"Name: {lastName}, {firstName}. G.P.A: {Grades.Average()}";
    public string GetGradePointPercentage() => $"Name: {lastName}, {firstName}. G.P.A: {Grades.Average():F2}";
    // The : is always interpreted as the separator between the expression being formatted and the format string
    // This can introduce problems when your expression uses a : in another way, such as a conditional operator:
    /*
    public string GetGradePointPercentages() => $"Name: {lastName}, {firstName}. G.P.A: {Grades.Any() ? Grades.Average() : double.NaN:F2}";
    */
    // In the preceding example, the : is parsed as the beginning of the format string, not part of the conditional operator
    // In all cases where this happens, you can surround the expression with parentheses to force the compiler to interpret the expression as you intend
    public string GetGradePointPercentages() => $"Name: {lastName}, {firstName}. G.P.A: {(Grades.Any() ? Grades.Average() : double.NaN):F2}";

    // There aren't any limitations on the expressions you can place between the braces
    // You can execute a complex LINQ query inside an interpolated string to perform computations and display the result
    public string GetAllGrades() => $@"All Grades: {Grades.OrderByDescending(g => g).Select(s => s.ToString("F2")).Aggregate((partial, element) => $"{partial}, {element}")}";
    // You can see from this sample that you can even nest a string interpolation expression inside another string interpolation expression
    // This example is very likely more complex than you would want in production code
    // Rather, it is illustrative of the breadth of the feature
    // Any C# expression can be placed between the curly braces of an interpolated string

    public void Method() 
    {
        // 6. String interpolation and specific cultures
        // FormattableString str = $"Average grade is {s.Grades.Average()}"; // The name 's' does not exist in the current context
        FormattableString str = $"Average grade is {Grades.Average()}";
        var gradeStr = str.ToString(new System.Globalization.CultureInfo("de-DE"));
    }
}

public class Standing 
{      
    public static Standing Freshman { get; set; } // 2. Auto-Property Initializers // static
}

delegate void EventHandlers(object sender, EventArguments args);

// .NET-compatible event
class EventArguments : EventArgs 
{ 
    public int eventnumber;
}

class EventContainer
{
    private static int count = 0;

    public event EventHandlers RegisterEventHandler;
        
    public void OnRegisterEventHandler()
    {
        EventArguments eventArgs = new EventArguments();

        // 5. Null-conditional operators // Invoke methods by calling the delegate's Invoke method
        // Previous versions of CS
        /*
        if (RegisterEventHandler != null)
        {
            eventArgs.eventnumber = count++;
            RegisterEventHandler(this, eventArgs);
        }
        */
        eventArgs.eventnumber = count++;
        this.RegisterEventHandler?.Invoke(this, eventArgs);
    }
}

class X
{
    public void XEventHandler(object sender, EventArguments args)
    {
        WriteLine("Event #" + args.eventnumber + " received by X object");
        WriteLine("Source: " + sender);
    }
}
           
class Y
{
    public void YEventHandler(object sender, EventArguments args)
    {
        WriteLine("Event #" + args.eventnumber + " received by Y object");
        WriteLine("Source: " + sender);
    }
}    

class EventClient
{
    public void Print()
    {
        // 5. Null-conditional operators // Invoke methods by calling the delegate's Invoke method
        EventContainer eventContain = new EventContainer();
        X x = new X();
        Y y = new Y();
        eventContain.RegisterEventHandler += x.XEventHandler;
        eventContain.RegisterEventHandler += y.YEventHandler; 
        eventContain.OnRegisterEventHandler();
        eventContain.OnRegisterEventHandler();
    }
}

class Features 
{
    private Pet[] pets = { new Pet { Name="Barley", Age=10 },
                            new Pet { Name="Boots", Age=4 },
                            new Pet { Name="Whiskers", Age=6 } };       

    // 6. String Interpolation
    private string GetAverageAgeFormat() => string.Format("{0} = {1}", "Average", (from x in pets select x.Age).Average()); 
    private string GetAverageAgeInterpolation() => $"Average = {(from x in pets select x.Age).Average()}";
    private string GetAverageAgePrecisionFormat() => string.Format("{0} = {1:F2}", "Average", (from x in pets select x.Age).Average()); 
    private string GetAverageAgePrecisionInterpolation() => $"Average = {(from x in pets select x.Age).Average():F2}";
    private string GetAverageAgePrecisionConditionalFormat() => string.Format("{0} = {1:F2}", "Average", pets.Any() ? ((from x in pets select x.Age).Average()) : double.NaN);
    private string GetAverageAgePrecisionConditionalInterpolation() => $"Average = {(pets.Any() ? ((from x in pets select x.Age).Average()) : double.NaN):F2}";
    
    private bool MakesPetsList()
    {   
        // 4. using static     
        // using static and extension methods
        // Extension methods are only in scope when called using the extension method invocation syntax, not when called as a static method
        // return all pet names in the array start with 'B'.
        // return pets.All(pet => pet.Name.StartsWith("B"));
        // Code below generates CS0103: 
        // The name 'All' does not exist in the current context.
        // return All(pets, pet => pet.Name.StartsWith("B"));
        return pets.All(pet => pet.Age > 3.5) && pets.Any();
    }

    // 5. Null-conditional operators ?. and ?[]
    double SumNumbers(List<double[]> setsOfNumbers, int indexOfSetToSum)
    {
        // using System.Linq;
        return setsOfNumbers?[indexOfSetToSum]?.Sum() ?? double.NaN;
    }

    public void Print()
    {
        var linqnames = (from pet in pets select pet.Name).ToList();
        WriteLine("Pet Names - LINQ:");
        linqnames.ForEach(WriteLine);
        
        var linqages = (from pet in pets select pet.Age).ToList();
        WriteLine("Pet Ages - LINQ:");
        linqages.ForEach(WriteLine);
        
        var linq1 = from pet in pets orderby pet.Name descending, pet.Age descending select pet.Name;
        WriteLine("Pet Count - LINQ:");
        WriteLine(linq1.Count());
                 
        var linq2 = from pet in pets orderby pet.Name descending, pet.Age descending select pet.Name;
        WriteLine("Pet Name Aggregate - LINQ:");
        WriteLine(linq2.Aggregate((a, b) => a + ", " + b));
              
        var linq3 = from pet in pets orderby pet.Name descending, pet.Age descending select pet.Age;
        WriteLine("Pet Age Aggregate - LINQ:");
        WriteLine(linq3.Aggregate((a, b) => a + b));
          
        var lambdanames = (pets.Select(pet => pet.Name)).ToList();
        WriteLine("Pet Names - Lambda:");
        lambdanames.ForEach(WriteLine);
        
        var lambdaages = (pets.Select(pet => pet.Age)).ToList();
        WriteLine("Pet Ages - Lambda:");
        lambdaages.ForEach(WriteLine);
        
        var lambda1 = pets.OrderByDescending(pet => pet.Name)
                          .ThenByDescending(pet => pet.Age)
                          .Select(pet => pet.Name);
        WriteLine("Pet Count - Lambda:");         
        WriteLine(lambda1.Count());
                        
        var lambda2 = pets.OrderByDescending(pet => pet.Name)
                          .ThenByDescending(pet => pet.Age)
                          .Select(pet => pet.Name).Aggregate((a, b) => a + ", " + b);
        WriteLine("Pet Name Aggregate - Lambda:");
        WriteLine(lambda2);
                           
        var lambda3 = pets.OrderByDescending(pet => pet.Name)
                          .ThenByDescending(pet => pet.Age)
                          .Select(pet => pet.Age).Aggregate((a, b) => a + b);
        WriteLine("Pet Age Aggregate - Lambda:");
        WriteLine(lambda3);
        
        Point pnt = new Point(1, 2);
        
        WriteLine("1. Read-only auto-properties");
        WriteLine("X = " + pnt.X);
        WriteLine("Y = " + pnt.Y);
        
        WriteLine("2. Auto-Property Initializers:");
        WriteLine("Property: " + pnt.Distance);
          
        WriteLine("3. Expression-bodied function members");
        WriteLine("Method: " + pnt.ToString());
      
        // 4. using static
        // Import static members of the type direcly into scope
        WriteLine("4. using static");
        // Console.WriteLine() // Will not compile without using System;              
        WriteLine("Import static members of the type direcly into scope");               
        // using static and extension methods 
        WriteLine("MakesPetsList: " +  MakesPetsList());   

        Point x = new Point(1, 2);
        Point y = new Point(3, 4);
        Point z = new Point();
        
        WriteLine("Overloading binary operator + to add objects: z = x + y");
        z = x + y;
        z.Show();                     
        
        // 5. Null-conditional operators
        // You can concisely and safely access members of an object while still checking for null with the null conditional operator
        WriteLine("5. Null-conditional operators");
        var first = pnt?.X;
        WriteLine("First Coordinate: " + first);
        
        // 5. Null-conditional operators // With the null coalescing operator to assign default values when one of the properties is null
        first = pnt?.X ?? null;
        WriteLine("First Coordinate: " + first);  
        
        // 5. Null-conditional operators ?. and ?[]
        Console.WriteLine("5. Null-conditional operators ?. and ?[]");
        /*
        List<double[]> setsOfNumbers = new List<double[]> { new[] { 1.0, 2.0, 3.0 }, null };
        int indexOfSetToSum = 0;
        // using System.Linq;
        var sum = setsOfNumbers?[indexOfSetToSum]?.Sum() ?? double.NaN; 
        Console.WriteLine("Sum = {0}", sum); // output: 6
        */
        var sum1 = SumNumbers(null, 0);
        Console.WriteLine(sum1);  // output: NaN
        var numberSets = new List<double[]>
        {
            new[] { 1.0, 2.0, 3.0 },
            null
        };
        var sum2 = SumNumbers(numberSets, 0);
        Console.WriteLine(sum2);  // output: 6
        var sum3 = SumNumbers(numberSets, 1);
        Console.WriteLine(sum3);  // output: NaN

        // 6. String Interpolation
        WriteLine("6. String Interpolation");
        WriteLine(GetAverageAgeFormat());
        WriteLine(GetAverageAgeInterpolation());            
        WriteLine(GetAverageAgePrecisionFormat());
        WriteLine(GetAverageAgePrecisionInterpolation());            
        WriteLine(GetAverageAgePrecisionConditionalFormat());
        WriteLine(GetAverageAgePrecisionConditionalInterpolation());
    }
}

// 7. Exception Filters
// Another new feature in C# 6 is exception filters. 
// Exception Filters are clauses that determine when a given catch clause should be applied
class ExceptionFilters
{
    // One use is to examine information about an exception to determine if a catch clause can process the exception
    // If the expression used for an exception filter evaluates to true, the catch clause performs its normal processing on an exception
    // If the expression evaluates to false, then the catch clause is skipped
    /*
    public async Task<string> MakeRequest()
    {    
        WebRequestHandler webRequestHandler = new WebRequestHandler();
        webRequestHandler.AllowAutoRedirect = false;
        using (HttpClient client = new HttpClient(webRequestHandler))
        {
            var stringTask = client.GetStringAsync("https://docs.microsoft.com");
            try
            {  
                var responseText = await stringTask;
                return responseText;
            }
            catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("301"))
            {
                return "Site Moved";
            }
        }
    }
    */

    // The code generated by exception filters provides better information about an exception that is thrown and not processed. 
    // Before exception filters were added to the language, you would need to create code like the following
    public async Task<string> MakeRequest()
    { 
        var client = new System.Net.Http.HttpClient();
        var streamTask = client.GetStringAsync("https://docs.microsoft.com");
        try
        {
            var responseText = await streamTask;
            return responseText;
        } 
        catch (System.Net.Http.HttpRequestException e)
        {
            if (e.Message.Contains("301"))
            {
                return "Site Moved";
            }
            else
            {
                throw;
            }
        }
    }
    // The point where the exception is thrown changes between the two MakeRequest() examples. 
    // In the previous code, where a throw clause is used, any stack trace analysis or examination of crash dumps will show that the exception was thrown from the throw statement in your catch clause. 
    // The actual exception object will contain the original call stack, but all other information about any variables in the call stack between this throw point and the location of the original throw point has been lost.
    // Contrast that with how the code using an exception filter is processed: the exception filter expression evaluates to false. 
    // Therefore, execution never enters the catch clause. Because the catch clause does not execute, no stack unwinding takes place. 
    // That means the original throw location is preserved for any debugging activities that would take place later.
    // Whenever you need to evaluate fields or properties of an exception, instead of relying solely on the exception type, use an exception filter to preserve more debugging information.

    // Whenever you want to log an exception, you can add a catch clause, and use this method as the exception filter
    public void MethodThatFailsSometimes()
    {
        try 
        {
            PerformFailingOperation();
        } 
        catch (Exception e) when (e.LogException())
        {
            // This is never reached!
        }
    }

    // The exceptions are never caught, because the LogException method always returns false. 
    // That always false exception filter means that you can place this logging handler before any other exception handlers
    public void MethodThatFailsButHasRecoveryPath()
    {
        try 
        {
            PerformFailingOperation();
        } 
        catch (Exception e) when (e.LogException())
        {
            // This is never reached!
        }
        catch (RecoverableException ex)
        {
            WriteLine(ex.ToString());
            // This can still catch the more specific
            // exception because the exception filter
            // above always returns false.
            // Perform recovery here 
        }
    }
    
    // The preceding example highlights a very important facet of exception filters. The exception filters enable scenarios where a more general exception catch clause may appear before a more specific one. It's also possible to have the same exception type appear in multiple catch clauses
    public async Task<string> MakeRequestWithNotModifiedSupport()
    { 
        var client = new System.Net.Http.HttpClient();
        // var streamTask = client.GetStringAsync("https://localHost:10000");
        var streamTask = client.GetStringAsync("https://docs.microsoft.com");
        try 
        {
            var responseText = await streamTask;
            return responseText;
        } 
        catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("301"))
        {
            return "Site Moved";
        } 
        catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("304"))
        {
            return "Use the Cache";
        }
    }

    // Another recommended pattern helps prevent catch clauses from processing exceptions when a debugger is attached.
    // This technique enables you to run an application with the debugger, and stop execution when an exception is thrown.
    // In your code, add an exception filter so that any recovery code executes only when a debugger is not attached:
    public void MethodThatFailsWhenDebuggerIsNotAttached()
    {
        try 
        {
            PerformFailingOperation();
        } 
        catch (Exception e) when (e.LogException())
        {
            // This is never reached!
        }
        catch (RecoverableException ex) when (!System.Diagnostics.Debugger.IsAttached)
        {
            WriteLine(ex.ToString());
            // Only catch exceptions when a debugger is not attached.
            // Otherwise, this should stop in the debugger. 
        }
    }
    // After adding this in code, you set your debugger to break on all unhandled exceptions. Run the program under the debugger, and the debugger breaks whenever PerformFailingOperation() throws a RecoverableException. The debugger breaks your program, because the catch clause won't be executed due to the false-returning exception filter.

    public void PerformFailingOperation() 
    {
         WriteLine("7. Exception Filters");
         WriteLine("Perform Failing Operation");
    }
}

class RecoverableException : Exception
{
    public RecoverableException() { }

    public RecoverableException(string message) : base(message) { }

    public RecoverableException(string message, Exception inner) : base(message, inner) { }
}

static class ExceptionExtension
{   
    // Another recommended pattern with exception filters is to use them for logging routines. This usage also leverages the manner in which the exception throw point is preserved when an exception filter evaluates to false.
    // A logging method would be a method whose argument is the exception that unconditionally returns false
    public static bool LogException(this Exception e)
    {
        // Console.Error.WriteLine($"Exceptions happen: {e}");
        Error.WriteLine($"Exceptions happen: {e}");
        return false;
    } 
}

class ExceptionFiltersClient
{
    public void Print()
    {       
        ExceptionFilters exceptionFilter = new ExceptionFilters();
        exceptionFilter.MethodThatFailsWhenDebuggerIsNotAttached();

        Task<string> asyncTaskMakeRequest =  exceptionFilter.MakeRequest();
        asyncTaskMakeRequest.Wait();
        // WriteLine(asyncTaskMakeRequest.Result);

        Task<string> asyncTaskMakeRequestWithNotModifiedSupport =  exceptionFilter.MakeRequestWithNotModifiedSupport();
        asyncTaskMakeRequestWithNotModifiedSupport.Wait();
        // WriteLine(asyncTaskMakeRequestWithNotModifiedSupport.Result);
    }
}

// 8. nameof Expressions
// .NET-compatible event
class PropertyChangedEventArgs : EventArgs 
{ 
    private string name;

    public PropertyChangedEventArgs(string name)
    {
        this.name = name;
    }    
}

// 8. nameof Expressions
delegate void PropertyChangedEventHandlers(object sender, PropertyChangedEventArgs args);

// 8. nameof Expressions
class NameofExpressions
{
    public event PropertyChangedEventHandlers PropertyChanged;
    
    // 8. nameof Expressions
    // One of the uses nameof operator is with XAML based applications that implement the INotifyPropertyChanged interface
    public string LastName
    {
        get { return lstName; }
        set
        {
            if (value != lstName)
            {
                lstName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
            }
        }
    }
    // private string lstName = string.Empty; // Unhandled Exception: System.ArgumentException: Cannot be blank Parameter name: lstName
    private string lstName = "LastName";
      
    public void Method()
    {
        WriteLine("8. nameof Expressions");
        // The nameof expression evaluates to the name of a symbol
        // It's a great way to get tools working whenever you need the name of a variable, a property, or a member field
        // One of the most common uses for nameof is to provide the name of a symbol that caused an exception:
        if (string.IsNullOrWhiteSpace(lstName))
        {
            throw new ArgumentException(message: "Cannot be blank", paramName: nameof(lstName));
        }      
        WriteLine("LastName: {0}", LastName);     
    }
}

class NameofExpressionsClient
{
    public void Print()
    { 
        NameofExpressions nameofExpression = new NameofExpressions();
        nameofExpression.Method();
    }
}

// 9. await in catch and finally blocks
// Await in Catch and Finally blocks
class AwaitInCatchAndFinally
{
    // C# 5 had several limitations around where you could place await expressions. One of those has been removed in C# 6. You can now use await in catch or finally expressions.
    // The addition of await expressions in catch and finally blocks may appear to complicate how those are processed. Let's add an example to discuss how this appears. In any async method, you can use an await expression in a finally clause.
    // With C# 6, you can also await in catch expressions. This is most often used with logging scenarios
    public async Task<string> MakeRequestAndLogFailures()
    { 
        WriteLine("9. await in catch and finally blocks");
        await logMethodEntrance();
        var client = new System.Net.Http.HttpClient();
        // var streamTask = client.GetStringAsync("https://localHost:10000");
        var streamTask = client.GetStringAsync("https://docs.microsoft.com");
        try 
        {
            var responseText = await streamTask;
            return responseText;
        } 
        catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("301"))
        {
            await logError("Recovered from redirect", e);
            return "Site Moved";
        }
        finally
        {
            await logMethodExit();
            client.Dispose();
        }
    }
    // The implementation details for adding await support inside catch and finally clauses ensures that the behavior is consistent with the behavior for synchronous code. When code executed in a catch or finally clause throws, execution looks for a suitable catch clause in the next surrounding block. If there was a current exception, that exception is lost. The same happens with awaited expressions in catch and finally clauses: a suitable catch is searched for, and the current exception, if any, is lost.
    // This behavior is the reason it's recommended to write catch and finally clauses carefully, to avoid introducing new exceptions.

    async Task<string> logMethodEntrance()
    {
        var tasklogEntrance = await Task.FromResult<string>("log Entrance");
        return tasklogEntrance;
    }

    async Task<string> logError(string message, System.Net.Http.HttpRequestException e)
    {
        var tasklogError = await Task.FromResult<string>($"{message}, {e.StackTrace}");
        return tasklogError;
    }

    async Task<string> logMethodExit()
    {
        var tasklogMethodExit = await Task.FromResult<string>("log Method Exit");
        return tasklogMethodExit;
    }
}

class AwaitInCatchAndFinallyClient
{
    public void Print()
    {
        AwaitInCatchAndFinally awaitInCatchFinally = new AwaitInCatchAndFinally();
        Task<string> asyncTask = awaitInCatchFinally.MakeRequestAndLogFailures();
        asyncTask.Wait();
        // WriteLine(asyncTask.Result);      
    }
}

class IndexInitializers
{
    // 10. Index initializers
    // Index Initializers is one of two features that make collection initializers more consistent with index usage. In earlier releases of C#, you could use collection initializers only with sequence style collections, including Dictionary<TKey,TValue> by adding braces around key and value pairs
    private List<string> messages = new List<string> 
    {
        "Page not Found",
        "Page moved, but left a forwarding address.",
        "The web server can't come out to play today."
    };
    
    // In earlier releases of C#, you could use collection initializers with sequence style collections, including Dictionary<TKey,TValue>, by adding braces around key and value pairs:
    private Dictionary<int, string> webErrs = new Dictionary<int, string>
    {
        { 404, "Page not Found"},
        { 302, "Page moved, but left a forwarding address."},
        { 500, "The web server can't come out to play today."}
    };

    // Now, you can use them with Dictionary<TKey,TValue> collections and similar types. The new syntax supports assignment using an index into the collection
    private Dictionary<int, string> webErrors = new Dictionary<int, string>
    {
        [404] = "Page not Found",
        [302] = "Page moved, but left a forwarding address.",
        [500] = "The web server can't come out to play today."
    };
    // This feature means that associative containers can be initialized using syntax similar to what's been in place for sequence containers for several versions.

    public void Method()
    { 
        WriteLine("10. Index initializers");
        WriteLine("messages");
        messages.ForEach(WriteLine);
        WriteLine("webErrs");
        webErrs.ToList().ForEach(kvp => WriteLine("Key: " + kvp.Key + ", Value: " + kvp.Value));
        WriteLine("webErrors");
        webErrors.ToList().ForEach(kvp => WriteLine("Key: " + kvp.Key + ", Value: " + kvp.Value));
    }
}

class IndexInitializersClient
{
    public void Print()
    {        
        IndexInitializers indexInitializer = new IndexInitializers();
        indexInitializer.Method();
    }
}

// 11. Extension methods for collection initializers
// Extension Add methods in collection initializers
// Another feature that makes collection initialization easier is the ability to use an extension method for the Add method. This feature was added for parity with Visual Basic.
// The feature is most useful when you have a custom collection class that has a method with a different name to semantically add new items.
// For example, consider a collection of students like this:
// Consistent accessibility // public class Enrollment<T> : IEnumerable<T>
class Enrollment<T> : IEnumerable<T>
{
    private List<Student> allStudents = new List<Student>();
    
    // The Enroll method adds a student
    // However it doesn't follow the Add pattern
    // In previous versions of C#, you could not use collection initializers with an Enrollment object
    /*
    public void Add(Student s)
    {
        allStudents.Add(s);
    }
    */
    public void Enroll(Student s)
    {
        allStudents.Add(s);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return ((IEnumerable<T>)allStudents).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<Student>)allStudents).GetEnumerator();
    }
}

// 11. Extension methods for collection initializers
// Consistent accessibility // public static class StudentExtensions
static class StudentExtensions
{
    public static void Add(this Enrollment<Student> e, Student s) => e.Enroll(s);
}

class ExtensionMethodsCollectionInitializersClient
{
    public void Print()
    {
        WriteLine("11. Extension methods for collection initializers");
        var classList = new Enrollment<Student>()
        {
            new Student("Lessie", "Crosby"),
            new Student("Vicki", "Petty"),
            new Student("Ofelia", "Hobbs"),
            new Student("Leah", "Kinney"),
            new Student("Alton", "Stoker"),
            new Student("Luella", "Ferrell"),
            new Student("Marcy", "Riggs"),
            new Student("Ida", "Bean"),
            new Student("Ollie", "Cottle"),
            new Student("Tommy", "Broadnax"),
            new Student("Jody", "Yates"),
            new Student("Marguerite", "Dawson"),
            new Student("Francisca", "Barnett"),
            new Student("Arlene", "Velasquez"),
            new Student("Jodi", "Green"),
            new Student("Fran", "Mosley"),
            new Student("Taylor", "Nesmith"),
            new Student("Ernesto", "Greathouse"),
            new Student("Margret", "Albert"),
            new Student("Pansy", "House"),
            new Student("Sharon", "Byrd"),
            new Student("Keith", "Roldan"),
            new Student("Martha", "Miranda"),
            new Student("Kari", "Campos"),
            new Student("Muriel", "Middleton"),
            new Student("Georgette", "Jarvis"),
            new Student("Pam", "Boyle"),
            new Student("Deena", "Travis"),
            new Student("Cary", "Totten"),
            new Student("Althea", "Goodwin")
        };

        IEnumerator<Student> enumeratorStudentclassList = classList.GetEnumerator();
        while (enumeratorStudentclassList.MoveNext())
        {
            WriteLine("{0} {1}", enumeratorStudentclassList.Current.firstName, enumeratorStudentclassList.Current.lastName);
        }

        /*
        foreach (Student stdnt in classList)
        {
            WriteLine("{0} {1}", stdnt.firstName, stdnt.lastName);
        }
        */
    }
}

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
        WriteLine("12. Improved overload resolution");
        // In earlier versions of C#, calling that method using the method group syntax would fail
        Task.Run(DoThings);  // The C# 6 compiler correctly determines that Task.Run(Func<Task>()) is a better choice

        // The earlier compiler could not distinguish correctly between Task.Run(Action) and Task.Run(Func<Task>())
        // In previous versions, you'd need to use a lambda expression as an argument        
        Task t = Task.Run(() => DoThings());        
        WriteLine(t.IsCompleted);        
    } 
}

class Program
{
    static void Main()
    {
        Features feature = new Features();
        feature.Print();
        
        EventClient evntClient = new EventClient();
        evntClient.Print();

        ExceptionFiltersClient exceptionFilterClient = new ExceptionFiltersClient();
        exceptionFilterClient.Print();

        NameofExpressionsClient nameofExpression = new NameofExpressionsClient();
        nameofExpression.Print();

        AwaitInCatchAndFinallyClient awaitInCatchFinally = new  AwaitInCatchAndFinallyClient();
        awaitInCatchFinally.Print();

        IndexInitializersClient indexInitializer = new IndexInitializersClient();
        indexInitializer.Print();

        ExtensionMethodsCollectionInitializersClient extensionMethodsCollectionInitializer = new ExtensionMethodsCollectionInitializersClient();
        extensionMethodsCollectionInitializer.Print();

        ImprovedOverloadResolution overloadResolution = new ImprovedOverloadResolution();
        overloadResolution.Print();

        WriteLine("13. Deterministic compiler output");
        WriteLine("The -deterministic option instructs the compiler to produce a byte-for-byte identical output assembly for successive compilations of the same source files. By default, every compilation produces unique output on each compilation. The compiler adds a timestamp, and a GUID generated from random numbers. You use this option if you want to compare the byte-for-byte output to ensure consistency across builds.");
    }         
}

// Output
/*
Pet Names - LINQ:
Barley
Boots
Whiskers
Pet Ages - LINQ:
10
4
6
Pet Count - LINQ:
3
Pet Name Aggregate - LINQ:
Whiskers, Boots, Barley
Pet Age Aggregate - LINQ:
20
Pet Names - Lambda:
Barley
Boots
Whiskers
Pet Ages - Lambda:
10
4
6
Pet Count - Lambda:
3
Pet Name Aggregate - Lambda:
Whiskers, Boots, Barley
Pet Age Aggregate - Lambda:
20
1. Read-only auto-properties
X = 1
Y = 2
2. Auto-Property Initializers:
Property: 2.23606797749979
3. Expression-bodied function members
Method: 1, 2
4. using static
Import static members of the type direcly into scope
MakesPetsList: True
Overloading binary operator + to add objects: z = x + y
Operator: (4, 6)
5. Null-conditional operators
First Coordinate: 1
First Coordinate: 1
5. Null-conditional operators ?. and ?[]
NaN
6
NaN
6. String Interpolation
Average = 6.66666666666667
Average = 6.66666666666667
Average = 6.67
Average = 6.67
Average = 6.67
Average = 6.67
Event #0 received by X object
Source: EventContainer
Event #0 received by Y object
Source: EventContainer
Event #1 received by X object
Source: EventContainer
Event #1 received by Y object
Source: EventContainer
7. Exception Filters
Perform Failing Operation
8. nameof Expressions
LastName: LastName
9. await in catch and finally blocks
10. Index initializers
messages
Page not Found
Page moved, but left a forwarding address.
The web server can't come out to play today.
webErrs
Key: 404, Value: Page not Found
Key: 302, Value: Page moved, but left a forwarding address.
Key: 500, Value: The web server can't come out to play today.
webErrors
Key: 404, Value: Page not Found
Key: 302, Value: Page moved, but left a forwarding address.
Key: 500, Value: The web server can't come out to play today.
11. Extension methods for collection initializers
Lessie Crosby
Vicki Petty
Ofelia Hobbs
Leah Kinney
Alton Stoker
Luella Ferrell
Marcy Riggs
Ida Bean
Ollie Cottle
Tommy Broadnax
Jody Yates
Marguerite Dawson
Francisca Barnett
Arlene Velasquez
Jodi Green
Fran Mosley
Taylor Nesmith
Ernesto Greathouse
Margret Albert
Pansy House
Sharon Byrd
Keith Roldan
Martha Miranda
Kari Campos
Muriel Middleton
Georgette Jarvis
Pam Boyle
Deena Travis
Cary Totten
Althea Goodwin
12. Improved overload resolution
False
13. Deterministic compiler output
The -deterministic option instructs the compiler to produce a byte-for-byte identical output assembly for successive compilations of the same source files. By default, every compilation produces unique output on each compilation. The compiler adds a timestamp, and a GUID generated from random numbers. You use this option if you want to compare the byte-for-byte output to ensure consistency across builds.
*/

/*
Courtesy:
https://docs.microsoft.com
*/