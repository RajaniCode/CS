// for 


using System;

class MainClass
{
    static void Main()
    {
        int i;
        int j;
        int temp = 0;

        int n;
        
        Console.WriteLine("Enter the number of elements (integers) in the integer array: ");
        n = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Enter the " + n + " elements (integers)");
        int[] a = new int[n];
        for(i=0; i<a.Length; i++)
            a[i] = int.Parse(Console.ReadLine()); 
           
        for(i=0; i<a.Length; i++) 
            for(j=0; j<a.Length; j++) 
                if(a[i] < a[j]) // Note: (a[i] > a[j]) // Descending order
                {
                     temp = a[i];
		     a[i] = a[j];
		     a[j] = temp;
                }
        Console.WriteLine("Ascending order");
        for(i=0; i<a.Length; i++) 
            Console.WriteLine(a[i]);
        Console.WriteLine("Descending order");
        for(i=a.Length-1; i>=0; i--) 
            Console.WriteLine(a[i]);  
            
    }
}    
     
