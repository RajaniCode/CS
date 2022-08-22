// string


using System;

class MyClass
{
    public void methodReplace(ref string sp)
    {
        Console.WriteLine("Replacing space with hyphen");
        sp = sp.Replace(' ', '-');
    }  
     
    public void methodRemove(ref string sp)
    {
        int i;

        string temp = String.Empty;
        Console.WriteLine("Removing space");
        for(i=0; i<sp.Length; i++)
        {
            if(sp[i] != ' ')
                temp += sp[i];
        }
        sp = temp;        
    } 

    public void methodReverse(ref string sp)
    {
        string temp = String.Empty;
        Console.WriteLine("Reversing string");
        for(int i=sp.Length-1; i >=0; i--)
            temp += sp[i];
        sp = temp;        
    }  
}

class MainClass
{
    static void Main()
    {
        MyClass mc = new MyClass();
      
        Console.WriteLine("Enter string");
        string s = Console.ReadLine();  
    
        mc.methodReplace(ref s);
        Console.WriteLine("The replaced string is: = {0} \n", s);

        mc.methodRemove(ref s);
        Console.WriteLine("The removed string is: = {0} \n", s);
    
        mc.methodReverse(ref s); 
        Console.WriteLine("The reversed string is: = {0} \n", s);   
    }
}



 