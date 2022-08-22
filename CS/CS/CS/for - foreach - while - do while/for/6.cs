// for


using System;

class MainClass
{
    static void Main()
    {
        int x; // 
        int i;
        int[] array = new int[10];

        for(i=0; i < 10; i++)
            array[i] += i; // Check for array[i] = i;

        for(i=0; i < 10; i++)
        {
            x = array[i];
            Console.WriteLine("x = " + x);
        }
        // Console.WriteLine("x = " + x); // x should be assigned such as int x = 0;
    }
}

