// abstract class

// abstractMethod() implemented (overridden) in all derived classes at 1st level derivation (even if the derived class is abstract)

// abstract class can inherit from abstract or non-abstract class (including multilevel & excluding multiple)

// non-abstract class can be inherited from an abstract class (including multilevel & excluding multiple)

// abstract class can do without abstract members (method) 


using System;

class x // abstract or non-abstract class
{

}

abstract class BaseClass : x
{
    static int s = 1;
    int i = 2;

    public string instanceMethod()  
    {       
        return "instanceMethod() in BaseClass: " + (s + i).ToString();
    }

    public static string staticMethod(BaseClass bcp) 
    {
        return "staticMethod() in BaseClass: " + (s + bcp.i).ToString(); 
    }    

    public abstract string abstractMethod(); 
}

abstract class DerivedClass : BaseClass // abstract class can do without abstract members (method) 
{
    sealed public override string abstractMethod() // abstractMethod() implemented (overridden) in abstract class
    {
        return "abstractMethod() must be implemented (overridden) [can be sealed] in all derived classes at 1st level derivation (even if the derived class is abstract) (DerivedClass)\n";
    }
}
   
class MoreDerivedClass : DerivedClass // abstract or non-abstract class
{
    /*
    public new virtual string abstractMethod()
    {   
        Console.WriteLine(base.abstractMethod());
        return "abstractMethod() is 'new' and vitual, and cannot override (MoreDerivedClass)\n";
    }
    */
}

class MainClass
{
    static void Main()
    {
        Console.WriteLine("abstractMethod() implemented (overridden) in derived abstract class\n");

        Console.WriteLine("abstract class can derive from abstract or non-abstract class\n");

        Console.WriteLine("abstract or non-abstract class can be derived from an abstract class\n");

        Console.WriteLine("do without abstract method in abstract class\n");  

        // MoreDerivedClass mdc = new MoreDerivedClass();

        // Console.WriteLine(mdc.abstractMethod()); 
    }
}