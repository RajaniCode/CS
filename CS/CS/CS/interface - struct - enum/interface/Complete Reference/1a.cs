using System;  // Note

class MyClass : InterfaceExample 
{
    int initial;
    int result;
    
    public MyClass() 
    {
        initial = 0;
        result = 0;
    }

    public int nextMethod() 
    {
        result += 2;
        return result;
    }

    public void resetMethod() 
    {
        result = initial;
    }
  
    public void fromMethod(int f) 
    { 
        initial = f; // Note       
        result = initial;
    }
}


//>csc 1.cs 1a.cs 1b.cs

//>1

// (1.cs containing entry point[static void Main()])



        
        




















    
