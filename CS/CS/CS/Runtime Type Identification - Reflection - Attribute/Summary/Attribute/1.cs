// Attribute


using System;

[AttributeUsage(AttributeTargets.All)]    // Note: AttributeUsage built-in attribute
class ClassAttribute : Attribute  // Note: System.Attribute
{
    string primaryremark;

    public  string secondaryremark; // Note: named parameter // should be public, read-write and non-static

    internal ClassAttribute(string comment)  // Note: positional parameter
    {
        primaryremark = comment;
        secondaryremark = "None"; //  
    }

    internal string remark // Note: can be internal
    {
        get
        {
            return primaryremark;
        }
    }
}

[ClassAttribute("This class uses an attribute", secondaryremark = "This is additional info")]
class ClassUsingAttribute
{

}

class MainClass
{
    static void Main()
    {
        Type t1 = typeof(ClassUsingAttribute);

        Console.WriteLine("Attribute(s) in {0}:", t1.Name);

        //Note: GetCustomAttributes
        object[] ao = t1.GetCustomAttributes(false); // 

        foreach (object a in ao)
            Console.WriteLine(a + "\n");

        Console.WriteLine("Remark: ");

        Type t2 = typeof(ClassAttribute);

        //Note: GetCustomAttribute
        ClassAttribute attributeClass = (ClassAttribute)Attribute.GetCustomAttribute(t1, t2); 
        Console.WriteLine(attributeClass.remark);
        Console.WriteLine(attributeClass.secondaryremark);
    }
}


/*
OUTPUT:
 * 
Attribute(s) in ClassUsingAttribute:
AttributeClass

Remark:
This class uses an attribute
This is additional info

*/