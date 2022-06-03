// Prime Numbers


using System;

class MainClass
{
    static void Main()
    {
        int i;
        int j;
         
        int nop = 0;
  
        bool prime;
         
        Console.WriteLine("Enter the number less than which you want prime numbers");
        int n = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Prime numbers");
        for(i=2; i<n; i++)
        {
            prime = true;
            for(j=2; j<(i/2 + 1); j++) 
            {
                if(i%j == 0)
                {
                    prime = false;
                    break;
                }
            }
            if(prime)
            {
                nop++;
                Console.WriteLine(i);                 
            }       
        }
        Console.WriteLine("\n" + nop + " primes found in the range 2-" + n);
    }
}