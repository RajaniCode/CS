// Generic class // reference type constraint

using System;

struct MyStruct
{

}

class MyClass
{

}

class G<T> where T : class // reference type constraint
{
    T t;
  
    public G()
    {
        t = null; // null ONLY in case of reference type constraint // Also possible: t = default(T);
    }
}

class MainClass
{
    static void Main()
    {
        G<MyClass> GMC = new G<MyClass>();

        // G<int> Gi = new G<int>(); // NOT POSSIBLE because of reference type constraint

        // G<MyStruct> GMS = new G<MyStruct>(); // NOT POSSIBLE because of reference type constraint
    }
}
