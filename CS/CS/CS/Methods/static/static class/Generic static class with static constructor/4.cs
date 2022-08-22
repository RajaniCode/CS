// Generic static class // static constructor


using System;

class G<T> : object
{
    T t;

    public G()
    {
         t = default(T);
    }

    public void methodInitialize(T tp)
    {
        t = tp;
    }

    public T methodTt()
    {
        Console.WriteLine("\nType is: {0}\n", typeof(T));
        return t;
    }
}

class MainClass 
{
    void instanceMainClass()
    {          
        G<object> Go = new G<object>();
     
        Go.methodInitialize(this);

        object ob = Go.methodTt();

        G<int> Gi = new G<int>();

        int i = Gi.methodTt();

        Console.WriteLine(i + "\n");

        Console.WriteLine(ob + "\n");
    }

    static void Main()
    {
        MainClass mc = new MainClass();

        mc.instanceMainClass();    
    }
}    