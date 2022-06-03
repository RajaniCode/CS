// casting derived & base types


using System;

class Automobile
{
}

class Car : Automobile
{
}

class MainClass
{
    static void Main()
    {
        Automobile a = new Automobile();
        Car c = new Car();

        a = c; // Same as // Automobile a = new Car();
        c = (Car)a; // Only in case of a = c;

        Console.WriteLine(a);
        Console.WriteLine(c);
    }
}

    