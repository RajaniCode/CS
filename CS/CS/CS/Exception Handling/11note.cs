// Exception Handling 

// No NullReferenceException!!!

// Note the term 'Reference', therefore is specific to Instance Methods

// This program is not recommended, however it is just to know how it works with static methods


using System;

class MyClass
{
    static int number;
    
    public MyClass(int n)
    {
        number = n;
    }
       

    public static int methodAdd(MyClass ob)
    {
        return number + MyClass.number;
    }
}

class MainClass
{
    static void Main()
    {
        int result;   
        
        MyClass mc1 = new MyClass(10);
        
        
        MyClass mc2 = null;
    
        try
        {
            result = MyClass.methodAdd(mc2);
        }
  
        catch(NullReferenceException)
        {
            Console.WriteLine("NullReferenceException");
            Console.WriteLine("Fixing it . . .");
            
            // Fixing
            
            mc2 = new MyClass(9);
            result = MyClass.methodAdd(mc2);
        }       
        
        Console.WriteLine("The result is = {0}", result); // Check the result
    }
}
                
    