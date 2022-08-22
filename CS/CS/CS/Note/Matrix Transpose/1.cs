// Matrix Transpose
 

using System;

class MainClass
{
    static void Main()
    {
        int[ , ] a = new int[20, 20];
        int[ , ] transpose = new int[20, 20];

        for(int i=0; i<20; i++) 
        {
            for(int j=0; j<20; j++)
            {
                a[i, j] = 0;                
                transpose[i, j] = 0;
            }
        }
        

        Console.WriteLine("Enter the number of rows of Matrix:");
        int r = int.Parse(Console.ReadLine());
           
        Console.WriteLine("Enter the number of columns of Matrix:");
        int c = int.Parse(Console.ReadLine());
   
        Console.WriteLine("Matrix A");
        for(int i=0; i<r; i++) 
        {
            for(int j=0; j<c; j++) 
            {
                Console.WriteLine("Enter element (row"+ (i + 1)  + ", column" + (j + 1) + "):");
                a[i, j] = int.Parse(Console.ReadLine());
            }
        }         

        for(int i=0; i<c; i++)
        {
            for(int j=0; j<r; j++)
                transpose[i, j] = a[j, i];
        }
               
        Console.WriteLine("Matrix Transpose:");
        for(int i=0; i<c; i++)
        {
            for(int j=0; j<r; j++) 
                Console.Write(transpose[i, j] + "\t");
            Console.WriteLine();
        }
    }   
}
