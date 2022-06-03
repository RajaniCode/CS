// Generic static class // static constructor


using System;

static class G<T> where T : new() 
{
    static T t;

    static G()
    {
         G<T>.t = new T(); // t = new T()
    }

    public static void methodInitialize(T t) // T tp
    {
        G<T>.t = t; // t = tp
    }

    public static T methodTt()
    {
        Console.WriteLine("\nType is: {0}\n", typeof(T));
        return G<T>.t; // return t;
    }
}

static class MainClass // can be static
{
    static void Main()
    {          
        G<double>.methodInitialize(5.5);

        int i = G<int>.methodTt();

        double d = G<double>.methodTt();

        Console.WriteLine(i + "\n");
        Console.WriteLine(d + "\n"); 
    }
}    