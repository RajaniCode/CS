// decimal array in ascending order


using System;

class MainClass
{
    static void Main()
    {
        Console.WriteLine("Enter number of elements");
        int n = int.Parse(Console.ReadLine());

        decimal[] array = new decimal[n];
        decimal t;
        
        Console.WriteLine("Enter decimal type number(s)"); 
        for(int i=0; i<n; i++)
        {            
            array[i] = decimal.Parse(Console.ReadLine());
        }

        for(int i=0; i<n; i++) 
        {
            for(int j=0 ;j<n-1; j++) 
            {
                if(array[i] < array[j])
                {
                    t = array[i];
                    array[i] = array[j];
                    array[j] = t;
                }
            }
        }

        Console.WriteLine("Array in ascending order is:");
        for(int i=0; i<n; i++)          // for(int i=n-1; i>=0; i--) // descending order
            Console.WriteLine(array[i]);
    }  
}