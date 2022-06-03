// input

using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            try
            {
               double.Parse(Console.ReadLine());
               break;            
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter Double");
            }         
        }
    }
}

