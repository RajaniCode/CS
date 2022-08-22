// using outer variables with an anonymous method

using System;

delegate int MyDelegate(int a);

class MainClass
{
    static MyDelegate md() // Note
    {
        int sum = 0; // Note: outer variable stays in existence
        
        MyDelegate mdo = delegate(int a) // Note 
        {
            for(int i=0; i<a; i++)
            {
                Console.WriteLine(i);
                sum += i;
            }
           
            return sum;
        }; // Note
        
        return mdo; // Note 
    }

    static void Main()
    {
        MyDelegate d = md(); // Note 
        
        int result;
        
        result = d(5);
        Console.WriteLine("sum = {0} \n", result);

        result = d(3);
        Console.WriteLine("sum = {0} \n", result);
    }
}