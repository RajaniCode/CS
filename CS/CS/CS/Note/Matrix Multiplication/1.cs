// Matrix Multiplication
 

using System;

class MainClass
{
    static void Main()
    {
        int[ , ] a = new int[20, 20];
        int[ , ] b = new int[20, 20];
        int[ , ] multiplication = new int[20, 20]; 
        int[ , ] addition = new int[20, 20];
        int[ , ] subtraction = new int[20, 20];

        for(int i=0; i<20; i++) 
        {
            for(int j=0; j<20; j++)
            {
                a[i, j] = 0;
                b[i, j] = 0;
                multiplication[i, j] = 0;
                addition[i, j] = 0;
                subtraction[i, j] = 0;
            }
        }
        

        Console.WriteLine("Enter the number of rows of Matrix A:");
        int rA = int.Parse(Console.ReadLine());
           
        Console.WriteLine("Enter the number of columns of Matrix A:");
        int cA = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Column of A = Row of B:");
        int rB = cA;
           
        Console.WriteLine("Enter the number of columns of Matrix B:");
        int cB = int.Parse(Console.ReadLine());
        
         
        Console.WriteLine("Matrix A");
        
        for(int i=0; i<rA; i++) 
        {
            for(int j=0; j<cA; j++) 
            {
                Console.WriteLine("Enter element (row"+ (i + 1)  + ", column" + (j + 1) + "):");
                a[i, j] = int.Parse(Console.ReadLine());
            }
        }
         
        for(int i=0; i<rB; i++) 
        {
            for(int j=0; j<cB; j++) 
            {
                Console.WriteLine("Enter element (row"+ (i + 1)  + ", column" + (j + 1) + "):");
                b[i, j] = int.Parse(Console.ReadLine());
            }
        }

        if((cA==rB) || (cB==rA))
        {
            for(int r1=0; r1< rA; r1++)
            {
                for(int c2=0; c2<cB; c2++)
                {
                    for(int c1=0; c1<cA; c1++) 
                        multiplication[r1, c2] += a[r1, c1] * b[c1, c2];
                }
            }

            Console.WriteLine("Matrix Multiplication:");
            for(int i=0; i<rA; i++)
            {
                for(int j=0; j<cB; j++) 
                    Console.Write(multiplication[i, j] + "\t");
                Console.WriteLine();
            }
        }

        if(rA == rB)
        {
            for(int i=0; i< rB; i++)
            {
                for(int j=0; j<cB; j++)
                    addition[i, j] = a[i, j] + b[i, j];
            }
        
  
            Console.WriteLine("Matrix Addition:");
            for(int i=0; i<rB; i++)
            {
                for(int j=0; j<cB; j++)
                    Console.Write(addition[i, j] + "\t");
                Console.WriteLine();
            }
        
            for(int i=0; i< rB; i++) 
            {
                for(int j=0; j< cB; j++) 
                    subtraction[i, j] = a[i, j] - b[i, j];
            }

            Console.WriteLine("Matrix Subtraction:");
            for(int i=0; i<rB; i++) 
            {
                for(int j=0; j<cB; j++)
                    Console.Write(subtraction[i, j] + "\t");
                Console.WriteLine();
            }
        }
    }   
}
