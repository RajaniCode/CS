// Covariance and Contravariance

using System;

class A { }

class B : A { }

class X { }

class Y : X { }

delegate A Covariance();

delegate void Contravariance(Y y);

class Example
{
    public B MethodB() // Covariance
    {
        Console.WriteLine("Covariance: Method's Return Type is Derived from Delegate's Return Type: " + typeof(B));
        return new B();
    }
   
    public void MethodX(X x) // Contravariance
    {      
        Console.WriteLine("Contravariance: Method's Signature (Parameter Type) is Base of Delegate's Signature (Parameter Type): " + x.GetType().Name);
        // Note: However only Derived Type can be passed to delegate instance as parameter
    }
}

class Program
{
    static void Main()
    {
        Example ex = new Example();
        
        Covariance co = ex.MethodB;
        co();
        
        Contravariance contra = ex.MethodX;
        Y y = new Y();
        contra(y); // Note: However only Derived Type can be passed to delegate instance as parameter
    }
}
        