// CS 4
/*
1. Dynamic Binding
2. Optional Parameters
3. Named Arguments
4. Variance - Covariance and Contravariance
5. Tuple
*/

﻿using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

class DynamicBinding
{
    public void Print()
    {
        // class
        object instance = new Maths();
        Type instanceType = instance.GetType();
        object result = instanceType.InvokeMember("IntegerSquare", BindingFlags.InvokeMethod, null, instance, new object[] { 1 });

        int number = (int)result;
        Console.WriteLine("Number using Reflection: " + number);
 
        // Dynamic Binding
        dynamic runtime = new Maths();
        number = runtime.IntegerSquare(2);
        Console.WriteLine("Number using dynamic: " + number);

        // dll
        /*
        Assembly assemblyName = Assembly.LoadFrom("Sample.dll");
        Type assemblyTypeName = assemblyName.GetType("Mathematics.Maths");
        object instance = Activator.CreateInstance(assemblyTypeName);
        object result = assemblyTypeName.InvokeMember("IntegerSquare", BindingFlags.InvokeMethod, null, instance, new object[] { 5 });

        int number = (int)result;
        Console.WriteLine("Number using Reflection: " + number);

        // Dynamic Binding
        dynamic runtime = Activator.CreateInstance(assemblyTypeName);
        number = runtime.IntegerSquare(5);
        Console.WriteLine("Number using dynamic: " + number);
        */
    }
}

class OptionalParameters
{
    int a;
    int b;
    int c;
    int[] integerArray;
    int[] parameterIntegerArray;
    string[ , ] arr = new string[100, 100];

    public OptionalParameters() 
    {
        Console.WriteLine("Explicit default constructor");
    }

    // Constructors can declare Optional Parameters
    public OptionalParameters(int a, int b = 2, int c = 3, int[] integerArray = null, params int[] parameterIntegerArray)
    {
        this.a = a;
        this.b = b;
        this.c = c;
        this.integerArray = integerArray;
        this.parameterIntegerArray = parameterIntegerArray;
    }

    public void PrintMemberVariables()
    {
        Console.WriteLine("a = {0}, b = {1}, c = {2}", a, b, c);

        if(integerArray != null && integerArray.Length > 0)
        {
            Console.WriteLine("Integer Array:");
            integerArray.ToList().ForEach(Console.WriteLine);
        }
        else
        {
            Console.WriteLine("Integer Array is null or empty");
        }

        if(parameterIntegerArray != null && parameterIntegerArray.Length > 0) 
        {
            Console.WriteLine("Parameter Integer Array:");
            parameterIntegerArray.ToList().ForEach(Console.WriteLine);
        }
        else
        {
            Console.WriteLine("Parameter Integer Array is null or empty");
        }
        Console.WriteLine();
    }

    // Methods can declare Optional Parameters
    public void OptionalParametersMethod(string a, string b = "B", string c = "C", string[] stringArray = null, params string[] parameterStringArray)
    {
        Console.WriteLine("a = {0}, b = {1}, c = {2}", a, b, c);

        if(stringArray != null && stringArray.Length > 0)
        {
            Console.WriteLine("String Array:");
            stringArray.ToList().ForEach(Console.WriteLine);
        }
        else
        {
            Console.WriteLine("String Array is null or empty");
        }

        if(parameterStringArray != null && parameterStringArray.Length > 0) 
        {
            Console.WriteLine("Parameter String Array:");
            parameterStringArray.ToList().ForEach(Console.WriteLine);
        }
        else
        {
            Console.WriteLine("Parameter String Array is null or empty");
        }
        Console.WriteLine();
    }

    // Indexers can declare optional parameters
    // Indexer to allow client code to use [ , ] notation
    public string this[int i, int j = 5]
    {
       get { return arr[i, j]; }
       set { arr[i, j] = value; }
    }

