// Armstrong Number


using System;

class MainClass
{
    public static void Main()
    {
        int d;
        int a = 0;
        int n;
        int t;
        Console.WriteLine("Enter the number: ");
        n = int.Parse(Console.ReadLine());
        t = n;
        while (t != 0)
        {
            d = t % 10;
            a = a + (d * d * d); // a += (d * d * d);
            t = t / 10;
        }
        if (n == a)
        {
            Console.WriteLine(n + " is Armstrong");
        }
        else
        {
            Console.WriteLine(n + " is not Armstrong");
        }
    }
}