using System;

class MainClass
{
    static float squareroot(float n)
    {
       float i = 0F;
       float x1 = 0F;
       float x2 = 0F;

       while((i*i) <= n)
           i += 0.1F;
           x1 = i;

       for(int j = 0; j < 10; j++)
       {
           x2 = n;
           x2 /= x1;
           x2 += x1;
           x2 /= 2;
           x1 = x2;
       }
       return x2;
    }

    static int Main()
    {
       Console.WriteLine("Enter the number for which square root is to be found:");
       float number = float.Parse(Console.ReadLine());

       Console.WriteLine("The square root for the number is: " + squareroot(number));
       return 0;
    }
}
