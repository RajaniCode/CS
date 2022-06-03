// Covariance and Contravariance

using System;

class X
{
    public int n;
}

class Y : X { }

delegate X D(Y y);

class MainClass
{
    // Covariance: Method's Return Type is Derived from Delegate's Return Type
    static Y YMethod(Y yp) 
    {
        Y y = new Y();
        y.n = yp.n + 1;        
        return y;
    }

    // Contravariance: Method's Signature (Parameter Type) is Base of Delegate's Signature (Parameter Type) 
    // Note: However only Derived Type can be passed to delegate instance as parameter
    static X XMethod(X xp) 
    {
        X x = new X();
        x.n = xp.n + 1;        
        return x;
    }    

    static void Main()
    {
        Y y = new Y();
        
        D d = XMethod;
        X x = d(y);
      
        Console.WriteLine("x.n = {0}\n", x.n);

        d = YMethod;
        y = (Y)d(y); // Note: The return type of D is X.  You must explicitly tell the compiler you expect the X to in fact be a Y 
        
        Console.WriteLine("y.n = {0}\n", y.n);              
    }
}
        