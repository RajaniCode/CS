// Fibonacci


using System;

class MainClass
{
    public static void Main()
    {
        int lo = 1;
        int hi = 1;
        int n;
        Console.WriteLine("Fibonacci series: ");
        Console.WriteLine("Enter a positive integer less than which fibonacci series is to be displayed: ");
        n = int.Parse(Console.ReadLine());
        Console.WriteLine("Fibonacci series less than " + n + " is: ");
        Console.Write(lo);
        while (hi < n)
        {
            Console.Write(", " + hi);
            hi = lo + hi;
            lo = hi - lo;
        }
    }
}
