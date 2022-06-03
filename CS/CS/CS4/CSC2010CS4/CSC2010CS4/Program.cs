using System;
using System.Reflection;

class DynamicType
{
    public void Print()
    {
        Assembly AssemblyName = Assembly.LoadFrom("Sample.dll");
        Type AssemblyTypeName = AssemblyName.GetType("Mathematics.Maths");
        object Instance = Activator.CreateInstance(AssemblyTypeName);
        object Result = AssemblyTypeName.InvokeMember("IntegerSquare", BindingFlags.InvokeMethod, null, Instance, new object[] { 5 });

        int Number = (int)Result;
        Console.WriteLine("Number using Reflection: " + Number);

        //The type 'dynamic' has no constructors defined
        //dynamic Runtime = new dynamic(); //Won't compile
        dynamic Dynam = new object();
        dynamic Runtime = Activator.CreateInstance(AssemblyTypeName);

        Number = Runtime.IntegerSquare(5);
        Console.WriteLine("Number using dynamic: " + Number);

    }
}

struct Structure
{

}

//The approved types for an enum are byte, sbyte, short, ushort, int, uint, long, or ulong.
enum Days : byte {Sat=1, Sun, Mon, Tue, Wed, Thu, Fri};

interface IInterface
{

}

delegate void DelegateType();

class OptionalAndNamedArguments
{
    //Optional parameters must appear after all required parameters
    //public void OptionalArguments(int A = 1, int B, int C) //Won't compile
    //A ref or out parameter cannot have a default value
    //public void NamedArguments(int A, ref int B = 2, out int C = 3)
    //A default parameter value of a reference type other than string can only be initialized with null
    //Cannot specify a default value for a parameter array
    //A parameter array must be the last parameter in a formal parameter list //After Optional Arguments
    //There can be only 1 parameter array in a formal parameter list
    public void OptionalArguments(int A, int B = 2, int C = 3, dynamic D = null, object E = null, Structure S = new Structure(), Days Day = Days.Sun, IInterface Inter = null, DelegateType DT = null, int[] IntArray = null, params string[] StringArray)
    {
        Console.WriteLine("A = {0}, B = {1}, C = {2}", A, B, C);
    }

    public void NamedArguments(int A, int B = 2, int C = 3, int[] IntArray = null, params int[] IntegerArray)
    {
        Console.WriteLine("A = {0}, B = {1}, C = {2}", A, B, C);
    }

    public void Print()
    {
        OptionalArguments(111, 222);

        //Named argument specifications must appear after all fixed arguments have been specified
        //NamedArguments(C:333, 2, 1); //Won't compile
        NamedArguments(B: 2, C: 333, A: 1, IntArray: null, IntegerArray: new int[] { 500, 700 });
        NamedArguments(1, 2, 3, null, 5, 6); //5, 6 will be assigned to IntegerArray
        NamedArguments(1);
    }
}

class OptionalAndNamedWithConstructors
{
    int A;
    int B;
    int C;
    int[] IntArray;
    int[] IntegerArray;
    public OptionalAndNamedWithConstructors(int A, int B = 2, int C = 3, int[] IntArray = null, params int[] IntegerArray)
    {
        this.A = A;
        this.B = B;
        this.C = C;
        this.IntArray = IntArray;
        this.IntegerArray = IntegerArray;
    }

    public void Print()
    {
        Console.WriteLine("A = {0}, B = {1}, C = {2}", A, B, C);
    }
}

class Program
{
    static void Main()
    {
        DynamicType dt = new DynamicType();
        dt.Print();

        OptionalAndNamedArguments onargs = new OptionalAndNamedArguments();
        onargs.Print();

        OptionalAndNamedWithConstructors onargsc = new OptionalAndNamedWithConstructors(B: 2, C: 333, A: 1, IntArray: null, IntegerArray: new int[] { 500, 700 });
        onargsc.Print();

        //Console.ReadKey();
    }
}


/*
//Sample.dll
//Sample.cs
namespace Mathematics
{
    public class Maths
    {
        public int IntegerSquare(int Integer)
        {
            return Integer * Integer;
        }
    }
}
*/