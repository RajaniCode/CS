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
    int[] array;
    
    public int l; // Note: index will be limited to l

    public bool error;

    public MyClass(int size)
    {
        array = new int[size];
        l = size;
    }

    int MyInterface.this[int index] 
    {
        get
        {
            if(ok(index)) // if ok method passed with index is true/false
            {
                error = false;
                return array[index]; // return value specified by index // array, elememt being processed
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
                array[index] = value; // set value specified by index
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

        MyInterface mi = (MyInterface)mc; // Note

        Console.WriteLine("Fail quietly: ");
        for(int i=0; i<(mc.l*2); i++)  // *Note
            mi[i] = i; // Note

        for(int i=0; i<(mc.l*2); i++) // *Note
        {
            x = mi[i]; // Note
            if(x!=-1) 
                Console.Write(x + " ");
        }

        
       Console.WriteLine("\nFail with error reports: ");
        for(int i=0; i<(mc.l*2); i++) // *Note
        {
            mi[i] = i; // Note
            if(mc.error) // *Note
                Console.WriteLine("mi[ " + i  + " ] out-of-bounds"); // Note
        }

        for(int i=0; i<(mc.l*2); i++) // *Note
        {
            x = mi[i]; // Note
            if(!mc.error) // *Note
                Console.Write(x + " ");
            else 
                Console.WriteLine("mi[ " + i + " ] out-of-bounds"); // Note
        }
    }
}