    public void CallOptionalParametersConstructor()
    {
        Console.WriteLine("Optional Parameters Constructor");

        Console.WriteLine("()");
        OptionalParameters option = new OptionalParameters();
        // Explicit Default Constructor
        option.PrintMemberVariables();

        Console.WriteLine("(11, 22, 33, 44, 55) will not compile");
        /*
        option = new OptionalParameters(11, 22, 33, 44, 55);
        option.PrintMemberVariables();
        */

        Console.WriteLine("(11, null, null) will not compile");
        /*
        option = new OptionalParameters(11, null, null);
        option.PrintMemberVariables();
        */

        Console.WriteLine("(11, 22, 33, null, 55, 66)");
        OptionalParameters option1 = new OptionalParameters(11, 22, 33, null, 55, 66);
        option1.PrintMemberVariables();

        Console.WriteLine("(111, 222, 333, null, new [] { 555, 666 })");
        OptionalParameters option2 = new OptionalParameters(111, 222, 333, null, new [] { 555, 666 });
        option2.PrintMemberVariables();

        Console.WriteLine("(1111, 2222, 3333 null, null)");
        OptionalParameters option3 = new OptionalParameters(1111, 2222, 3333, null, null);
        option3.PrintMemberVariables();

        Console.WriteLine("(11111, 22222, 33333 null)");
        OptionalParameters option4 = new OptionalParameters(11111, 22222, 33333, null);
        option4.PrintMemberVariables();

        Console.WriteLine("(1)");
        OptionalParameters option5 = new OptionalParameters(1);
        option5.PrintMemberVariables();
    }

    public void CallOptionalParametersMethod()
    {
        Console.WriteLine("Optional Parameters Method");
        Console.WriteLine("(\"AA\", \"BB\", \"CC\", \"DD\", \"EE\") will not compile");
        // OptionalParametersMethod("AA", "BB", "CC", "DD", "EE");

        Console.WriteLine("(\"AA\", null, null) will compile unlike value types");
        OptionalParametersMethod("AA", null, null);

        Console.WriteLine("(\"AAA\", \"BBB\", \"CCC\", null, \"EEE\", \"FFF\")");
        OptionalParametersMethod("AAA", "BBB", "CCC", null, "EEE", "FFF");

        Console.WriteLine("(\"AAAA\", \"BBBB\", \"CCCC\", new[] { \"DDDD\", \"EEEE\" }, \"FFFF\")");
        OptionalParametersMethod("AAAA", "BBBB", "CCCC", new[] { "DDDD", "EEEE" }, "FFFF");

        Console.WriteLine("(\"AAAAA\", \"BBBBB\", \"CCCCC\", null, null)");
        OptionalParametersMethod("AAAAA", "BBBBB", "CCCCC", null, null);

        Console.WriteLine("(\"AAAAAA\", \"BBBBBB\", \"CCCCCC\", null)");
        OptionalParametersMethod("AAAAAA", "BBBBBB", "CCCCCC", null);

        Console.WriteLine("(\"A\")");
        OptionalParametersMethod("A");
    }
    
    public void CallOptionalParametersIndexer()
    {
        Console.WriteLine("Optional Parameters in Indexers");
        OptionalParameters stringArrayLike = new OptionalParameters();
        stringArrayLike[0, 0] = "Hello, World!";
        Console.WriteLine(stringArrayLike[0, 0]);
        stringArrayLike[0, 5] = "Indexer Optional Parameter default value is 5";
        Console.WriteLine(stringArrayLike[0]);
        Console.WriteLine();
    }

    public void Print() 
    {
        CallOptionalParametersConstructor();
        CallOptionalParametersMethod();
        CallOptionalParametersIndexer();
    }
}

class Container
{
    int a;
    int b;
    int c;
    int[] integerArray;
    int[] parameterIntegerArray;
    string[ , ] arr = new string[100, 100];

    public Container() 
    {
        Console.WriteLine("Explicit default constructor");
    }

    public Container(int a, int b = 2, int c = 3, int[] integerArray = null, params int[] parameterIntegerArray)
    {
        this.a = a;
        this.b = b;
        this.c = c;
        this.integerArray = integerArray;
        this.parameterIntegerArray = parameterIntegerArray;
    }

    public void PrintMemberVariables()
    {
        Console.WriteLine("a = {0}, b = {1}, c = {2}", a, b, c);

        if(integerArray != null && integerArray.Length > 0)
        {
            Console.WriteLine("Integer Array:");
            integerArray.ToList().ForEach(Console.WriteLine);
        }
        else
        {
            Console.WriteLine("Integer Array is null or empty");
        }

        if(parameterIntegerArray != null && parameterIntegerArray.Length > 0) 
        {
            Console.WriteLine("Parameter Integer Array:");
            parameterIntegerArray.ToList().ForEach(Console.WriteLine);
        }
        else
        {
            Console.WriteLine("Parameter Integer Array is null or empty");
        }
        Console.WriteLine();
    }

    public void ContainerMethod(string a, string b = "B", string c = "C", string[] stringArray = null, params string[] parameterStringArray)
    {
        Console.WriteLine("a = {0}, b = {1}, c = {2}", a, b, c);

        if(stringArray != null && stringArray.Length > 0)
        {
            Console.WriteLine("String Array:");
            stringArray.ToList().ForEach(Console.WriteLine);
        }
        else
        {
            Console.WriteLine("String Array is null or empty");
        }

        if(parameterStringArray != null && parameterStringArray.Length > 0) 
        {
            Console.WriteLine("Parameter String Array:");
            parameterStringArray.ToList().ForEach(Console.WriteLine);
        }
        else
        {
            Console.WriteLine("Parameter String Array is null or empty");
        }
        Console.WriteLine();
    }

