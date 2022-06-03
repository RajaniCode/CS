// static class (cannot be sealed, abstract)

// static class cannot have protected or protected internal members but can be protected or protected internal in a class/struct(essentially namespace)

// static class cannot be derived 

// static class can EXTEND (and inherit only static members) only from object


using System;

static class MyClass // static 
{
    public const int x = 100; // Note: Only static and const

    public static int y = 200;  // Note: Only static and const

    public static double reciprocalMethod(double n) // static 
    {
        return 1/n;
    }

    public static double fractionPartMethod(double n) // static 
    {
        return n - (int)n;
    }

    public static bool isEvenMethod(double n) // static 
    {
        return n%2 ==0 ? true : false; // Note
    }

    public static bool isOddMethod(double n) // static 
    {
        return !isEvenMethod(n); // Note
    }
}



class MainClass //Also: can be static
{
    static void Main()
    {
        Console.WriteLine(MyClass.Equals(1, 2)); // MyClass  inherits static method Equal() from object

        Console.WriteLine(MyClass.Equals(1, 1)); // MyClass  inherits static method Equal() from object

        Console.WriteLine("x = {0}", MyClass.x);

        Console.WriteLine("y = {0}", MyClass.y); 

        Console.WriteLine("The reciprocal of {0} is {1}", 5D, MyClass.reciprocalMethod(5D)); // Note
        
        Console.WriteLine("The Fraction Part of {0} is {1}", 5.12345D, MyClass.fractionPartMethod(5.12345D)); // Note

        Console.WriteLine("{0} is even, true or false: {1}", 5D, MyClass.isEvenMethod(5D)); // Note

        Console.WriteLine("{0} is odd, true or false: {1}", 5D, MyClass.isOddMethod(5D)); // Note
    }
}