// char or int array in alphabetical or ascending order


using System;

class MainClass
{
    static void Main()
    {
        Console.WriteLine("Enter number of elements");
        int n = int.Parse(Console.ReadLine());

        char[] array = new char[n];
        char t;
        
        Console.WriteLine("Enter characters or integers"); 
        for(int i=0; i<n; i++)
        {            
            array[i] = char.Parse(Console.ReadLine());
        }

        for(int i=0; i<n; i++) 
        {
            for(int j=0 ;j< n-1; j++) 
            {
                if(array[i] < array[j]) // NOTE // if(array[i] < array[j]) // reverse alphabetical order or descending
                {
                    t = array[i];
                    array[i] = array[j];
                    array[j] = t;
                }
            }
        }

        Console.WriteLine("Array in alphabetical or ascending order is:");
        for(int i=0; i<n; i++)           // for(int i=n-1; i>=0; i--) // reverse alphabetical order or descending
            Console.WriteLine(array[i]);
    }  
}

