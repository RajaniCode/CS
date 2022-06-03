// Exception Handling // manually throw Exception


using System;

class MyClass
{
    int i;
        
    int n;

    int z = 0;

    public int myMethod()
    {
        try
        {
            i = 5;
            // n = i/z; // NOTE the difference 
            return i;            
        }
         
        catch(Exception)
        {   
            i = 7;         
            Console.WriteLine("Exception caught");                        
        }        
        finally
        {  
            i = 10;                     
        }
         
        return i;
    }    
}

class MainClass
{
    static void Main()
    {
        int a;

        MyClass mc = new MyClass();

        a = mc.myMethod();
      
        Console.WriteLine(a);
    }
}
         