// CS 2
/*
1. Generics
2. Nullable types
3. Iterators
4. yield Statement
5. Partial Classes/Structs/Interfaces
6. Anonymous methods
7. The :: operator (Namespace Alias Qualifier)
8. Static Classes
9. Covariance and contravariance
10. Fixed-size buffers
Note: fixed keyword [only with built-in struct except decimal, only in unsafe, cannot be static]
11. Friend assemblies
12. Extern Aliases [extern keyword has been available since C# 1.0]
13. Delegate Method Group Conversion
14. Access Modifiers with Accessors [Note: For properties and indexers]
15. #pragma directives
16. ?? Operator or Null-Coalesce Operator
17. System.Predicate
18. System.Action
*/

/*
// 12. extern aliases 
// An extern alias declaration must precede all other elements defined in the namespace
// Aliases on the command line: csc /reference:ExternAssembly1=ExternalAssemblyA.dll;ExternAssembly2=ExternalAssemblyB.dll Program.cs
extern alias ExternAssembly1;
extern alias ExternAssembly2;
*/

using System;
using System.Collections;
using System.Collections.Generic;
using N1;
using N2;

// Give N1 an alias called N.
// 7. The :: operator (Namespace Alias Qualifier)
using N = N1;

// 11. Friend assemblies 
// using SignedFriend; // Commented to reference unsigned assemblies // As both current assembly and friend assembly must be signed with strong name

class G
{
    object obj;

    public G(object obj)
    {
        this.obj = obj;
    }

    public object GetObject()
    {
        return obj;
    }

    public void ShowType()
    {
        Console.WriteLine("Type: " + obj.GetType());
    }
}

// 1. Generics
class G<T>
{
    T obj;

    public G(T obj)
    {
        this.obj = obj;
    }

    public T GetObject()
    {
        return obj;
    }

    public void ShowType()
    {
        Console.WriteLine("Type: " + typeof(T));
    }
}

class GClient
{
    public void Print()
    {
        G g = new G("Hello World!");
        string s = (string)g.GetObject();
        Console.WriteLine("Object: " + s);
        g.ShowType();

        g = new G(100);
        int i = (int)g.GetObject();
        Console.WriteLine("Object: " + i);
        g.ShowType();

        G<string> gs = new G<string>("Hello World!");
        s = gs.GetObject();
        Console.WriteLine("Object: " + s);
        gs.ShowType();

        G<int> gi = new G<int>(100);
        i = gi.GetObject();
        Console.WriteLine("Object: " + i);
        gi.ShowType();
    }
}

struct StuctureType { }

// 15. New #pragma directives
/*
The first is warning, which is used to enable or disable specific compiler warnings:
#pragma warning disable [warnings]
#pragma warning restore [warnings]
The second #pragma option is checksum. It is used to generate checksums for ASP.NET projects. 
It has this general form:
#pragma checksum “fi lename” “{GUID}” “check-sum”
Here, filename is the name of the file, GUID is the globally unique identifier associated with
filename, and check-sum is a hexadecimal number that contains the checksum. This string
must contain an even number of digits.
*/
#pragma warning disable 0168, 0169, 0219, 0414, 3021 // 3021 for CLSCompliant
[CLSCompliant(false)]
class NullableTypes
{
    // 2. Nullable Types 
    // System.Nullable<[ValueType]> or Nullable<[ValueType]> or [ValueType]? 
    // Can be member or local variable
    // Defaulted to null as member variable
    // Can be static
    // warning 0169
    System.Nullable<StuctureType> nullableStucture; // Can be struct
    sbyte? nullableSByte;
    byte? nullableByte;
    char? mullableChar;
    short? nullableShort;
    ushort? nullableUShort;
    System.Nullable<int> nullableInteger;
    uint? nullableUInt;
    long? nullableLong;
    ulong? nullableULong;
    float? nullableFloat;
    double? nullableDouble;
    decimal? nullableDecimal;
    bool? nullableBool;

