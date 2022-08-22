// Exception Handling // finally


using System;

class MyClass
{
    public void myMethod(int n)
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
        MyClass mc = new MyClass();
        
        for(int i=0; i<3; i++)
            mc.myMethod(i);
        
        /*
        mc.myMethod(0);
        mc.myMethod(1);
        mc.myMethod(2);
        */
    }
}                         
        
         
