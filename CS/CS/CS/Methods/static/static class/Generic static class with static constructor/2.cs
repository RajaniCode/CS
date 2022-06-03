// Generic static class // static constructor


using System;

static class G<T> where T : new() 
{
    static T t;

    static G()
    {
        t = new T();         
    }

    public static void methodTt() 
    {   
        Console.WriteLine("\nType is: {0}\n", typeof(T));
        Console.WriteLine("\nObject value is: {0}\n", t);
    }            
}

static class MainClass // can be static
{
    static void Main()
    {          
        G<object>.methodTt();      
    }
}    