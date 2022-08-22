// Exception Handling // rethrow Exception


using System;

class MyClass
{
    public static void myMethod()
    {
        int[] numerator = {4, 8, 0, 16, 18, -20, 24, 100, 200, 300}; // Note
        int[] denominator = {2, 4, 6, 8, 0, 10, -12, 100}; // Note

        for(int i=0; i<numerator.Length; i++)
        {
            try
            {
                Console.WriteLine("numerator[i]" + " / " + "denominator[i]" + " = " + numerator[i]/denominator[i]);
            }
    
            catch(DivideByZeroException)
            {
                Console.WriteLine("Can't divide by zero");
            }
 
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("No denominator found");
                throw; // Rethrow Exception
            } 
        }
    }
}

class MainClass
{
    static void Main()
    {
        try
        {
            MyClass.myMethod();
        }

        catch(IndexOutOfRangeException) // Recatch Exception // catch
        {
            Console.WriteLine("Program terminated"); // Recatch Exception
        }
    }
}
        

        
         
                        