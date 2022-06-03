// Exception Handling // manually throw Exception


using System;

class MyClass
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Before Exception");
         
            // throw new ArrayTypeMismatchException();
            // throw new DivideByZeroException(); 
            // throw new IndexOutOfRangeException();
            // throw new InvalidCastException();
            // throw new OutOfMemoryException();
            // throw new OverflowException();
            throw new NullReferenceException();
        }
         
        catch
        {
            Console.WriteLine("Exception caught");
        }
         
        Console.WriteLine("After try/catch block");
    }    
}