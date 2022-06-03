using static System.Console;
using System;

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
    WriteLine(indices);
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
        throw new InvalidOperationException("Not found");
    }
    // Now that the method returns a reference to the integer value in the matrix, you need to modify where it's called
    /*
    var valItem = Find3(matrix, (val) => val == 42);
    WriteLine(valItem);
    valItem = 24;
    WriteLine(matrix[4, 2]);
    */
    // The second WriteLine statement in the example above prints out the value 42, not 24
    // The variable valItem is an int, not a ref int
    // The var keyword enables the compiler to specify the type, but will not implicitly add the ref modifier
    // Instead, the value referred to by the ref return is copied to the variable on the left-hand side of the assignment
    // The variable is not a ref local
    // In order to get the result you want, you need to add the ref modifier to the local variable declaration to make the variable a reference when the return value is a reference:
    /*
    ref var refItem = ref Find3(matrix, (val) => val == 42);
    WriteLine(refItem);
    refItem = 24;
    WriteLine(matrix[4, 2]);
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
        WriteLine("5. ref locals and returns");      
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
                Console.WriteLine("matrix[{0}, {1}] = {2}", i, j, matrix[i, j]);
            }
        }
        */           
        WriteLine("local");
        RefLocalsReturns refLocalReturn = new RefLocalsReturns();       
        var valItem = refLocalReturn.Find3(matrix, (val) => val == 42);
        WriteLine(valItem);
        valItem = 24;
        WriteLine(matrix[4, 2]);

        WriteLine("ref"); 
        ref var refItem = ref refLocalReturn.Find3(matrix, (val) => val == 42);
        WriteLine(refItem);
        refItem = 24;
        WriteLine(matrix[4, 2]);       
    }
}

class Program
{
    static void Main()
    {
        RefLocalsReturnsClient refLocalReturnClient = new RefLocalsReturnsClient();
        refLocalReturnClient.Print();
    }
}