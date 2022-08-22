// Generic method // static method


using System;

class MyClass
{
    public static bool copyArray<T>(T element, int index, T[] sourcep, T[] targetp)
    {
        if(targetp.Length < sourcep.Length + 1)
            return false;

        for(int i=0, j=0; i<sourcep.Length; i++, j++)
        {
            if(i == index)
            {
                targetp[j] = element;
                j++;
            }
            targetp[j] = sourcep[i];
        }
        return true;
    }   
}

class MainClass
{
    static void Main()
    {
        int[] source1 = {1, 2, 3};
 
        int[] target1 = new int[4];
  
        MyClass.copyArray(4, 2, source1, target1);

        foreach(int i in target1)
            Console.Write(i + " ");

        Console.WriteLine();

        string[] source2 = {"Bill", "Gates", "Bjarne", "Straustrup"};
 
        string[] target2 = new string[5];
  
        MyClass.copyArray("and", 2, source2, target2);

        foreach(string s in target2)
            Console.Write(s + " ");
    }
}      
    
           