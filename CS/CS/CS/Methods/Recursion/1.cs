// Recursion // Factorial


using System;

class MyClass
{
    int result;

    public int factorialMethod(int n)
    {
        
        if(n==0 || n==1)
            return 1;       
        
        result = n * factorialMethod(n-1);
        return result;
    }
   
    public int iterativeMethod(int n)
    {
        if(n==1 || n==0)
            return 1;
  
        result = 1;  // NOTE

        for(int i=1; i<=n; i++)
        {
            result *= i;
        }
        
        return result;
    }
}

class MainClass
{
    static void Main()
    {
        MyClass mc = new MyClass();

        Console.WriteLine("Enter integer:");
       
        int i = int.Parse(Console.ReadLine());

        if(i<0)
        {
            Console.WriteLine("Integer should be >= 0");
            return;
        }       
 
        Console.WriteLine("Recursive Method");
        Console.WriteLine("The factorial of {0} = {1}", i, mc.factorialMethod(i));
        
        Console.WriteLine("Iterative Method");
        Console.WriteLine("The factorial of {0} = {1}", i, mc.iterativeMethod(i));      
    }
}