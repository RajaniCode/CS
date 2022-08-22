// indexers in interface, private and explicit implementation by struct // Note: : this()

// #Note


using System;

interface MyInterface
{
    int len
    {
        get;
    }

    bool er // #Note
    {
        get;
    }

    int this[int index]
    {
        get;
        set;
    }
}

struct MyStruct : MyInterface
{
    public int[] array; //Note: public for ms.array.Length
    
    public int l;

    public bool error;

    int MyInterface.len // #Note
    {
        get
        {
            return l;
        }
    }  

    bool MyInterface.er // #Note
    {
        get
        {
            return error;
        }
    }  

    public MyStruct(int size) : this() // Note
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
        MyStruct ms = new MyStruct(5); 

        int x;

        MyInterface mi = (MyInterface)ms;

        Console.WriteLine("Fail quietly: ");
        for(int i=0; i<(ms.array.Length*2); i++)  // Note: instead of ms.l, ms.array.Length 
            mi[i] = i; 
        for(int i=0; i<(ms.array.Length*2); i++) 
        {
            x = mi[i]; 
            if(x!=-1) 
                Console.Write(x + " ");
        }

        
       Console.WriteLine("\nFail with error reports: ");
        for(int i=0; i<(ms.array.Length*2); i++)
        {
            mi[i] = i; 
            if(mi.er) // #Note
                Console.WriteLine("mi[ " + i  + " ] out-of-bounds");
        }

        for(int i=0; i<(ms.array.Length*2); i++) 
        {
            x = mi[i]; 
            if(!mi.er) // #Note
                Console.Write(x + " ");
            else 
                Console.WriteLine("mi[ " + i + " ] out-of-bounds"); 
        }
    }
}