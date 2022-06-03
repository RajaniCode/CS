// Generic method // static method // using explicit type arguments


using System;

class A
{

}

class B : A
{

}

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

        MyClass.copyArray<int>(4, 2, source1, target1); // <int> is the explicit type argument // <int> NOT A MUST

        foreach(int i in target1)
            Console.Write(i + " ");

        Console.WriteLine();

        string[] source2 = {"Bill", "Gates", "Bjarne", "Straustrup"};
 
        string[] target2 = new string[5];
  
        MyClass.copyArray<string>("and", 2, source2, target2); // <string> is the explicit type argument // <string> NOT A MUST

        foreach(string s in target2)
            Console.Write(s + " ");

        Console.WriteLine();

        B[] b = {new B(), new B(), new B()};
        A[] a = new A[4];

        MyClass.copyArray<A>(new A(), 2, b, a); // <A> is the explicit type argument // MUST

        foreach(A a1 in a)
            Console.Write(a1 + " ");
        
    }
}      
    
           