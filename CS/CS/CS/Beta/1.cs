// Inheritance


using System;

class Automobile
{

}

class Car : Automobile
{
    static void Main()
    {
        Automobile auto = new Automobile();

        Car mercedes = new Car();
        Car bmw = new Car();

        auto = mercedes;

        bmw = (Car)auto;      
    }
}
 
  
 