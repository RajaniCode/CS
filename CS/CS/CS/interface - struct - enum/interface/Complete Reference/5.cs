// interface // interface cannot have static members

// interface methods implemented by different classes


using System;

interface InterfaceExample
{
    int nextMethod();
    void resetMethod();
    void fromMethod(int f);
}

class MyClass1 : InterfaceExample  // Note
{
    int initial;
    int result;

    public MyClass1()
    {
        initial = 0;
        result = 0;
    }

    public int nextMethod()
    {
        result += 2;
        return result;
    }

    public void resetMethod()
    {
        result = initial;
    }

    public void fromMethod(int f)
    {
        initial = f;
        result = initial;
    }
}

class MyClass2 : InterfaceExample  // Note
{  
    int initial;
    int result;
    

    public MyClass2()
    {
        initial = 2;
        result = 2;
    }

    public int nextMethod()
    {   
        int i;
        int j;
        bool isprime;       

        result++; // Note

        for(i=result; i<100000; i++)  // Note
        {
            isprime = true;
            for(j=2; j<(i/j + 1); j++)  // Note
            {
                if(i%j == 0)
                {
                    isprime = false;
                    break; // Note
                }
            }
            if(isprime)
            {
                result = i;
                break; // Note
            }
        }
        return result;
    }

    public void resetMethod()
    {
        result = initial;
    }
    
    public void fromMethod(int f)
    {
        initial = f;
        result = initial;
    }
}

class MainClass
{
    static void Main()
    {
        MyClass1 mc1 = new MyClass1();

        MyClass2 mc2 = new MyClass2();
   
        InterfaceExample ie;  // Note

        ie = mc1;  // Note

        Console.WriteLine("Enter how many even/odd/prime numbers you want: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("First " + n + " even numbers");
        for(int i=0; i<n; i++)
            Console.WriteLine(ie.nextMethod()); // (mc1.nextMethod());
        Console.WriteLine();

        
        Console.WriteLine("First " + n + " odd numbers");
        ie.fromMethod(1);
        for(int i=0; i<n; i++)
            Console.WriteLine(ie.nextMethod()); // (mc1.nextMethod());
        Console.WriteLine();
      


        ie = mc2; // Note

        Console.WriteLine("First " + n + " prime numbers");
        for(int i=0; i<n; i++)
            Console.WriteLine(ie.nextMethod()); // (mc2.nextMethod());
        Console.WriteLine();
    }
}
            
       

   
       
        
        
    
    
    