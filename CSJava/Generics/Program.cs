// Generics // CS // Java
using System;

class Program 
{
    static void Main() 
    {
        Generics<string> genericText = new Generics<string>("Hello, World!");
        String textGenerics = genericText.getObject();
        Console.WriteLine("Object: " + textGenerics);
        genericText.showType();

        Generics<int> genericNumber = new Generics<int>(1234567890);
        int numberGenerics = genericNumber.getObject();
        Console.WriteLine("Object: " + numberGenerics);
        genericNumber.showType();

        NonGenerics nonGenericText = new NonGenerics("Hello, World!");
        String textNonGenerics = (String)nonGenericText.getObject();
        Console.WriteLine("Object: " + textNonGenerics);
        nonGenericText.showType();

        NonGenerics nonGenericNumber = new NonGenerics(1234567890);
        int numberNonGenerics = (int)nonGenericNumber.getObject();
        Console.WriteLine("Object: " + numberNonGenerics);
        nonGenericNumber.showType();
    }
}

class Generics<T> 
{
    T obj;

    public Generics(T obj) 
    {
        this.obj = obj;
    }

    public T getObject() 
    {
        return obj;
    }

    public void showType() 
    {
        Console.WriteLine("Type GetType: " + obj.GetType()); // Java // getClass()
        Console.WriteLine("Type GetType Name: " + obj.GetType().Name); // Java // getClass().getName()
        Console.WriteLine("Type typeof: " + typeof(T)); // Unlike C# // Java only for built-in classes // Object.class
        Console.WriteLine("Type typeof Name: " + typeof(T).Name); // Unlike C# // Java only for built-in classes // Object.class.getName()
    }
}

class NonGenerics 
{
    Object obj;

    public NonGenerics(Object obj) 
    {
        this.obj = obj;
    }

    public Object getObject() 
    {
        return obj;
    }

    public void showType() 
    {
        Console.WriteLine("Type: " + obj.GetType()); // Java // getClass()
	// Console.WriteLine("Type: " + obj.GetType().Name); // Java // getClass().getName()
    }
}

// Output
/*
/Users/rajaniapple/Desktop/Mnemonics/Generics/Program.cs(46,46): warning CS8602: Dereference of a possibly null reference. [/Users/rajaniapple/Desktop/Mnemonics/Generics/Generics.csproj]
Object: Hello, World!
Type GetType: System.String
Type GetType Name: String
Type typeof: System.String
Type typeof Name: String
Object: 1234567890
Type GetType: System.Int32
Type GetType Name: Int32
Type typeof: System.Int32
Type typeof Name: Int32
Object: Hello, World!
Type: System.String
Object: 1234567890
Type: System.Int32
*/