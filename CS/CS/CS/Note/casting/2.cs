// casting derived & base types

// abstract class


using System;

abstract class Automobile
{
}

class Car : Automobile
{
}

class MainClass
{
    static void Main()
    {
        Automobile a; // = new Car(); // Error // Automobile a = new Automobile();
        Car c = new Car();

        a = c; // Same as // Automobile a = new Car();
        c = (Car)a; // Only in case of a = c; // or // Automobile a = new Car();

        Console.WriteLine(a); // Error // Automobile a; // without // a = c; // or // Automobile a = new Car();
        Console.WriteLine(c);
    }
}