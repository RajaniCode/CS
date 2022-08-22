// indexers

using System;

class MyClass
{
    public int[] array; //Note: public for mc.array.Length
    
    public int l;

    public bool error;

    public MyClass(int size)
    {
        array = new int[size];
        l = size;
    }

    // public, being member of class // int, type of element being processed // this, keyword // int, type of array indexing // index, index of element being processed and not keyword 
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

        set
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
}

class MainClass
{
    static void Main()
    {
        MyClass mc = new MyClass(5); 

        int x;

        Console.WriteLine("Fail quietly: ");
        for(int i=0; i<(mc.array.Length*2); i++)  // Note: instead of mc.l, mc.array.Length 
            mc[i] = i; 

        for(int i=0; i<(mc.l*2); i++) 
        {
            x = mc[i]; 
            if(x!=-1) 
                Console.Write(x + " ");
        }

        
       Console.WriteLine("\nFail with error reports: ");
        for(int i=0; i<(mc.array.Length*2); i++)
        {
            mc[i] = i; 
            if(mc.error)
                Console.WriteLine("mc[ " + i  + " ] out-of-bounds");
        }

        for(int i=0; i<(mc.array.Length*2); i++) 
        {
            x = mc[i]; 
            if(!mc.error)
                Console.Write(x + " ");
            else 
                Console.WriteLine("mc[ " + i + " ] out-of-bounds");
        }
    }
}