    // Indexer to allow client code to use [ , ] notation
    public string this[int i, int j = 5]
    {
       get { return arr[i, j]; }
       set { arr[i, j] = value; }
    }
}

class NamedArguments
{
    public void CallContainerConstructor()
    {
        Console.WriteLine("()");
        Container caller = new Container();
        // Explicit Default Constructor
        caller.PrintMemberVariables();
        Console.WriteLine("Passing Named Arguments to Constructor");

        Console.WriteLine("(b:22, c:33, a:11, null, 55, 66) will not compile");
        /*
        caller = new Container(b:22, c:33, a:11, null, 55, 66);
        caller.PrintMemberVariables();
        */
        Console.WriteLine("(b:22, c:33, a:11, integerArray: null, parameterIntegerArray: 55, 66) will not compile");
        /*
        caller = new Container(b:22, c:33, a:11, integerArray: null, parameterIntegerArray: 55, 66);
        caller.PrintMemberVariables();
        */
        Console.WriteLine("(null, b:22, c:33, a:11, parameterIntegerArray: new[] { 55, 66 }) will not compile");
        /*
        caller = new Container(null, b:22, c:33, a:11, parameterIntegerArray: new[] { 55, 66 });
        caller.PrintMemberVariables();
        */
        Console.WriteLine("(11, 22, null, c:33, parameterIntegerArray: new[] { 55, 66 }) will not compile");
        /*
        caller = new Container(11, 22, null, c:33, parameterIntegerArray: new[] { 55, 66 });
        caller.PrintMemberVariables();
        */

        Console.WriteLine("(b:22, c:33, a:11, integerArray: null, parameterIntegerArray: new[] { 55, 66 })");
        Container caller1 = new Container(b:22, c:33, a:11, integerArray: null, parameterIntegerArray: new[] { 55, 66 });
        caller1.PrintMemberVariables();

        Console.WriteLine("(111, 222, integerArray: null, c:333, parameterIntegerArray: new[] { 555, 666 })");
        Container caller2 = new Container(111, 222, integerArray: null, c:333, parameterIntegerArray: new[] { 555, 666 });
        caller2.PrintMemberVariables();
        
        Console.WriteLine("(1)");
        Container caller3 = new Container(1);
        caller3.PrintMemberVariables();
    }

    public void CallContainerMethod()
    {
        Container caller = new Container();
        Console.WriteLine("Passing Named Arguments to Method");

        Console.WriteLine("(b:\"BB\", c:\"CC\", a:\"AA\", null, \"EE\", \"FF\") will not compile");
        // caller.ContainerMethod(b:"BB", c:"CC", a:"AA", null, "EE", "FF");
        Console.WriteLine("(b:\"BB\", c:\"CC\", a:\"AA\", stringArray: null, stringParameterArray: \"EE\", \"FF\") will not compile");
        // caller.ContainerMethod(b:"BB", c:"CC", a:-"AA", stringArray: null, stringParameterArray: "EE", "FF");
        Console.WriteLine("(null, b:\"BB\", c:\"CC\", a:\"AA\", parameterStringArray: new[] { \"EE\", \"FF\" }) will not compile");
        // caller.ContainerMethod(null, b:"BB", c:"CC", a: "AA", parameterStringArray: new[] { "EE", "FF" });
         Console.WriteLine("(\"AA\", \"BB\", null, c:\"CC\", stringParameterArray: new[] { \"EE\", \"FF\" }) will not compile");
        // caller.ContainerMethod("AA", "BB", null, c:"CC", parameterStringArray: new[] { "EE", "FF" });
        Console.WriteLine("(b:\"BB\", c:\"CC\", a:\"AA\", stringArray: null, stringParameterArray: new[] { \"EE\", \"FF\" })");
        caller.ContainerMethod(b:"BB", c:"CC", a: "AA", stringArray: null, parameterStringArray: new[] { "EE", "FF" });

        Console.WriteLine("(\"AAA\", \"BBB\", stringArray: null, c:\"CCC\", stringParameterArray: new[] { \"EEE\", \"FFF\" })");
        caller.ContainerMethod("AAA", "BBB", stringArray: null, c:"CCC", parameterStringArray: new[] { "EEE", "FFF" });

        Console.WriteLine("(\"A\")");
        caller.ContainerMethod("A");
    }