    public void Print()
    {
        // 2. Nullable Types
        // warning	0168
        StuctureType? nullableStuct;
        sbyte? nullableSByteLocal;
        byte? nullableByteLocal;
        char? nullableCharLocal;
        short? nullableShortLocal;
        ushort? nullableUShortLocal;
        System.Nullable<int> nullableInt = null;
        uint? nullableUIntLocal;
        long? nullableLongLocal;
        ulong? nullableULongLocal;
        float? nullableFloatLocal;
        double? nullableDoubleLocal;
        decimal? nullableDecimalLocal;
        bool? nullableBoolLocal;

        if (nullableInt == null) // Since nullableInt is assigned although with null
        {
            Console.WriteLine("nullableInt is null.");
        }

        nullableInt = nullableInteger;

        if (nullableInt == null)
        {
            Console.WriteLine("nullableInt is still null.");
        }

        // 16. ?? or Null-Coalesce operator        
        Console.WriteLine("nullableInt is defaulted to {0}", nullableInt ?? 1);
        nullableInteger = nullableInt ?? default(int);

        Random randomNumber = new Random();
        int number = randomNumber.Next(0, 100);
        // Pre-C# 2.0 conditional operator (?:)
        Console.WriteLine("{0}  is an {1}", number, (number % 2 == 0) ? "Even Number" : "Odd Number");

        if (nullableInteger != null)
        {
            Console.WriteLine("nullableInteger is not null.");
            if (nullableInteger.HasValue)
            {
                Console.WriteLine("nullableInteger has value: {0}", nullableInteger.Value);
            }
        }

        if (nullableStucture == null)
        {
            Console.WriteLine("nullableStucture is null");
        }

        nullableStucture = new StuctureType();

        if (nullableStucture != null)
        {
            Console.WriteLine("nullableStucture is not null");
        }

        if (nullableStucture.HasValue)
        {
            Console.WriteLine("nullableStucture has value: {0}", nullableStucture.Value);
        }
    }
}

// 3. Iterators
class Digits
{ 
    public IEnumerable<int> GetDigit()
    {
        // 4. yield Statement
        yield return 0;
        yield return 1;
        yield return 2;
        yield return 3;
        yield return 4;
        yield return 5;
        yield return 6;
        yield return 7;
        yield return 8;
        yield return 9;
    }
}

class Greek : IEnumerable
{
    private string[] alphabet = { "alpha", "beta", "gamma", "delta", "epsilon", "zeta", "eta", "theta", "iota", "kappa", "lambda", "mu", "nu", "xi", "omicron", "pi", "rho", "sigma", "tau", "upsilon", "phi", "chi", "psi", "omega" };

    public IEnumerator GetEnumerator()
    {
        for (int index = 0; index < alphabet.Length; index++)
        {
            // 4. yield Statement
            yield return alphabet[index];
        }
    }
}

class Characters<T> 
{
    T[] array;

    public Characters(T[] a) 
    {
        array = a;
    }

    public IEnumerator<T> GetEnumerator() 
    {
        foreach(T obj in array)
        {
            // 4. yield Statement           
            yield return obj;
        }
    }
}

class IteratorClient
{
    public void Print()
    {
        Console.WriteLine("Iterators");
        Digits digit = new Digits();
        foreach (int i in digit.GetDigit())
        {
            Console.WriteLine(i);
        }

        Greek gre = new Greek();
        IEnumerator enumerator = gre.GetEnumerator();
        while(enumerator.MoveNext())
        {
            Console.WriteLine(enumerator.Current);
        }

        int[] evenDigits = { 0, 2, 4, 6, 8 };
        Characters<int> evens = new Characters<int>(evenDigits);
        foreach(int i in evens)
        {
    	    Console.WriteLine(i);
        }

    	bool[] booleans = { true, true, false, true };
    	Characters<bool> bools = new Characters<bool>(booleans);

    	foreach(bool b in bools)
        {  
    	    Console.WriteLine(b);
        }
    }

}

