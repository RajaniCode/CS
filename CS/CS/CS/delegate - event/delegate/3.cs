// C# 2.0 Delegate Method Group Conversion 

// delegate referring to instance method(s)


using System;

delegate string MyDelegate(string str); 

class MyClass
{
    public string reverseMethod(string a) 
    {
        Console.WriteLine("Reversing the string");
        string temp = "";
        int i;
        int j; //
        for(j=0, i=a.Length-1; i>=0; i--, j++) // for(i=a.Length-1; i>=0; i--)
            temp += a[i];
        return temp;   
    }
    
    public string methodConcat(string a)
    {
        Console.WriteLine("String Concatenation");
        string b = " and this is the concatenation";
        return string.Concat(a, b); // Also: String.Concat(a, b); 

    }
  
    public string methodCopy(string a)
    {
        Console.WriteLine("String Copy");
        string b = string.Copy(a); // Also: String.Copy(a);
        return b;

    }
    
    public string methodToUpper(string a)
    {
        Console.WriteLine("Upper case string");
        return a.ToUpper();
    }
    
    public string methodToLower(string a)
    {
        Console.WriteLine("Lower case string");
        return a.ToLower();
    }
}

class MainClass
{
    static void Main()
    {
        string s; 
        
        MyClass mc = new MyClass();

        MyDelegate mdstatic = mc.reverseMethod; // Note: object is NEEDED EVEN in case of same class; no parenthesis for the method 
        s = mdstatic("This is the string");
        Console.WriteLine("The reversed string is: {0} \n", s);

        mdstatic = mc.methodConcat; // Note: object is NEEDED EVEN in case of same class; no parenthesis for the method
        s = mdstatic("This is the string");
        Console.WriteLine("The concatenated string is: {0} \n", s);

        mdstatic = mc.methodCopy; // Note: object is NEEDED EVEN in case of same class; no parenthesis for the method
        s = mdstatic("This is the string");
        Console.WriteLine("The copied string is: {0} \n", s);  

        mdstatic = mc.methodToUpper; // Note: object is NEEDED EVEN in case of same class; no parenthesis for the method
        s = mdstatic("This is the string");
        Console.WriteLine("The string in upper case is: {0} \n", s);  

        mdstatic = mc.methodToLower; // Note: object is NEEDED EVEN in case of same class; no parenthesis for the method
        s = mdstatic("This is the string");
        Console.WriteLine("The string in lower case is: {0} \n", s);
    }
}