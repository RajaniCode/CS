// user-defined CompareTo() for MyClass // using class parameters

// #Note


using System;

class MyClass 
{
    int value;
    
    public MyClass(int x)
    {
        value = x;
    } 

    public int CompareTo(object ob)         //#Note
    {
        return value - ((MyClass)ob).value; //#Note
    }
}

class MainClass
{
    static bool isIn(MyClass mcp, MyClass[] mcarrayp)  //#Note: calling user-defined CompareTo()
    {
        foreach(MyClass mc in mcarrayp)
            if(mc.CompareTo(mcp) == 0)
                return true;

        return false;
    }

    static void Main()
    {
        MyClass[] mcarray = {new MyClass(1), new MyClass(2), new MyClass(3), new MyClass(4), new MyClass(5)};

        MyClass mc1 = new MyClass(2);

        if(isIn(mc1, mcarray))
            Console.WriteLine("\n2 is in mcarray\n");
        else
            Console.WriteLine("\n2 is not in mcarray\n");

        MyClass mc2 = new MyClass(22);

        if(isIn(mc2, mcarray))
            Console.WriteLine("\n22 is in mcarray\n");
        else
            Console.WriteLine("\n22 is not in mcarray\n");
  
        if(isIn(new MyClass(2), mcarray))
            Console.WriteLine("\n2 is in mcarray\n");
        else
            Console.WriteLine("\n2 is not in mcarray\n");   
            
        if(isIn(new MyClass(22), mcarray))
            Console.WriteLine("\n22 is in mcarray\n");
        else
            Console.WriteLine("\n22 is not in mcarray\n");
    }
} 

        

    