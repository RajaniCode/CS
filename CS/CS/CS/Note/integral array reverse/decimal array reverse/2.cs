// decimal array reverse


using System;

class MainClass
{
    static void Main()
    {
        Console.WriteLine("Enter number of elements");
        int n = int.Parse(Console.ReadLine());

        decimal[] array = new decimal[n];
        
        Console.WriteLine("Enter decimal type number(s)"); 
        for(int i=0; i<n; i++) 
        {            
            array[i] = decimal.Parse(Console.ReadLine());
        }

        Array.Reverse(array);

        Console.WriteLine("Array reverse is:");
        for(int i=0; i<n; i++)
            Console.WriteLine(array[i]);
    }  
}