// instance indexer and instance properties in interface, public implementation by class

// using l and error as properties


using System;

interface MyInterface
{
    int l 
    {
        get; // Note: read-only 
    } 

    bool er
    {
        get; // Note: read-only
    } 

    int this[int index]   
    {
        get;
        set;
    }   
}

class MyClass : MyInterface
{
    int[] array;
    
    int len; // Note

    public int l // Note: read-only 
    {
        get
        {
            return len;
        }       
    }
   
    bool error; // Note
    
    public bool er // Note: read-only
    {   
        get
        {
            return error;
        }    
    }
     
    public MyClass(int size)
    {
        array = new int[size];
        len = size; // Note: Because l is read-only
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
            if(mc.er) // Note: error is private
                Console.WriteLine("mc[ " + i  + " ] out-of-bounds");
        }

        for(int i=0; i<(mc.l*2); i++) 
        {
            x = mc[i]; 
            if(!mc.er) // Note: error is private
                Console.Write(x + " ");
            else 
                Console.WriteLine("mc[ " + i + " ] out-of-bounds");
        }
    }
}