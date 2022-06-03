// Generic struct

using System;

class MyClass
{

}

class MyStruct
{

}

struct G<T>
{
    T t1;
    T t2;
  
    public G(T t1p, T t2p)
    {
        t1 = t1p;
        t2 = t2p;
    }

    public T property1 // Note: property return type
    {
        get
        {
            return t1;
        }
        set
        {
            t1 = value;
        }
    }
        
    public T property2 // Note: property return type
    {
        get
        {
            return t2;
        }
        set
        {
            t2 = value;
        }
    }
}

struct MainStruct
{
    static void Main()
    {
        G<int> Gi = new G<int>(10, 20);

        G<double> Gd = new G<double>(88.0, 99.0);

        G<MyClass> GMC = new G<MyClass>(new MyClass(), new MyClass());

        G<MyStruct> GMS = new G<MyStruct>(new MyStruct(), new MyStruct());

        Console.WriteLine(Gi.property1 + " " + Gi.property2);

        Console.WriteLine(Gd.property1 + " " + Gd.property2);

        Console.WriteLine(GMC.property1 + " " + GMC.property2);

        Console.WriteLine(GMS.property1 + " " + GMS.property2);
    }
}