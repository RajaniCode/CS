// abstract class


using System;

abstract class MainClass
{
    string instanceMethod()  
    {       
        return "instanceMethod() in abstract MainClass";
    }

    static string staticMethod() 
    {
        return "staticMethod() in abstract MainClass"; 
    }

    static void Main()
    {
        MainClass mcr = new DerivedClass();

        Console.WriteLine(mcr.instanceMethod()); // ?
                                                       
        Console.WriteLine(staticMethod());                                                                                         
    }
}

class DerivedClass : MainClass
{

}