    public void CallContainerIndexer()
    {
        Console.WriteLine("Passing Named Arguments to Indexers");
        Container stringArrayLike = new Container();
        stringArrayLike[0,0] = "Hello, World!";
        Console.WriteLine(stringArrayLike[0, 0]);
        stringArrayLike[0, 5] = "Indexer Named Arguments [j:5, i:0]";
        Console.WriteLine(stringArrayLike[j:5, i:0]);
        Console.WriteLine();
    }

    private void Foo(int j, int k)
    {
        Console.WriteLine("j = {0}, k = {1}", j, k);
        Console.WriteLine();
    }

    private void Bar()
    {
        int i = 0;
        Console.WriteLine("Interdependent side-effecting expression");
        Foo(k: ++i, j: --i); // ++i is evaluated first though not recommended
        Console.WriteLine();
    }

    public void Print() 
    {
        CallContainerConstructor();
        CallContainerMethod();
        CallContainerIndexer();
        Bar();
    }
}

// Variance
// CS 4 Covariance and Contravariance
class CovarianceContravarianceCS4
{
    object GetObject() { return null; }
    void SetObject(object obj) { Console.WriteLine(obj); }

    string GetString() { return ""; }
    static void SetString(string str) { Console.WriteLine(str); }

    public void Print()
    {
        // Difference between assignment compatibility, covariance, and contravariance.

        // Assignment compatibility
        string str = "Covariance and Contravariance";
        // An object of a more derived type is assigned to an object of a less derived type
        object obj = str;
        Console.WriteLine(obj);
        
        // Covariance and contravariance in generic interfaces and delegates allow for implicit conversion of generic type parameters
        // The following code example shows implicit reference conversion for generic interfaces
        // A generic interface or delegate is called variant if its generic parameters are declared covariant or contravariant
        // And enable you to create your own variant interfaces and delegates

        // Covariance
        IEnumerable<string> strings = new List<string>();
        // An object that is instantiated with a more derived type argument is assigned to an object instantiated with a less derived type argument
        // Assignment compatibility is preserved
        IEnumerable<object> objects = strings;
        // objects = new List<string>() {"Alpha", "Beta", "Gamma", "Delta", "Epsilon" };
        objects = new[] {"Alpha", "Beta", "Gamma", "Delta", "Epsilon" };
        // objects.ToList().ForEach(Console.WriteLine);
        foreach(string s in objects)
        {
            Console.WriteLine(s);
        }

        // Contravariance
        Action<object> actObject = SetObject;
        // An object that is instantiated with a less derived type argument is assigned to an object instantiated with a more derived type argument
        // SetObject("Hello, World!");
        // Assignment compatibility is reversed
        Action<string> actString = actObject;
        actString ("Hello, World!");

        // Covariance for arrays enables implicit conversion of an array of a more derived type to an array of a less derived type
        // However this operations is not type safe, as shown in the following code example
        #pragma warning disable 0219
        object[] array = new String[10]; // warning 0219
        // The following statement produces a run-time exception
        // array[0] = 10;

        // Covariance and contravariance support for method groups allows for matching method signatures with delegate types
        // This enables you to assign to delegates not only methods that have matching signatures, but also methods that return more derived types (covariance) or that accept parameters that have less derived types (contravariance) than that specified by the delegate type
        // The following code example shows covariance and contravariance support for method groups

        // Covariance
        // A delegate specifies a return type as object, however you can assign a method that returns a string
        Func<object> delegateReturnType = GetString;
        Console.WriteLine("Return type: {0}", delegateReturnType().GetType());

        // Contravariance
        // A delegate specifies a parameter type as string, however you can assign a method that takes an object.
    Action<string> delegateParameterType = SetObject;
        delegateParameterType("Parameter type as string");
    }
}

class BaseClass { }

class DerivedClass : BaseClass { }

// CS 2 Covariance and Contravariance
delegate BaseClass Covariance();
delegate void Contravariance(DerivedClass dc);

class CovarianceContravarianceCS2
{
    DerivedClass CovarianceMethod()
    {
        DerivedClass dc = new DerivedClass();
        Console.WriteLine("Covariance Method: {0}", dc.GetType());
        return dc;
    }

    void ContravarianceMethod(BaseClass bc)
    {
        Console.WriteLine("Contravariance Method: {0}", bc.GetType());
    }