// Pre-CS 2
// Non-Generic IEnumerable and IEnumerator interfaces
// Generic versions of IEnumerable and IEnumerator interfaces (>= CS 2)  prevent the additional cost of boxing/unboxing
// Business object
class Person
{
    public string firstName;
    public string lastName;

    public Person(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
    }
}

class EnumerableType : IEnumerable
{
    private Person[] persons; 
 
    public EnumerableType(Person[] persons)
    {
        this.persons = new Person[persons.Length];

        for (int i = 0; i < persons.Length; i++)
        {
            this.persons[i] = persons[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
       return (IEnumerator) GetEnumerator();
    }

    public EnumeratorType GetEnumerator()
    {
        return new EnumeratorType(persons);
    }
}

class EnumeratorType : IEnumerator
{
    public Person[] persons;

    // Enumerators are positioned before the first element until the first MoveNext() call
    int position = -1;

    public EnumeratorType(Person[] persons)
    {
        this.persons = persons;
    }

    public bool MoveNext()
    {
        position++;
        return (position < persons.Length);
    }

    public void Reset()
    {
        position = -1;
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public Person Current
    {
        get
        {
            try
            {
                return persons[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}

class EnumeratorTypeClient
{
    public void Print()
    {
        Console.WriteLine("Non-Generic IEnumerable and IEnumerator interfaces");
        Person[] persons = new Person[3] { new Person("Bill", "Gates"), new Person("Steve", "Jobs"), new Person("Larry", "Page") };

        EnumerableType enumerable = new EnumerableType(persons);
        EnumeratorType enumerator = enumerable.GetEnumerator();
        Console.WriteLine("EnumeratorType");
        while (enumerator.MoveNext())
        {
            Console.WriteLine("{0} {1}", enumerator.Current.firstName, enumerator.Current.lastName);
        }        
       
        /*       
        // The compiler translates the foreach block to a while loop like the earlier example
        // Under the hood, it’ll use the IEnumerator object returned from GetEnumerator method
        // While you can use the foreach block on any types that implements IEnumerable, IEnumerable is not designed for the foreach block
        Console.WriteLine("EnumerableType");
        foreach (Person p in enumerable)
        {
            Console.WriteLine("{0} {1}", p.firstName, p.lastName);
        }
        */    
    }
}

/*
// IEnumerable and IEnumerator interfaces are implementations of the iterator pattern
// IEnumerable interface
// Exposes an enumerator, which supports a simple iteration over a non-generic collection
// The GetEnumerator method here returns an IEnumerator object, which can be used to iterate (or enumerate) the given object
public interface IEnumerable
{
    IEnumerator GetEnumerator();
}

// When you implement IEnumerable, you must also implement IEnumerator
// IEnumerator interface
// Supports a simple iteration over a non-generic collection
// With this, the client code can use the MoveNext() method to iterate the given object and use the Current property to access one element at a time
public interface IEnumerator
{
    bool MoveNext();
    object Current { get; }
    void Reset();
}
*/

// 5. Partial Classes/Structs/Interfaces
// It is possible to split the definition of a class or a struct, or an interface over two or more source files. 
// Each source file contains a section of the type, and all parts are combined when the application is compiled.
partial class PartialType // public partial struct P // All should be structs
{
    private int x;
    private int y;

    public PartialType(int x, int y) // Note: Constructor cannot be partial
    {
        this.x = x;
        this.y = y;
    }
}

// This part can be in a separate file.
partial class PartialType // public partial struct P // All should be structs
{
    public void Print()
    {
        Console.WriteLine("x = {0}, y = {1}", x, y);
    }
}

// 5. Partial Classes/Structs/Interfaces
partial interface IPartial
{
    void Medthod();
}

// This part can be in a separate file.
partial interface IPartial
{
    // Must be different or overloaded
    void Medthod(string s);
}

class ImplementingType : IPartial // partial class ImplementingType : IPartial // partial struct ImplementingType : IPartial
{
    public void Medthod()
    {
        Console.Write("Partial ");
    }

    public void Medthod(string s)
    {
        Console.WriteLine(s);
    }

    public void Print()
    {
        Medthod();
        Medthod("Type!");
    }
}

delegate int Delegates(int i);

class AnonymousMethods
{
    public void Print()
    {
        // 6. Anonymous method.
        Delegates DelegateObject = delegate(int number)
        {
            int sum = 0;
            for (int i = 0; i <= number; i++)
            {
                Console.Write(i + " ");
                sum += i;
            }
            return sum;
        }; // Note

        int result = DelegateObject(3);
        Console.WriteLine("Summation: " + result);
    }
}

namespace N1
{
    class C
    {
        int i;
        public C(int i)
        {
            this.i = i;
            Console.WriteLine("Number passed to Namespace N1 is " + i);
        }
    }
}

namespace N2
{
    // Same class as in N1
    class C
    {
        int i;
        public C(int i)
        {
            this.i = i;
            Console.WriteLine("Number passed to Namespace N2 is " + i);
        }
    }
}

class NamespaceAliasQualifier
{
    public void Print()
    {
        // 7. The :: operator (Namespace Alias Qualifier)
        // Here, the :: operator (Namespace Alias Qualifier) tells
        // the compiler to use the class C 
        // that is in the N1 namespace.
        N::C c1 = new N::C(10);
        // Note
        N2.C c2 = new N2.C(20);
    }
}

// 8. static classes
static class StaticClass
{
    public static int i;

    // Access modifiers are not allowed on static constructors
    // A static constructor must be parameterless
    static StaticClass()
    {
        i = 100;
    }

    public static void Print()
    {
        Console.WriteLine("static class member variable value: " + i);
    }
}

class BaseClass { }

class DerivedClass : BaseClass { }

// 9. Covariance and contravariance
delegate BaseClass Covariance();
delegate void Contravariance(DerivedClass dc);

class CovarianceContravariance
{
    DerivedClass CovarianceMethod()
    {
        DerivedClass dc = new DerivedClass();
        Console.WriteLine("Covariance Method: {0}", dc.GetType());
        return dc;
    }

    void ContravarianceMethod(BaseClass bc)
    {
        Console.WriteLine("Contravariance Method: {0}", bc.GetType());
    }

    public void Print()
    {
        // 13. Delegate Method Group Conversion
        Covariance co = CovarianceMethod; //Covariance co = new Covariance(CovarianceMethod);
        co += CovarianceMethod; //Note
        co -= CovarianceMethod; //Note
        Contravariance contra = ContravarianceMethod; //Contravariance Contra = new Contravariance(ContravarianceMethod);
        co();
        DerivedClass dc = new DerivedClass();
        contra(dc); //Note
    }
}

/*
// 10. Fixed-size buffers [Note: Available only in an unsafe context]
// Compiling unsafe:
// csc Program.cs /unsafe
// Create a fixed-size buffer.
unsafe struct FixedBankRecord
{
    public fixed byte name[80]; // create a fixed-size buffer
    public double balance;
    public long ID;
}
*/

class Properties
{
    string propertyName;

    // 14. Access Modifiers with Accessors
    // Accessibility modifiers on accessors may only be used if the property or indexer has both a get and a set accessor
    // Cannot specify accessibility modifiers for both accessors of the property or indexer
    // The accessibility modifier of the get or set accessor must be more restrictive than the property or indexer
    // Event accessor declarations are available in pre-C# 2.0. Modifiers cannot be placed on event accessor declarations in C# at all
    internal protected string Property
    {
        internal get
        {
            return propertyName;
        }
        set
        {
            propertyName = value;
        }
    }

    public void Print()
    {
        Property = "Access Modifiers only with either Accessor of the property";
        Console.WriteLine(Property);
    }
}

class FailSoftArray
{
    int[] integerArray; // reference to underlying array
    public int arrayLength; // arrayLength is public
    public bool errorFlag; // indicates outcome of last operation
    // Construct array given its size
    public FailSoftArray(int size)
    {
        integerArray = new int[size];
        arrayLength = size;
    }
    // This is the indexer for FailSoftArray
    public int this[int index]
    {
        // This is the get accessor
        get
        {
            if (Okay(index))
            {
                errorFlag = false;
                return integerArray[index];
            }
            else
            {
                errorFlag = true;
                return 0;
            }
        }

        // 14. Access Modifiers with Accessors
        // This is the set accessor
        internal set
        {
            if (Okay(index))
            {
                integerArray[index] = value;
                errorFlag = false;
            }
            else
            {
                errorFlag = true;
            }
        }
    }
    // Return true if index is within bounds
    private bool Okay(int index)
    {
        if (index >= 0 & index < arrayLength)
        {
            return true;
        }
        return false;
    }
}

class FailSoftClient
{
    public void Print()
    {
        FailSoftArray fsa = new FailSoftArray(5);
        int number;

        for (int i = 0; i < (fsa.arrayLength * 2); i++)
        {
            fsa[i] = i * 10;
        }

        Console.WriteLine("Fail quietly:");
        for (int i = 0; i < (fsa.arrayLength * 2); i++)
        {
            number = fsa[i];
            if (number != -1)
            {
                Console.Write(number + " ");
            }
        }
        Console.WriteLine();

        Console.WriteLine("Fail with error reports:");
        for (int i = 0; i < (fsa.arrayLength * 2); i++)
        {
            number = fsa[i];
            if (!fsa.errorFlag)
            {
                Console.Write(number + " ");
            }
            else
            {
                Console.WriteLine("fsa[" + i + "] out-of-bounds");
            }
        }
    }
}

// 17. System.Predicate
/*
C# 2.0 introduced a new feature: the predicate. A predicate is a delegate of type
System.Predicate that returns either true or false, based upon some condition.
The object to be tested against the condition is passed in obj. If obj satisfies that condition,
the predicate must return true. Otherwise, it must return false. Predicates are used by
several new methods added to Array by C# 2.0, including Exists( ), Find( ), FindIndex( ), and FindAll().
The following program demonstrates using a predicate to determine if an array of integers
contains a negative value. If a negative value is found, the program then obtains the first
negative value in the array. To accomplish this, the program uses Exists( ) and Find( ).
*/
class Predicates
{
    // A predicate method.
    // Returns true if Value is negative.
    bool isNegative(int val)
    {
        if (val < 0)
        {
            return true;
        }
        return false;
    }

    public void Print()
    {
        int[] numbers = { 1, 4, -1, 5, -9 };
        Console.Write("Contents of numbers: ");
        foreach (int i in numbers)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();

        // First see if nums contains a negative value.
        if (Array.Exists(numbers, isNegative))
        {
            Console.WriteLine("Numbers contain a negative value.");

            // Now, find first negative value.
            int x = Array.Find(numbers, isNegative);
            Console.WriteLine("First negative value is: " + x);
        }
        else
        {
            Console.WriteLine("Numbers contain no negative values.");
        }
    }
}

class Number
{
    public int integerNumber;

    public Number(int integerNumber)
    {
        this.integerNumber = integerNumber;
    }
}

// 18. System.Action 
/*
Another new feature introduced by C# 2.0 is the System.Action delegate. An Action is used
by another new C# feature, Array.ForEach( ), to perform an action on each element of an array.
The object to be acted upon is passed in obj. When used with ForEach( ), each element of the
array is passed to obj in turn. Thus, through the use of ForEach( ) and Action, you can, in a
single statement, perform an operation over an entire array.
The following program demonstrates both ForEach( ) and Action. It first creates an
array of Number objects, then uses the method Show( ) to display the values. Next, it uses Negate( ) to negate the values. Finally, it uses Show( ) again to display the negated values.
These operations all occur through calls to ForEach( ).
*/
class Actions
{
    // An Action method.
    // Displays the value it is passed.
    void Show(Number n)
    {
        Console.Write(n.integerNumber + " ");
    }

    // Another Action method.
    // Negates the value it is passed.
    void Negate(Number n)
    {
        n.integerNumber = -n.integerNumber;
    }

    public void Print()
    {
        Number[] numbers = new Number[5];
        numbers[0] = new Number(5);
        numbers[1] = new Number(4);
        numbers[2] = new Number(3);
        numbers[3] = new Number(2);
        numbers[4] = new Number(1);

        Console.Write("Contents of numbers: ");
        // Use action to show the values.
        Array.ForEach(numbers, Show);
        Console.WriteLine();

        // Use action to negate the values.
        Array.ForEach(numbers, Negate);
        Console.Write("Contents of numbers negated: ");
        // Use action to negate the values again.
        Array.ForEach(numbers, Show);
        Console.WriteLine();
    }
}

class Program
{
    // 10. Fixed-size buffers [Note: Available only in an unsafe context]
    // Mark Main as unsafe
    // unsafe static void Main()
    static void Main()
    {
        GClient gClnt = new GClient();
        gClnt.Print();

        NullableTypes nt = new NullableTypes();
        nt.Print();

        IteratorClient ic = new IteratorClient();
        ic.Print();

        EnumeratorTypeClient ec = new EnumeratorTypeClient();
        ec.Print();

        PartialType pt = new PartialType(1, 2);
        pt.Print();

        ImplementingType it = new ImplementingType();
        it.Print();

        AnonymousMethods am = new AnonymousMethods();
        am.Print();

        NamespaceAliasQualifier naq = new NamespaceAliasQualifier();
        naq.Print();

        StaticClass.Print();

        CovarianceContravariance cocontra = new CovarianceContravariance();
        cocontra.Print();

        FailSoftClient fsc = new FailSoftClient();
        fsc.Print();

        // 10. Fixed-size buffers [Note: Available only in an unsafe context]
        // Console.WriteLine("Size of FixedBankRecord is " + sizeof(FixedBankRecord));

        // 9. sizeof(type)
        Console.WriteLine("C# 2.0 sizeof(double): " + sizeof(double));
        Console.WriteLine("C# 2.0 sizeof(long): " + sizeof(long));

        // 11. Friend assemblies
        // Calculator calc = new Calculator();
        // Console.WriteLine("Using Friend Assembly, {0} power {1} = {2}", 2, 8, calc.Power(2, 8));
        
        /*
        // 12. extern aliases
        ExternAssembly1::ExternAssembly.ExternClass ec1 = new ExternAssembly1::ExternAssembly.ExternClass();
        ExternAssembly2::ExternAssembly.ExternClass ec2 = new ExternAssembly2::ExternAssembly.ExternClass();
        */

        Predicates predict = new Predicates();
        predict.Print();
        
        Actions act = new Actions();
        act.Print();
    }
}


/*
// ExternAssemblyA
// ExternAssemblyA.dll
// ExternClass.cs
// csc /target:library /out:ExternAssemblyA.dll ExternClass.cs
using System;

namespace ExternAssembly
{
    public class ExternClass  // Note: public
    {
        public ExternClass()
        {
            Console.WriteLine("Constructing from ExternAssemblyA.dll.");
        }
    }
}

// ExternAssemblyB
// ExternAssemblyB.dll
// ExternClass.cs
// csc /target:library /out:ExternAssemblyB.dll ExternClass.cs
using System;

namespace ExternAssembly
{
    public class ExternClass // Note: public
    {
        public ExternClass()
        {
            Console.WriteLine("Constructing from ExternAssemblyB.dll.");
        }
    }
}

// SignedFriendAssembly
// SignedFriendAssembly.dll
// Calculator.cs
// csc /keyfile:sgKeyCalculator.snk /target:library /out:SignedFriendAssembly.dll Calculator.cs
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Program, PublicKey=0024000004800000940000000602000000240000525341310004000001000100abb9e04800b33a7c9ee09160350f50bca67fe047171b167e5ab18b9630762da48de8f8f8bd085e8ac614b1506076810d83b2f8e8e0c83afe4dd3e8e8fceb32e8810fa6b050d65ed99e25cf6cec12f1eb032191277b6c86109712cc9273cfedcdccf3b77c31bb41a90c9f9489ccef3cb65992910de711022d8105384227fd438b")]
namespace SignedFriend
{
    class Calculator
    {
        internal int Power(int Number, int Exponent)
        {
            int Counter = 0;
            int Result = 1;
            while (Counter++ < Exponent)
            {
                Result *= Number;
            }
            return Result;
        }
    }
}

// Note
1.
Use the following sequence of commands with the Strong Name tool to generate a keyfile(sn.exe) and to display its public key. 

a.
Generate a strong-name key for this example and store it in the file sgKeyCalculator.snk:

sn -k sgKeyCalculator.snk

[Note: -k should be in lower case]
[On running: Key pair written to sgKeyCalculator.snk]

b.
Extract the public key from sgKeyCalculator.snk and put it into publicKeyCalculators.publickey:

sn -p sgKeyCalculator.snk publicKeyCalculators.publickey

[On running: Public key written to publicKeyCalculators.publickey]

c.
Display the public key stored in the file publicKeyCalculators.publickey:

sn -tp publicKeyCalculators.publickey

[On running:


Public key is
0024000004800000940000000602000000240000525341310004000001000100abb9e04800b33a
7c9ee09160350f50bca67fe047171b167e5ab18b9630762da48de8f8f8bd085e8ac614b1506076
810d83b2f8e8e0c83afe4dd3e8e8fceb32e8810fa6b050d65ed99e25cf6cec12f1eb032191277b
6c86109712cc9273cfedcdccf3b77c31bb41a90c9f9489ccef3cb65992910de711022d81053842
27fd438b

Public key token is 18bab1d69c990e13]

2.
The source code uses the InternalsVisibleToAttribute attribute to declare Program as a friend assembly.

The Strong Name tool generates a new public key every time it runs. Therefore, you must replace the public key in the following code with the public key you just generated, as shown in the following:

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Program, PublicKey=0024000004800000940000000602000000240000525341310004000001000100abb9e04800b33a7c9ee09160350f50bca67fe047171b167e5ab18b9630762da48de8f8f8bd085e8ac614b1506076810d83b2f8e8e0c83afe4dd3e8e8fceb32e8810fa6b050d65ed99e25cf6cec12f1eb032191277b6c86109712cc9273cfedcdccf3b77c31bb41a90c9f9489ccef3cb65992910de711022d8105384227fd438b")]
namespace SignedFriend
{
    class Calculator
    {
        internal int Power(int Number, int Exponent)
        {
            int Counter = 0;
            int Result = 1;
            while (Counter++ < Exponent)
            {
                Result *= Number;
            }
            return Result;
        }
    }
}

3.
Compile and sign Program.cs by using the following command:
csc /keyfile:sgKeyCalculator.snk /reference:SignedFriendAssembly.dll Program.cs]

// Note
Both the current assembly and the friend assembly must be unsigned, or both must be signed with a strong name. If they are signed with a strong name, the argument to the InternalsVisibleToAttribute constructor must include the full public key as well as the name of the assembly.
*/


/*
Courtesies:
C# 2.0 The Complete Reference by Herbert Schildt
https://docs.microsoft.com
*/