// indexers in interface, private and explicit implementation by struct // note: this()

// #Note


using System;

interface MyInterface // #Note
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
    int[] array;
     
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
        for(int i=0; i<(mi.len*2); i++) // #Note
            mi[i] = i; 

        for(int i=0; i<(mi.len*2); i++) // #Note
        {
            x = mi[i]; 
            if(x!=-1) 
                Console.Write(x + " ");
        }

        
       Console.WriteLine("\nFail with error reports: ");
        for(int i=0; i<(mi.len*2); i++) // #Note
        {
            mi[i] = i; 
            if(mi.er) // #Note
                Console.WriteLine("mi[ " + i  + " ] out-of-bounds"); // Note
        }

        for(int i=0; i<(mi.len*2); i++) // *Note
        {
            x = mi[i]; 
            if(!mi.er) // #Note
                Console.Write(x + " ");
            else 
                Console.WriteLine("mi[ " + i + " ] out-of-bounds"); // Note
        }
    }
}