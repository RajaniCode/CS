// Non-generic built-in IComparable  interface // using generic method

// Note: IComparable does not require <> for the implementing class

// #Note


using System;

class MyClass : IComparable //#Note
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
    static bool isIn<T>(T tp, T[] tarrayp) where T : IComparable //#Note
    {
        foreach(T t in tarrayp)
            if(t.CompareTo(tp) == 0)
                return true;
        return false;
    }

    static void Main()
    {
        int[] narray = {1, 2, 3, 4, 5};
        
        if(isIn(2, narray))
            Console.WriteLine("\n2 is in narray\n");
        else
            Console.WriteLine("\n2 is not in narray\n");

        if(isIn(22, narray))
            Console.WriteLine("\n22 is in narray\n");
        else
            Console.WriteLine("\n22 is not in narray\n");


        string[] sarray = {"Bill", "Gates", "James", "Goosling", "Straustrup"};

        if(isIn("Bill", sarray))
            Console.WriteLine("\nBill is in sarray\n");
        else
            Console.WriteLine("\nBill is not in sarray\n");

        if(isIn("Bjarne", sarray))
            Console.WriteLine("\nBjarne is in sarray\n");
        else
            Console.WriteLine("\nBjarne is not in sarray\n");


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

        

    