// indexers in interface, private and explicit implementation by class
 

using System;

interface MyInterface 
{
    int this[int index] // Note
    {
        get; // Note
        set; // Note
    }
}

class MyClass : MyInterface 
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
    int MyInterface.this[int index] 
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

        MyInterface mi = (MyInterface)mc;

        Console.WriteLine("Fail quietly: ");
        for(int i=0; i<(mc.array.Length*2); i++)  // Note: instead of mc.l, mc.array.Length 
            mi[i] = i; // Note

        for(int i=0; i<(mc.array.Length*2); i++) 
        {
            x = mi[i]; // Note
            if(x!=-1) 
                Console.Write(x + " ");
        }

        
       Console.WriteLine("\nFail with error reports: ");
        for(int i=0; i<(mc.array.Length*2); i++)
        {
            mi[i] = i; // Note
            if(mc.error)
                Console.WriteLine("mi[ " + i  + " ] out-of-bounds"); // Note
        }

        for(int i=0; i<(mc.array.Length*2); i++) 
        {
            x = mi[i]; // Note
            if(!mc.error)
                Console.Write(x + " ");
            else 
                Console.WriteLine("mi[ " + i + " ] out-of-bounds"); // Note
        }
    }
}