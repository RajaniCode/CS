// Generic class


using System;

class G<T>
{
    T t;
    
    public G(T tp) // Note
    {
        t = tp;
    }

    public void methodT() 
    {
        Console.WriteLine("\nType is: {0}\n", typeof(T));
    }        

    public T methodt() 
    {
        return t;
    }    
}

class MainClass
{
    static void Main()
    {
        G<int> Gi;
        
        Gi = new G<int>(100); // Note
        
        Gi.methodT();
        
        Console.WriteLine("\nObject value is: {0}\n", Gi.methodt());


       G<string> Gs;
       
       Gs = new G<string>("Bill"); // Note

       Gs.methodT();

       Console.WriteLine("\nObject value is: {0}\n", Gs.methodt());
    }
}    