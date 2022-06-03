// Generic interface with non-generic methods

// #Note


using System;

interface MyInterface<T>   // #Note
{                              
    T nextMethod();        // #Note
    //void resetMethod();  // #Note
    void startMethod(T t); // #Note
}

class G<T> : MyInterface<T> // #Note <T> MUST for the implementing class
{
    T value;
    T start;

    public delegate T MyDelegate(T t); // Note: delegate here is inside the class. Although not a member, has the access modifier as that of a member

    MyDelegate md;

    public G(MyDelegate mdp)
    {
        start = default(T);
        value = default(T);
        md = mdp;
    }

    public T nextMethod()
    {
        value = md(value);
        return value;
    }

    /*
    public void resetMethod()
    {
        value = start;
    }
    */

    public void startMethod(T t)
    {
        start = t;
        value = start;
    }
}

class XYZClass
{
    public int x;
    public int y;
    public int z;
 
    public XYZClass(int a, int b, int c)
    {
        x = a;
        y = b;
        z = c;
    }
}

class MainClass
{
    static int intPlusTwo(int valuep)
    {
        return valuep + 2;
    }
   
    static double doublePlusTwo(double valuep)
    {
        return valuep + 2.0;
    }    

    static XYZClass XYZClassPlusTwo(XYZClass valuep)
    {
        if(valuep == null)
            return new XYZClass(0, 0, 0);
        else
            return new XYZClass(valuep.x + 2, valuep.y + 2, valuep.z + 2);
    }

    static void Main()
    {
        G<int> Gi = new G<int>(intPlusTwo);
       
        for(int i=0; i<5; i++)
             Console.Write(Gi.nextMethod() + " ");

        Console.WriteLine("\n");

        G<double> Gd = new G<double>(doublePlusTwo);

        Gd.startMethod(11.4);   // #Note
       
        for(int i=0; i<5; i++)
             Console.Write(Gd.nextMethod() + " ");
         
        Console.WriteLine("\n");
   
        G<XYZClass> GXYZC = new G<XYZClass>(XYZClassPlusTwo);

        XYZClass xyzc;  // #Note

        for(int i=0; i<5; i++)
        {
            xyzc = GXYZC.nextMethod(); // #Note
            Console.Write(xyzc.x + "," + xyzc.y + "," + xyzc.z + " ");
        }
    }
}
     
 
    