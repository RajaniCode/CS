// Perfect Number


using System;

class MainClass
{
    static void Main()
    {
        bool prime = true; 
        int result = 1;        
        Console.WriteLine("Enter the number:");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine();
 
        for(int i=2; i < number; i++) 
        {
            if (number % i == 0) 
            {
                if(prime) 
                {
                    Console.WriteLine(number + " is not a prime number! \n" + number + "'s factors are: ");
                    prime = false;
                }
                Console.WriteLine(i);
                result += i;
            }
        }
   
        if(result==number)
            Console.WriteLine(number + " is a perfect number!\n");
        else
            Console.WriteLine(number + " is not a perfect number!\n"); 
    }
}
    