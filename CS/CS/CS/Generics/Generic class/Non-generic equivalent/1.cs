// Non-generic equivalent for generic class


using System;

class MyClass
{
    object ob;

    public MyClass(object obp)
    {
        ob = obp;
    }

    public void methodobject() 
    {
        Console.WriteLine("\nType is: {0} \n", ob.GetType()); // Note
    }

    public object methodob() 
    {
        return ob;
    }
}

class MainClass
{
    static void Main()
    {
        MyClass mc1 = new MyClass(100); // Note
       
        mc1.methodobject();

        Console.WriteLine("\nObject Value is: {0}\n", mc1.methodob());


        MyClass mc2 = new MyClass("Bill"); // Note
       
        mc2.methodobject();

        Console.WriteLine("\nObject Value is: {0}\n", mc2.methodob());  
    }
}
        
        
   