using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSC2008ListArrayInstance
{
    class Program
    {
        int[] A = new int[1];

        List<int> B = new List<int>();

        int C;

        private void StoreRandomNumber()
        {
            Random Rnm = new Random();
            A[0] = Rnm.Next(100);
            B.Add(Rnm.Next(100));
        }

        private void StoreNumber(/*int[] D, List<int> E,*/ int F)
        {
            //D[0] = StoreRandomNumber();
            //E.Add(StoreRandomNumber());

            //D[0] = 100;
            //E.Add(200);
            F = 300;
        }

        static void Main()
        {
            Program p = new Program();

            p.StoreNumber(/*p.A, p.B,*/ p.C);

            Console.WriteLine("A[0] = " + p.A[0]);

            if (p.B.Count > 0)
            {
                Console.WriteLine("B[0] = " + p.B[0]);
            }

            Console.WriteLine("C = " + p.C);

            Console.ReadKey();
        }
    }
}
