//C# 2.0 Nullable<T> // Only vlaue types // can be static // can be readonly // cannot be volatile // cannot be const 


// ?? operator // null coalescing operator


using System;

class MainClass
{
    static int getZero()
    {
        return 0;
    }
 
    static void Main()
    {
        System.Nullable<int> i1 = null; // LOCAL
        int i2;                         // LOCAL

        // i2 = (int)i1; // ONLY EXPLICIT exists from <int> to int BUT ONLY WHEN <int> is not null
    
        // i2 = i1; ?? getZero();
      
        // Console.WriteLine("i2 has value: " + i2);
        
        i1 = 100; 

        i2 = i1 ?? getZero();
    
        Console.WriteLine("i2 has value: " + i2);                   
    }
}