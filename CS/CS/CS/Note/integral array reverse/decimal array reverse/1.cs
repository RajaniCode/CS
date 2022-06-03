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

        Console.WriteLine("Array reverse is:");
        for(int j=n-1; j>=0; j--) 
            Console.WriteLine(array[j]);
    }  
}