    public void Print()
    {
        // Delegate Method Group Conversion
        Covariance co = CovarianceMethod; // Covariance co = new Covariance(CovarianceMethod);
        co += CovarianceMethod; // Note
        co -= CovarianceMethod; // Note
        Contravariance contra = ContravarianceMethod; // Contravariance contra = new Contravariance(ContravarianceMethod);
        co();
        DerivedClass dc = new DerivedClass();
        contra(dc); // Note
    }
}

class Tuples
{
    public void Print()
    {
         Console.WriteLine("Tuples");
        // An instance of a tuple class can be created by calling its class constructor
        var newYork = new Tuple<string, int, int, int, int, int, int>("New York", 7891957, 7781984, 7894862, 7071639, 7322564, 8008278);
        Console.WriteLine("A 7-tuple or septuple that contains population data for New York City for each census from 1950 through 2000: {0}", newYork);
        Console.WriteLine();
        Console.WriteLine("New York Lowercase: {0}", newYork.Item1.ToLower());
        Console.WriteLine();

        // Creating the same tuple object by using a helper method is more straightforward
        var bigApple = Tuple.Create("New York", 7891957, 7781984, 7894862, 7071639, 7322564, 8008278);
        Console.WriteLine("A 7-tuple or septuple that contains population data for New York City for each census from 1950 through 2000: {0}", bigApple);
        Console.WriteLine();
        Console.WriteLine("New York Uppercase: {0}", bigApple.Item1.ToUpper());
        Console.WriteLine();

        // Comparing Tuples
        // Tuples are classes (and therefore reference types) therefore, comparing two distinct instances with the equality operator returns false however, the Equals method is overridden to compare each individual element instead:
        // False
        Console.WriteLine("newYork == bigApple: {0}",  newYork == bigApple);
        // True
        Console.WriteLine("newYork.Equals(bigApple): {0}", newYork.Equals(bigApple));
        Console.WriteLine();

        Console.WriteLine("Tuple Item Property cannot be assigned to (it is read-only)");
        Console.WriteLine("371 is an Armstrong Number since 3**3 + 7**3 + 1**3 = 371");
        var t = Tuple.Create(3, 7, 1, "Armstrong Number Digits");
         var armstrongNumber = Math.Pow(t.Item1, 3) + Math.Pow(t.Item2, 3) + Math.Pow(t.Item3, 3);
        Console.WriteLine("Armstrong Number: {0}", armstrongNumber);
        Console.WriteLine();

        // The Create() helper methods directly support the creation of tuple objects that have from one to eight components (that is, singletons through octuples)
        // Although there is no practical limit to the number of components a tuple may have, helper methods are not available to create a tuple with nine or more components
        // To create such a tuple, the Tuple<(Of <(T1, T2, T3, T4, T5, T6, T7, TRest>)>).Tuple<(Of <(T1, T2, T3, T4, T5, T6, T7, TRest>)>) constructor must be called
        // An 8-tuple (octuple) that contains prime numbers that are less than 20
        var primes = Tuple.Create(2, 3, 5, 7, 11, 13, 17, 19);
        // foreach statement cannot operate on variables of type `System.Tuple<int,int,int,int,int,int,int,System.Tuple<int>>' because it does not contain a definition for `GetEnumerator' or is inaccessible
        Console.WriteLine("An 8-tuple (octuple) that contains prime numbers that are less than 20: {0}", primes);
        Console.WriteLine();

        Console.WriteLine("Prime numbers less than 20: " + "{0}, {1}, {2}, {3}, {4}, {5}, {6}, and {7}", primes.Item1, primes.Item2, primes.Item3, primes.Item4, primes.Item5, primes.Item6, primes.Item7, primes.Rest.Item1);
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        DynamicBinding dynamicBind  = new DynamicBinding();
        dynamicBind.Print();

        OptionalParameters optionalParams = new OptionalParameters();
        optionalParams.Print();

        NamedArguments namedArgs = new NamedArguments();
        namedArgs.Print();

        CovarianceContravarianceCS4 cs4 = new CovarianceContravarianceCS4();
        cs4.Print();
        
        CovarianceContravarianceCS2 cs2 = new CovarianceContravarianceCS2();
        cs2.Print();

        Tuples tupl = new Tuples();
        tupl.Print();
    }
}

class Maths
{
    public int IntegerSquare(int integerNumber)
    {
        return integerNumber * integerNumber;
    }
}

/*
// Sample.dll
// Sample.cs
// csc /target:library Sample.cs
namespace Mathematics
{
    public class Maths
    {
        public int IntegerSquare(int integerNumber)
        {
            return integerNumber * integerNumber;
        }
    }
}
*/


/*
Courtesies:
C# 4.0 The Complete Reference by Herbert Schildt
https://docs.microsoft.com
*/