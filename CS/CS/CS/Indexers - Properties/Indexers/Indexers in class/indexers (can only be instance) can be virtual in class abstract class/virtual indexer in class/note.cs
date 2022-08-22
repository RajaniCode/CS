// indexers (can only be instance) [can only be accessor based] can be [virtual in class/abstract class] & can be 'sealed' when overridden

// #Note: calling base class instance indexer in a derived class instance method using 'base', and then calling the instance method from Main()
// [Only assignment, call, increment, decrement, and new object expressions can be used as a statement]


using System;

class BaseClass
{
    public int[] array; // Note: public 
    
    public int l; 

    public bool error;

    public BaseClass(int size) 
    {
        array = new int[size];
        l = size;
    }
  
    public virtual int this[int index] 
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
                return 0;    //Note
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

class DerivedClass : BaseClass
{  
    public DerivedClass(int size) : base(size) // Note
    {

    }
   
    sealed public override int this[int index] // Can be 'sealed' when override
    {
        get
        {
            if((index>=0) && (index<l))
            {         
                error = false;
                return array[index] * 2; //Note: different implementation
            }
            else 
            {
                error = true;
                return 0;     
            }
     
        }
            
        set
        {   
            if((index>=0) && (index<l))
            {   
                array[index] = value;
                error = false;       
            }
            else 
                error = true;
        }
    }
}

class FurtherDerivedClass: DerivedClass
{
    public FurtherDerivedClass(int size) : base(size)
    {

    }
    
    public void methodFurtherDerivedClass()
    {   
        int x;  
       
        Console.WriteLine("Fail quietly: ");
        for(int i=0; i<(base.l*2); i++)  
            base[i] = i; 

        for(int i=0; i<(base.l*2); i++) 
        {
            x = base[i]; 
            if(x!=-1) 
                Console.Write(x + " ");
        }

        
        Console.WriteLine("\nFail with error reports: ");
        for(int i=0; i<(base.l*2); i++)
        {
            base[i] = i; 
            if(base.error)
                Console.WriteLine("base[ " + i  + " ] out-of-bounds");
        }

        for(int i=0; i<(base.l*2); i++) 
        {
            x = base[i]; 
            if(!base.error)
                Console.Write(x + " ");
            else 
                Console.WriteLine("base[ " + i + " ] out-of-bounds");
        }  
    }
}

class MainClass
{
    static void Main()
    {
        int x;

        Console.WriteLine("\n# 1");     
        BaseClass bc = new BaseClass(5); 
        
        Console.WriteLine("Fail quietly: ");
        for(int i=0; i<(bc.l*2); i++)  
            bc[i] = i; 

        for(int i=0; i<(bc.l*2); i++) 
        {
            x = bc[i]; 
            if(x!=-1) 
                Console.Write(x + " ");
        }

        
        Console.WriteLine("\nFail with error reports: ");
        for(int i=0; i<(bc.l*2); i++)
        {
            bc[i] = i; 
            if(bc.error)
                Console.WriteLine("bc[ " + i  + " ] out-of-bounds");
        }

        for(int i=0; i<(bc.l*2); i++) 
        {
            x = bc[i]; 
            if(!bc.error)
                Console.Write(x + " ");
            else 
                Console.WriteLine("bc[ " + i + " ] out-of-bounds");
        }
              
        Console.WriteLine("\n# 2");  
        BaseClass bcr;   
        DerivedClass dc = new DerivedClass(10); 
        bcr = dc;        

        Console.WriteLine("Fail quietly: ");
        for(int i=0; i<(bcr.l*2); i++)  
           bcr[i] = i; 

        for(int i=0; i<(bcr.l*2); i++) 
        {
            x = bcr[i]; 
            if(x!=-1) 
                Console.Write(x + " ");
        }

        
       Console.WriteLine("\nFail with error reports: ");
       for(int i=0; i<(bcr.l*2); i++)
       {
           bcr[i] = i; 
           if(bcr.error)
                Console.WriteLine("bcr[ " + i  + " ] out-of-bounds");
       }

       for(int i=0; i<(bcr.l*2); i++) 
       {
           x = bcr[i]; 
           if(!bcr.error)
               Console.Write(x + " ");
           else 
               Console.WriteLine("bcr[ " + i + " ] out-of-bounds");
       }  


        Console.WriteLine("\n# 3");     
        Console.WriteLine("Fail quietly: ");
        for(int i=0; i<(dc.l*2); i++)  
           dc[i] = i; 

        for(int i=0; i<(dc.l*2); i++) 
        {
            x = dc[i]; 
            if(x!=-1) 
                Console.Write(x + " ");
        }

        
       Console.WriteLine("\nFail with error reports: ");
       for(int i=0; i<(dc.l*2); i++)
       {
           dc[i] = i; 
           if(dc.error)
                Console.WriteLine("dc[ " + i  + " ] out-of-bounds");
       }

       for(int i=0; i<(dc.l*2); i++) 
       {
           x = dc[i]; 
           if(!dc.error)
               Console.Write(x + " ");
           else 
               Console.WriteLine("dc[ " + i + " ] out-of-bounds");
       }

       Console.WriteLine("\n# 4");     
        Console.WriteLine("Fail quietly: ");
        for(int i=0; i<(((BaseClass)dc).l*2); i++)  
           dc[i] = i; 

        for(int i=0; i<(((BaseClass)dc).l*2); i++) 
        {
            x = ((BaseClass)dc)[i]; 
            if(x!=-1) 
                Console.Write(x + " ");
        }

        
       Console.WriteLine("\nFail with error reports: ");
       for(int i=0; i<(((BaseClass)dc).l*2); i++)
       {
           ((BaseClass)dc)[i] = i; 
           if(((BaseClass)dc).error)
                Console.WriteLine("((BaseClass)dc)[ " + i  + " ] out-of-bounds");
       }

       for(int i=0; i<(((BaseClass)dc).l*2); i++) 
       {
           x = ((BaseClass)dc)[i]; 
           if(!((BaseClass)dc).error)
               Console.Write(x + " ");
           else 
               Console.WriteLine("((BaseClass)dc)[ " + i + " ] out-of-bounds");
       }   

        
        Console.WriteLine("\n# 5");
        FurtherDerivedClass fdc = new  FurtherDerivedClass(5); // *Note
        fdc.methodFurtherDerivedClass();          
    }
}