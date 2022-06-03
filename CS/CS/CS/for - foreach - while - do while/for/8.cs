// for loop


using System;

class MainClass
{   
    static void myMethod(int i, bool flag)
    {
        if (!flag)
            Console.WriteLine(i);
        else
            Console.WriteLine(i);
    }

    static void Main()
    {
        bool flag = false;
        
        for (int i = 0; i < 5; i++)
        {           
            myMethod(i, flag);

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

