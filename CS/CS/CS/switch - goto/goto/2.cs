// goto


using System;

class MainClass
{
    static void Main()
    {
        for(int i = 1; i < 5; i++)
        {
            switch(i)
            {
                case 1:
                    Console.WriteLine("Case 1");
                    goto case 3;
                case 2:
                    Console.WriteLine("Case 2");
                    goto case 1;
                case 3:
                    Console.WriteLine("Case 3");
                    goto default;
                default:
                    Console.WriteLine("Case default");
                    break;
            }
            Console.WriteLine();
        }
    }
}


      