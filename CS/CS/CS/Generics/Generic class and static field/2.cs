/*
If a generic class contains a static field, then each constructed type has its own copy of that field. 
This means that each instance of the same constructed type shares the same static field. 
However, a different constructed type shares a different copy of that field. 
Thus a static field is not shared by all constructed types."
*/

//  Check with non-generic 


using System;

class G 
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
        G Gs1 = new G();
        G Gs2 = new G();
    
        G Gi1 = new G();
        G Gi2 = new G();
        G Gi3 = new G();

        Console.WriteLine(G.NumberOfInstances);

        Console.WriteLine(G.NumberOfInstances);
    }
}