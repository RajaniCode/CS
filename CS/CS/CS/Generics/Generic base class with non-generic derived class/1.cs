// Generic base class with non-generic derived class // extending G<object> etc


using System;

class G<T>
{
    T t;
   
    public G()
    {

    }

    public G(T tp)
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

class DerivedClass : G<object> // #Note: can be any type but will be limited to that type, for example: if int then only int in derived class constructor
{
    public DerivedClass(int s) : base(s)
    {

    }          
}



class MainClass
{
    static void Main()
    {
        G<string> Gs = new G<string>("Hello");

        Gs.methodT();

        Console.WriteLine("\nObject value is: {0}\n", Gs.methodt()); 

        DerivedClass dc = new DerivedClass(100);
 
        dc.methodT();

        Console.WriteLine("\nObject value is: {0}\n", dc.methodt()); 
    
    }
}