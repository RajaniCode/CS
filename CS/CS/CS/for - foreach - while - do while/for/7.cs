// for loop


using System;

class MainClass
{
    static void Main()
    {
        bool flag = false;
        
        for (int i = 0; i < 5; i++)
        {
            if (!flag)
                Console.WriteLine("Statement 1");
            else
                Console.WriteLine("Statement 2");

            if (!flag && i == 4)
            {
                i = -1;
                flag = true;
            }

            if (flag && i == 4)
            {
                break;
            }
        }
    }
}

