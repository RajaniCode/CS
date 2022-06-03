using System;

struct StructureType
{

}

//The approved types for an enum are byte, sbyte, short, ushort, int, uint, long, or ulong.
enum EnumType : byte
{ Mon = 1, Tue, Wed, Thu, Fri, Sat, Sun };

class ClassType
{

}

abstract class AbstractClassType
{

}

static class StaticClassType
{

}

interface IInterfaceType
{

}

delegate void DelegateType();

class MainnApp
{
    void Print()
    {
        object obj = new object();
        object[] ObjectArray = new object[5];

        //The type 'dynamic' has no constructors defined
        //dynamic DynamicObject = new dynamic(); //Won't compile
        dynamic DynamicReferenceVariable = new object();
        dynamic[] DynamicArray = new dynamic[5];

        EnumType EnumObject = new EnumType();
        EnumType[] EnumArray= new EnumType[5];

        StructureType StructureObject = new StructureType();
        StructureType[] StructureArray = new StructureType[5];

        ClassType ClassObject = new ClassType();
        ClassType[] ClassArray = new ClassType[5];

        //AbstractClassType AbstractClassObject = new AbstractClassType(); //abstract class cannot be instantiated
        AbstractClassType AbstractClassReferenceVariable = null;
        AbstractClassType[] AbstractClassArray = new AbstractClassType[5];

        //static class cannot be instantiated
        //Cannot declare a variable of static type 'StaticClassType' hence cannot declare array of static type 'StaticClassType'  
        //StaticClassType StaticClassObject = new StaticClassType(); //Won't compile
        //StaticClassType StaticClassReferenceVariable = null;
        //StaticClassType[] StaticClassArray = new StaticClassType[5]; //Won't compile        

        //inferface cannot be instantiated
        //IInterfaceType InterfaceObject = new IInterfaceType(); 
        IInterfaceType InterfaceReferenceVariable = null;
        IInterfaceType[] InterfaceArray = new IInterfaceType[5];

        //'DelegateType' does not contain a constructor that takes 0 arguments
        //DelegateType DelegateObject = new DelegateType();
        DelegateType DelegateObject = new DelegateType(Print);
        DelegateType[] DelegateArray = new DelegateType[5];        
    }

    static void Main()
    {
        MainnApp App = new MainnApp();
        App.Print();

        Console.WriteLine("All's well.");
        Console.ReadKey();
    }
}

