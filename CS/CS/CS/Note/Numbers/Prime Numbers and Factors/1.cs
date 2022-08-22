// Prime Numbers


using System;
using System.Collections;

class MainClass
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number up to which you want prime numbers:\n");
        int n = int.Parse(Console.ReadLine());
      
        int prime = 0;

        BitArray ba = new BitArray(n, true);
 
        for (int i = 2; i < n; i++)
        {
            if (ba[i])
            {
                for (int j = i * 2; j < n; j += i)
                {
                    ba[j] = false;
                }
            }
        }

        for (int i = 2; i < n; i++)
        {
            if (ba[i])
            {
                prime++;
                Console.WriteLine(i);
            }
        }

        Console.WriteLine("\n" + prime + " primes found in the range 2-" + n);
    }     
}
