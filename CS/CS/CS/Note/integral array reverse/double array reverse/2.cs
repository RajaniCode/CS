// double array reverse


using System;

class MainClass
{
    static void Main()
    {
        Console.WriteLine("Enter number of elements");
        int n = int.Parse(Console.ReadLine());

        double[] array = new double[n];
        
        Console.WriteLine("Enter double type number(S)"); 
        for(int i=0; i<n; i++) 
        {
            
            array[i] = double.Parse(Console.ReadLine());
        }

        Array.Reverse(array);

        Console.WriteLine("Array reverse is:");
        for(int i=0; i<n; i++)
            Console.WriteLine(array[i]);
    }  
}