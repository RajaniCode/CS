// Covariance and Contravariance

using System;

class A { }

class B : A { }

// class C : A { } // Works
class C : B { } // Works

class X { }

class Y : X { }

// class Z : X { }  // Works
class Z : Y { }  // Works

delegate A Covariance();

delegate void Contravariance(Z z);

class Example
{
    public C MethodC() // Covariance
    {
        Console.WriteLine("Covariance: Method's Return Type is Derived from Delegate's Return Type: " + typeof(C));
        return new C();
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
        
        Covariance co = ex.MethodC;
        co();
        
        Contravariance contra = ex.MethodX;
        Z z = new Z();
        contra(z); // Note: However only Derived Type can be passed to delegate instance as parameter
    }
}
        