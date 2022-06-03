// Exception Handling // multiple catch


using System;

class MainClass
{
    static void Main()
    {
        int[] numerator = {4, 8, 0, 16, 18, -20, 24, 100, 200, 300}; // Note
        int[] denominator = {2, 4, 6, 8, 0, 10, -12, 100}; // Note

        for(int i=0; i<numerator.Length; i++) // Note
        {
            try // Note
            {
                Console.WriteLine(numerator[i] + " / " + denominator[i] + " = " + numerator[i]/denominator[i]);
            }
       
            catch(DivideByZeroException) // Note
            {
                Console.WriteLine("Can't divide by zero");
        
            }
            
            catch(IndexOutOfRangeException) // Note
            {
                Console.WriteLine("No denominator found");
            }        
        }
    }
}
    
           