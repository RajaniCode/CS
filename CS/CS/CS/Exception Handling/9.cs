// Exception Handling // finally


using System;

class MyClass
{
    public static void myMethod(int n)
    {
        int a;
        int[] array = new int[2];
  
        Console.WriteLine("Receiving: " + n);
        
        try
        {
            switch(n)
            {
                case 0:
                    a = 10 / n;
                    break;
                case 1:
                    array[2] = 2; // Check for: array[n] = 2;
                    break;
                case 2:
                    break; // Note
            }
        }
               
        catch(DivideByZeroException)
        {
            Console.WriteLine("Can't divide by zero");
            // return; // Note
        }

        catch(IndexOutOfRangeException)
        {
            Console.WriteLine("Index out-of-bounds");            
        }

        finally
        {
            Console.WriteLine("Leaving try \n");            
        }  
   }
}

class MainClass
{
    static void Main()
    {
        for(int i=0; i<3; i++) //
            MyClass.myMethod(i); //

    
        /*
        MyClass.myMethod(0);
        MyClass.myMethod(1);
        MyClass.myMethod(2); 
        */
    }
}                         
        
         
