// CS 3
/*
1. Implicitly Typed Local Variables
2. Implicitly Typed Arrays
3. Query Expressions (LINQ)
4. Anonymous Types
5. Object and Collection Initializers
6. Extension Methods
7. Lambda Expressions
8. Expression Trees
9. Automatically Implemented Properties
10. Partial Classes and Methods (Partial Classes, Structs, and Interfaces were available in CS 2)
*/

// Note
// LINQ is supported by a set of interrelated features including the query syntax, Lambda Expressions, Anonymous Types, and Extension Methods
// Anonymous Type directly relates to LINQ
// Anonymous type is a class that has no name
// The primary use of Anonymous Type is to create an object returned by the select clause
// The primary use of the object initializer syntax is with Anonymous Types created in a LINQ expression

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExtensionMethods;

delegate int Delegates(int i); //

class Program
 {
    // delegate int Delegates(int i);

    // 2. Implicitly Typed Arrays
    object implicitlyTypedArray = new[] { 1, 10, 100, 1000 }; // int[]

    private void Print()
    {
        Console.WriteLine("1. Implicitly Typed Local Variables: var");
        var implicitlyTypedString = "Hello, World!";
        Console.WriteLine(implicitlyTypedString);
        Console.WriteLine();

        Console.WriteLine("2. Implicitly Typed Arrays");
        int[] intArray = implicitlyTypedArray as int[];
        intArray.ToList().ForEach(Console.WriteLine);

        var implicitlyTypedIntArray = new[] { 1, 10, 100, 1000 }; // int[]
        implicitlyTypedIntArray.ToList().ForEach(Console.WriteLine);

        var implicitlyTypedStringArray = new[] { "hello", null, "world" }; // string[]
            implicitlyTypedStringArray.ToList().ForEach(Console.WriteLine);

        int[,] twoDimensionArray = new int[,] { { 3, 5}, { 7, 11 }, { 13, 17} };
        foreach (int intgr in twoDimensionArray)
        {
            System.Console.Write("{0} ", intgr);
        }
        Console.WriteLine();

        int[,] implicitlyTypedTwoDimensionArray = new[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
        Console.WriteLine("To print 5: " + implicitlyTypedTwoDimensionArray[2, 0]);

        // single-dimension jagged array of integers
        var implicitlyTypedSingleDimensionJaggedArray = new[] { new[]{1,2,3}, new[]{4,5,6,7}, };

        Console.WriteLine("To print 5: " + implicitlyTypedSingleDimensionJaggedArray[1][1]);

        // Two-dimension jagged array of strings
        var implicitlyTypedTwoDimensionJaggedArray = new[] { new[,]{{"Bill", "Gates"}, {"Anders", "Heilsberg"}}, new[,]{{"Larry", "Page"}, {"Mark", "Zuckerberg"}, {"Jack", "Dorsey"}}, };

        Console.WriteLine("To print Zuckerberg: " + implicitlyTypedTwoDimensionJaggedArray[1][1, 1]);
        Console.WriteLine();

        Console.WriteLine("3. LINQ, 4. Anonymous Types, 5. Object and Collection Initializers");
        // 5. Object Initializers
        var anonymousType = new { Name = "Anonymous", Number = 0 };
        Console.WriteLine("Name = {0}, Number = {1}", anonymousType.Name, anonymousType.Number);

        // 5. Collection Initializers
        // () is optional
        List<Product> products = new List<Product>()
        {
            new Product(){Color = "Red", Flag = -1},
            new Product(){Color = "Amber", Flag = 0},
            new Product(){Color = "Green", Flag = 1},
        };
        
        // 3. LINQ
        // 4. Anonymous Types
        // 5. Collection Initializers
        var rowset = from p in products
                               select new { p.Color, Semaphore = p.Flag };

        foreach (var row in rowset)
        {
            Console.WriteLine("Color = {0}, Semaphore = {1}", row.Color, row.Semaphore);
        }

        // var implicitlyTypedLocalVaraibleArray = new[] { 1, 10, 100, 1000 }; // int[]

        // 4. Anonymous Types
        var anonymousTypeArray = new[] { new { Fruit = "Apple", Price = 10 }, new { Fruit = "Grape", Price = 5 } };

        foreach (var arr in anonymousTypeArray)
        {
            Console.WriteLine("Fruit = {0}, Flag = {1:C}", arr.Fruit, arr.Price);
        }

        for (var index = 0; index < anonymousTypeArray.Length; index++)
        {
            Console.WriteLine("Flag = {0:C}, Fruit = {1}, ", anonymousTypeArray[index].Price, anonymousTypeArray[index].Fruit);
        }

        // 5. Collection Initializers
        var integers = new List<int>()
        {
            1, 2, 3, 4, 5,
        };

        foreach (var intgr in integers)
        {
            Console.Write(intgr + " ");
        }
        Console.WriteLine();

        int number = 2;

        // 5. Collection Initializers
        var intergerList = new List<int> { -2 + 12, 40 / 2, 150 % 40, 10 * GetSquare(number), 50 };

        foreach (var intgr in intergerList)
        {
            Console.Write(intgr + " ");
        }
        Console.WriteLine("\n");

        Console.WriteLine("6. Extension Methods");
        int[] numbers = { 1, 5, 4, 8, 9, 2, 7, 3, 6 };
        var numbersOrderBy = numbers.OrderBy(l => l);

        foreach (var intgr in numbersOrderBy)
        {
            Console.Write(intgr + " ");
        }
        Console.WriteLine();

        string line = "Hello World!";
        Console.WriteLine("Number of words in \"{0}\" = {1}", line, line.WordCount());
        Console.WriteLine();

        Console.WriteLine("7. Lambda Expressions");
        Delegates delegatesObject = x => x * x;
        Console.WriteLine(delegatesObject(5));

        Expression<Delegates> expressionTreeType = y => y * y * y;

        // Compiling the expression tree into a delegate.
        var expressionTree = expressionTreeType.Compile();
        delegatesObject = expressionTreeType.Compile();

        // Invoking the delegate and writing the result to the console.
        Console.WriteLine(expressionTree(5));
        Console.WriteLine(delegatesObject(5));
        Console.WriteLine();

        Console.WriteLine("8. Expression Trees");
        // Manually build the expression tree for the lambda expression num => num < 5
        ParameterExpression numParam = Expression.Parameter(typeof(int), "num");
        ConstantExpression five = Expression.Constant(5, typeof(int));
        BinaryExpression numLessThanFive = Expression.LessThan(numParam, five);

        Expression<Func<int, bool>> lamb = Expression.Lambda<Func<int, bool>>(numLessThanFive, new ParameterExpression[] { numParam });
        Console.WriteLine(lamb);

        // Create an expression tree
        Expression<Func<int, bool>> exprTree = num => num < 7;
        // Decompose the expression tree.
        ParameterExpression param = (ParameterExpression)exprTree.Parameters[0];
        BinaryExpression operation = (BinaryExpression)exprTree.Body;
        ParameterExpression left = (ParameterExpression)operation.Left;
        ConstantExpression right = (ConstantExpression)operation.Right;
        // This code produces the following output
        // Decomposed expression: num => num LessThan 7  
        Console.WriteLine("Decomposed expression: {0} => {1} {2} {3}", param.Name, left.Name, operation.NodeType, right.Value);

        // Creating an expression tree
        Expression<Func<int, bool>> expr = num => num < 5;
        // Compiling the expression tree into a delegate
        Func<int, bool> result = expr.Compile();
        // Invoking the delegate and writing the result to the console
        Console.WriteLine(result(4)); // Prints True
        // You can also use simplified syntax to compile and run an expression tree
        // The following line can replace two previous statements
        Console.WriteLine(expr.Compile()(4)); // Also prints True
        Console.WriteLine();
            
        Console.WriteLine("9. Automatically Implemented Properties");
        Product prod = new Product();
        prod.Color = "Blue";
        prod.Flag = 5;
        Console.WriteLine("Product Color: {0}, Product Flag: {1}", prod.Color, prod.Flag);
        Console.WriteLine();

        Console.WriteLine("10. Partial Classes and Methods");
        CoOrdinates coords = new CoOrdinates(5, 10);
        coords.PrintCoOrdinates();
    }

    private int GetSquare(int nmbr)
    {
        return nmbr * nmbr;
    }

    static void Main()
    {
        Program prgm = new Program();
        prgm.Print();
    }
}

class Product
{
    // 9. Automatically Implemented Properties
    public string Color
    {
        get;
        set;
    }

    // 9. Automatically Implemented Properties
    public sbyte Flag
    {
        get;
        set;
    }
}

namespace ExtensionMethods
{
    static class Extension // Extension methods must be defined in a non-generic static class	
    {
        // 5. Extension Methods
        public static int WordCount(this string Message)
        {
            return Message.Split(new char[] { ' ', '!' }, StringSplitOptions.RemoveEmptyEntries).Length;            
        }
    }
}

// 10. Partial Classes (Partial Classes Structs and Interfaces were available in C# 2.0) and Methods
// It is possible to split the definition of a class or a struct, an interface or a method over two or more source files. 
// Each source file contains a section of the type or method definition, and all parts are combined when the application is compiled.
public partial class CoOrdinates // public partial struct CoOrdinates // All should be structs
{
    private int x;
    private int y;

    public CoOrdinates(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    // A partial method must be declared within a partial class or partial struct	
    // Signatures in both parts of the partial type must match.
    // The method must return void.
    // No access modifiers or attributes are allowed. Partial methods are implicitly private.
    // Can be static - both partial method declarations must be static or neither may be static
    // The 'partial' modifier can only appear immediately before 'class', 'struct', 'interface', or 'void'	
    // A partial method may not have multiple implementing declarations - Max 2 - 1 declaration - MUST (can be called without implementation) and 1 implementation	
    partial void PartialMedthod();    
}

// This part can be in a separate file
public partial class CoOrdinates // public partial struct CoOrdinates // All should be structs
{
    public void PrintCoOrdinates()
    {
        Console.WriteLine("Co-ordinates: {0},{1}", x, y);
        PartialMedthod();
        StaticPartialMedthod();
    }

    partial void PartialMedthod()
    {
        Console.WriteLine("This is partial method!");
    }   

    static partial void StaticPartialMedthod();
}

// This part can be in a separate file
public partial class CoOrdinates // public partial struct CoOrdinates // All should be structs
{
    static partial void StaticPartialMedthod()
    {
        Console.WriteLine("This is static partial method!");
    }
}

partial interface IInterface
{
    void NonPartailMedthod();
}

// This part can be in a separate file.
partial interface IInterface
{
    // Must be different or overloaded
    void NonPartailMedthod(string s);
}


/*
Courtesies:
C# 3.0 The Complete Reference by Herbert Schildt
https://docs.microsoft.com
*/