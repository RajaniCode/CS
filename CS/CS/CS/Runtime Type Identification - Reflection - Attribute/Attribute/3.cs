// Attrribute


// property as named parameter


using System;

[AttributeUsage(AttributeTargets.All)]
public class RemarkAttribute : Attribute
{
    string primaryremark;
    
    public string primaryremark2;
   
    int primarypriority;
  
    public RemarkAttribute(string comment)
    {
        primaryremark = comment;       

        primaryremark2 = "";
    }

    public string remark
    {
        get
        {
            return primaryremark;
        }
    }


    public int priority
    {
        get
        {
            return primarypriority;
        }

        set
        {
            primarypriority = value;
        }
    }
}


[RemarkAttribute("This class uses an attribute", primaryremark2 = "This is an additional information", priority = 1)]
class ClassUsingAttribute
{

}

class MainClass
{
    static void Main()
    {
        Type t = typeof(ClassUsingAttribute);

        Console.WriteLine("Attribute(s) in {0}", t.Name);

        object[] oa = t.GetCustomAttributes(false);

        foreach(object a in oa)
            Console.WriteLine(a);

        Console.WriteLine("Remark: ");

        Type tRA = typeof(RemarkAttribute);

        RemarkAttribute ra = (RemarkAttribute)Attribute.GetCustomAttribute(t, tRA);

        Console.WriteLine(ra.remark);

        Console.WriteLine("Additional remark: {0}", ra.primaryremark2);

        Console.WriteLine("Priority: {0}", ra.priority);
    }
}
       