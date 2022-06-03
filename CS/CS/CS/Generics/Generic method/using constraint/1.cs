// Generic method // static method // using constraint


using System;

class A
{

}

class B : A
{

}

class MyClass
{
    public static bool copyArray<T>(T element, int index, T[] sourcep, T[] targetp) where T : class // ONLY reference type
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
        B[] b = {new B(), new B(), new B()};
        A[] a = new A[4];

        MyClass.copyArray<A>(new A(), 2, b, a); // ONLY reference type // <A> MUST

        foreach(A a1 in a)
            Console.Write(a1 + " ");

        string[] s1 = {"Bill", "Gates", "Bjarne", "Straustrup"};
        string[] s2 = new string[5];

        Console.WriteLine();

        MyClass.copyArray<string>("and", 2, s1, s2); // <string> NOT A MUST

        foreach(string s in s2)
            Console.Write(s + " ");        
    }
}      
    
           