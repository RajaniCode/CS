// Attribute

// Positional and named parameters


using System;

[AttributeUsage(AttributeTargets.All)]
public class RemarkAttribute : Attribute  
{
    string primaryremark; // Note: for positional parameter
    
    public string primaryremark2; // Note: for named parameter; should be public, non-static 

    public RemarkAttribute(string comment)  
    {
        primaryremark = comment;
        primaryremark2 = ""; // Note
          
    }

    public string remark 
    {
        get
        {
            return primaryremark;
        }
    }
}

[RemarkAttribute("This class uses an attribute", primaryremark2 = "This is an additional info")] // Note
class ClassUsingAttribute
{

}

class MainClass
{
    static void Main()
    {
        Type t = typeof(ClassUsingAttribute);

        Console.Write("Attribute(s) in {0}: ", t.Name);

       
        object[] ao = t.GetCustomAttributes(false); 

        foreach(object a in ao)
            Console.WriteLine(a);

        Console.Write("Remark: ");

        Type tRA = typeof(RemarkAttribute);

        RemarkAttribute ra = (RemarkAttribute)Attribute.GetCustomAttribute(t, tRA); 
        Console.WriteLine(ra.remark);
        Console.Write( "Additional Remark: {0}", ra.primaryremark2); // Note
    }
}    
     