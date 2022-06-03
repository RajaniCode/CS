//C# 2.0 Nullable<T> // Only vlaue types // can be static // can be readonly // cannot be volatile // cannot be const 


using System;

class MainClass
{     
    static void Main()
    {
        int x;
        System.Nullable<int> i1 = null; // LOCAL
        int? i2 = null;                 // LOCAL

        // Console.WriteLine("x has value: " + x); // NOT POSSIBLE NOW

        x = 100;

        Console.WriteLine("x has value: " + x); // NOW POSSIBLE 

        i1 = i2 + x;
    
        if(i1 != null)
            Console.WriteLine("i1 has value: " + i1.Value);
        else
            Console.WriteLine("i1 doesn't have value");  

        i2 = 50; 

        i1 = i2 + x;
    
        if(i1 != null)
            Console.WriteLine("i1 has value: " + i1.Value);
        else
            Console.WriteLine("i1 doesn't have value");  
              
    }
}