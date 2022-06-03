// Generic class // creating default object of type parameter


using System;

class MyClass
{

}

class MyStruct
{

}

class G<T>
{
    T t;

    public G()
    {
        t = default(T); // works for both value type and reference type
    }
}

class MainClass
{
    static void Main()
    {
        G<MyClass> GMC = new G<MyClass>();

        G<MyStruct> GMS = new G<MyStruct>();
    }
}
