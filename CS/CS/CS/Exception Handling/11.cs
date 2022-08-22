// Exception Handling 

// NullReferenceException 

// Note the term 'Reference', therefore is specific to Instance Methods


using System;

class MyClass
{
    int number;
    
    public MyClass(int n)
    {
        number = n;
    }
       

    public int methodAdd(MyClass ob)
    {
        return number + ob.number;
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
            result = mc1.methodAdd(mc2);
        }
  
        catch(NullReferenceException)
        {
            Console.WriteLine("NullReferenceException");
            Console.WriteLine("Fixing it . . .");
            
            // Fixing
            
            mc2 = new MyClass(9);
            result = mc1.methodAdd(mc2);
        }
        
        Console.WriteLine("The result is = {0}", result);
    }
}
                
    