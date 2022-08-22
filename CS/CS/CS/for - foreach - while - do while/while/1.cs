// while


using System;

class MainClass
{
    static void Main()
    {
        Console.WriteLine("Printing 1-5");
        int n = 0;
        while(n < 10)
        {
            n++;
            Console.WriteLine(n);
            if(n == 5)
            break;
         }
     }
}
