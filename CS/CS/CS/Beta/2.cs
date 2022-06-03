// Inheritance // abstract class


using System;

abstract class Automobile
{

}

class Car : Automobile
{
    static void Main()
    {
        Automobile auto;

        Car mercedes = new Car();
        Car bmw = new Car();

        auto = mercedes;

        bmw = (Car)auto;      
    }
}
 
  
 