// indexers

// using access modifiers with accessors // #Note: accessor must be more restrictive(less accessible) than the property or indexer



using System;

class MyClass
{
    int[] array;
    
    public int l; // Note: index will be limited to l

    public bool error;

    public MyClass(int size)
    {
        array = new int[size];
        l = size;
    }

    public int this[int index] 
    {
        get
        {
            if(ok(index)) 
            {
                error = false;
                return array[index]; 
            }
            else
            {
                error = true;
                return 0;
            }
        }

        private set // #Note
        {
            if(ok(index))
            {
                array[index] = value; 
                error = false;
            }
            else 
                error = true;
        }
    }

    bool ok(int index)
    {
        if((index>=0) && (index<l))
            return true;
        else
            return false;
    }
// }                    // #Note
 
// class MainClass      // #Note  
// {                    // #Note
    static void Main()
    {
        MyClass mc = new MyClass(5);

        int x;

        Console.WriteLine("Fail quietly: ");
        for(int i=0; i<(mc.l*2); i++)  
            mc[i] = i; 

        for(int i=0; i<(mc.l*2); i++) 
        {
            x = mc[i];
            if(x!=-1) 
                Console.Write(x + " ");
        }

        
       Console.WriteLine("\nFail with error reports: ");
        for(int i=0; i<(mc.l*2); i++)
        {
            mc[i] = i; 
            if(mc.error)
                Console.WriteLine("mc[ " + i  + " ] out-of-bounds");
        }

        for(int i=0; i<(mc.l*2); i++) 
        {
            x = mc[i]; 
            if(!mc.error)
                Console.Write(x + " ");
            else 
                Console.WriteLine("mc[ " + i + " ] out-of-bounds");
        }
    }
}