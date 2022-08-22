// Non-generic equivalent for generic class


using System;

class MyClass
{
    object ob1;
    object ob2;

    public MyClass(object obp1, object obp2)
    {
        ob1 = obp1;
        ob2 = obp2;
    }

    public void methodobject() 
    {
        Console.WriteLine("\nType is: {0}\n", ob1.GetType()); 
        Console.WriteLine("\nType is: {0}\n", ob2.GetType());
    }

    public object methodob1() 
    {
        return ob1;
    }

    public object methodob2() 
    {
        return ob2;
    }
}

class MainClass
{
    static void Main()
    {
        MyClass mc1 = new MyClass(100, "Bill"); 
       
        mc1.methodobject();

        Console.WriteLine("\nObject Value is: {0}\n", mc1.methodob1());

        Console.WriteLine("\nObject Value is: {0}\n", mc1.methodob2());        
    }
}
        
        
   