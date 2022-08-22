/*
If a generic class contains a static field, then each constructed type has its own copy of that field. 
This means that each instance of the same constructed type shares the same static field. 
However, a different constructed type shares a different copy of that field. 
Thus a static field is not shared by all constructed types."
*/


using System;

class G<T> 
{  
    static int _numInstances = 0;

    public G()
    {
        _numInstances++;

    }

    public static int NumberOfInstances 
    {
        get 
        {
            return _numInstances;
        }
    }
}

class MainClass
{
    static void Main()
    {
        G<string> Gs1 = new G<string>();
        G<string> Gs2 = new G<string>();
    
        G<int> Gi1 = new G<int>();
        G<int> Gi2 = new G<int>();
        G<int> Gi3 = new G<int>();

        Console.WriteLine(G<string>.NumberOfInstances);

        Console.WriteLine(G<int>.NumberOfInstances);
    }
}