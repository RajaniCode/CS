// indexers in interface, private and explicit implementation by struct // note: this()

// *Note: Doesn't work


using System;

interface MyInterface 
{
    int this[int index] 
    {
        get; 
        set; 
    }
}

struct MyStruct : MyInterface 
{
    int[] array;
    
    public int l; 

    public bool error;

    public MyStruct(int size) : this()
    {
        array = new int[size];
        l = size;                
    }

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

struct MainStruct
{
    static void Main()
    {
        MyStruct ms = new  MyStruct(5); 

        int x;

        MyInterface mi = (MyInterface)ms; 

        Console.WriteLine("Fail quietly: ");
        for(int i=0; i<(ms.l*2); i++)  
            mi[i] = i; 

        for(int i=0; i<(ms.l*2); i++) 
        {
            x = mi[i]; 
            if(x!=-1) 
                Console.Write(x + " ");
        }

        
       Console.WriteLine("\nFail with error reports: ");
        for(int i=0; i<(ms.l*2); i++) 
        {
            mi[i] = i; 
            if(ms.error) // *Note: Doesn't work
                Console.WriteLine("mi[ " + i  + " ] out-of-bounds"); // Note
        }

        for(int i=0; i<(ms.l*2); i++) // *Note
        {
            x = mi[i]; 
            if(!ms.error) // *Note: Doesn't work
                Console.Write(x + " ");
            else 
                Console.WriteLine("mi[ " + i + " ] out-of-bounds"); // Note
        }
    }
}