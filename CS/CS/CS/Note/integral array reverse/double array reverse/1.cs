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

        Console.WriteLine("Array reverse is:");
        for(int j=n-1; j>=0; j--)
            Console.WriteLine(array[j]);
    }  
}