// object class // ToString()

using System;
 
class Myclass
{
    static int count = 1;
    int id;
 
    public Myclass()
    {
        id = count++; // Note post increment
    }
   
    public override string ToString() // Note: built-in method in Object class
    {
        return "MyClass object #" + id;
    }
}

class MainClass
{
    static void Main()
    {
        Myclass ob1 = new Myclass(); 
        Myclass ob2 = new Myclass();
        Myclass ob3 = new Myclass(); 
   
        Console.WriteLine(ob1); // Note: No need for method name
        Console.WriteLine(ob2); // Note: No need for method name
        Console.WriteLine(ob3); // Note: No need for method name
    }
}