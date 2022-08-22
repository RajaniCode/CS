// Generic method


using System;

class ClassArray
{
    internal static bool CopyInsert<T>(T e, int idx, T[] source, T[] target)
    {
        if(target.Length < source.Length+1)
        {
            return false;
        }

        for(int i=0, j=0; i<source.Length; i++, j++)
        {
            if(i==idx)
            {
                target[j] = e;
                j++;                
            }
            target[j] = source[i]; 
        }
        return true; 
    }
}

class MainClass
{
    static void Main()
    {
        int[] intArrayS = new int[] {100,200,300};
        int[] intArrayT  = new int[4];

        ClassArray.CopyInsert(99, 2, intArrayS, intArrayT);

        Console.Write("int array: ");
        foreach(int i in intArrayT)
            Console.Write(i + " "); 

        Console.WriteLine();  

        string[] stringArrayS = new string[] {"100%","200%","300%"};
        string[] stringArrayT  = new string[4];

        ClassArray.CopyInsert("99%", 2, stringArrayS, stringArrayT);

        Console.Write("string array: ");
        foreach(string i in stringArrayT)
            Console.Write(i + " "); 

        Console.WriteLine();

        object[] objectArrayS = new object[] {"100%",200,true};
        object[] objectArrayT  = new object[4];

        
        ClassArray.CopyInsert(DateTime.Now, 2, objectArrayS, objectArrayT);

        Console.Write("object array: ");
        foreach(object i in objectArrayT)
            Console.Write(i + " "); 

        Console.WriteLine(); 
    }
}