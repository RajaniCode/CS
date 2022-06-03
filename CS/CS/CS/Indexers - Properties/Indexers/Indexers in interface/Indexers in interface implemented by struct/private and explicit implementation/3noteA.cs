// mulidimensional indexers in interface, private and explicit implementation by struct 

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

    int this[int index1, int index2]
    {
        get;
        set;
    }
}

struct MyStruct : MyInterface
{
    public int[ , ] array;  

    int row; 
    
    int column; 

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

    public MyStruct(int r, int c) : this()
    {
        row = r;
        column = c;
        array = new int[row, column]; 
        l = row * column; // Also: l = r * c; 
    }

    int MyInterface.this[int index1, int index2] 
    {
        get
        {
            if(ok(index1, index2)) 
            {
                error = false;
                return array[index1, index2]; 
            }
            else
            {
                error = true;
                return 0;
            }
        }

        set
        {
            if(ok(index1, index2))
            {
                array[index1, index2] = value;
                error = false;
            }
            else
                error = true;               
        }
    }

    bool ok(int index1, int index2)
    {
        if((index1>=0 && index1<row) && (index1>=0 && index1<column)) 
            return true;
        else
            return false;
    }
}

struct MainStruct
{
    static void Main()
    {
        MyStruct ms = new MyStruct(3, 5); 
   
        int x;
 
        MyInterface mi = (MyInterface)ms;

        Console.WriteLine("Fail quietly: ");
        for(int i=0; i<(mi.len); i++) // #Note
            mi[i,i] = i; 

        for(int i=0; i<(mi.len); i++) // #Note
        {
            x = mi[i,i]; 
            if(x!=-1)
                Console.Write(x + " ");
        }

        Console.WriteLine("\nFail with error records: ");
        for(int i=0; i<(mi.len); i++) // #Note
        {
            mi[i,i] = i;
            if(mi.er) // #Note
                Console.WriteLine("mi[ " + i + ", " + i + "] out-of-bounds"); 
        }

        for(int i=0; i<(mi.len); i++)  // #Note
        {
            x = mi[i,i]; 
            if(!mi.er) // #Note
                Console.Write(x + " ");
            else
                Console.WriteLine("mi[ " + i + ", " + i + "] out-of-bounds"); 
        }
    }
}