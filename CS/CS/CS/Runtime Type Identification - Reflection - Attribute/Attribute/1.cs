// Attribute


using System;

[AttributeUsage(AttributeTargets.All)]    // Note: AttributeUsage built-in attribute
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
            Console.WriteLine(a);

        Console.Write("Remark: ");

        Type tRA = typeof(RemarkAttribute);

        //Note: GetCustomAttribute
        RemarkAttribute ra = (RemarkAttribute)Attribute.GetCustomAttribute(t, tRA); //Note: reference to attribute, to access its member (property)

        Console.WriteLine(ra.remark);
    }
}
          
     