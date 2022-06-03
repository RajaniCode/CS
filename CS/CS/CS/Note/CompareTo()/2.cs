// built-in Int32.CompareTo(Int32) // using int parameters

// #Note


using System;

class MainClass
{
    static bool isIn(int ip, int[] iarrayp)  //#Note
    {
        foreach(int i in iarrayp)
            if(i.CompareTo(ip) == 0)        // #Note: calling built-in Int32.CompareTo(Int32)
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
    }
} 

        

    