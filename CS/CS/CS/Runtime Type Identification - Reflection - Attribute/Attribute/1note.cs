// Attribute


using System;

[AttributeUsage(AttributeTargets.All)]
public class RemarkAttribute : Attribute  // Note: RemarkAttribute is not a keyword
{
    string primaryremark; // Note: instance data
    
    public RemarkAttribute(string comment)  // Note: Constructor
    {
        primaryremark = comment;
    }

    public string remark // Note: public, read-only
    {
        get
        {
            return primaryremark;
        }
    }
}


[AttributeUsage(AttributeTargets.All)]
public class RemarkAttribute2 : Attribute  // Note: RemarkAttribute is not a keyword
{
    string primaryremark2; // Note: instance data
    
    public RemarkAttribute2(string comment2)  // Note: Constructor
    {
        primaryremark2 = comment2;
    }

    public string remark2 // Note: public, read-only
    {
        get
        {
            return primaryremark2;
        }
    }
}



[RemarkAttribute2("This class uses an attribute")]
[RemarkAttribute("This class uses an attribute")]
class ClassUsingAttribute
{

}

class MainClass
{
    static void Main()
    {
        Type t = typeof(ClassUsingAttribute);

        Console.Write("Attribute(s) in {0}: ", t.Name);

        //Note: GetCustomAttributes
        object[] ao = t.GetCustomAttributes(false); // Note: attribute array in ClassUsingAttribute

        foreach(object a in ao)
            Console.Write(a + " ");

        Console.Write("\nRemark: ");

        Type tRA = typeof(RemarkAttribute);

        //Note: GetCustomAttribute
        RemarkAttribute ra = (RemarkAttribute)Attribute.GetCustomAttribute(t, tRA); //Note: reference to attribute, to access its member (property)

        Console.WriteLine(ra.remark);
    }
}
          
     