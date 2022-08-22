// returning value from an anonymous method

using System;

delegate int MyDelegate(int a);

class MainClass
{
    static void Main()
    {
       int result;

        MyDelegate md = delegate(int a)
        {
            int sum = 0;
           
            for(int i=0; i<a; i++)
            {
                Console.WriteLine(i);
                sum += i;
            }

            return sum;
        };

        result = md(5); // Note
        Console.WriteLine("sum = {0} \n", result); 

       

        result = md(3); // Note
        Console.WriteLine("sum = {0} \n", result);
    }
}
           
          
             