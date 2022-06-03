using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSC2008ValueTypeReferenceType
{
    //struct
    class Program
    {
        int X;

        static void Main(string[] args)
        {
            Program A = new Program();
            Program B = new Program();

            A.X = 10;
            B.X = 20;

            //A = B;
            //B = A;
            Console.WriteLine("A.X = {0}, B.X = {1}", A.X, B.X);
            A = B;
            //B = A;

            B.X = 30;
            
            Console.WriteLine("A.X = {0}, B.X = {1}", A.X, B.X);

            Console.ReadKey();
        }
    }
}

/*

class (A = B and B = A):
A.X = 10, B.X = 20
A.X = 30, B.X = 30
 

struct (A =  B):
A.X = 10, B.X = 20
A.X = 20, B.X = 30


struct (B =  A):
A.X = 10, B.X = 20
A.X = 10, B.X = 30
 
*/