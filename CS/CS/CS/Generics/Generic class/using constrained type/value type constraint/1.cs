// Generic class // value type constraint

using System;

class MyClass
{

}

struct MyStruct
{

}

class G<T> where T : struct // value type constraint
{
    T t;
  
    public G(T tp)
    {
        t = tp; // tp ONLY in case of  value type // Also: default(T);
    }
}

class MainClass
{
    static void Main()
    {
        G<MyStruct> GMS = new G<MyStruct>(new MyStruct());

        G<int> Gi = new G<int>(10); // POSSIBLE ONLY in case of value type

        // G<MyClass> GMS = new G<MyClass>(new MyClass()); // NOT POSSIBLE because of value type constraint
    }
}
