// Inheritance - Constructor Overloading // base() and EXPLICIT parameterless DerivedClass constructor


using System;

class BaseClass
{
    double pwidth;       
    double pheight;      
     
    // Properties for width and height
    
    public double width  
    {
        get
        {
            return pwidth;
        }
        set
        {
            pwidth = value;
        }
    }

    public double height  
    {
        get
        {
            return pheight;
        }
        set
        {
            pheight = value;
        }
    }

    public BaseClass() // NoTE
    {

    }
        
    public BaseClass(double w, double h)
    {
        width = w;                        
        height = h;                       
    }
    
    public void methodD()
    {
        Console.WriteLine("\nThe width and height in BaseClass: " + width + " and " + height);
    }
}

class DerivedClass : BaseClass
{
    string style;
   
    public DerivedClass() // NoTE
    {

    }
          
    public DerivedClass(string s, double w, double h) : base(w, h)
    {
        style = s;
    }

    public double methodArea()
    {
        return width * height/2;
    }  

    public void methodStyle()
    {
        Console.WriteLine("\nThe style of the triangle in DerivedClass is: " + style);
    }
}

class MainClass
{
    static void Main()
    {
        Console.WriteLine("\nBaseClass constructor call: ");         
        BaseClass bc = new BaseClass(5.0, 5.0);   
        
        bc.methodD();                                                             

        Console.WriteLine("\nDerivedClass constructor call: ");
        BaseClass bcr;        
        DerivedClass dc = new DerivedClass("isosceles", 4.0, 4.0); 
        bcr = dc;
        
        bcr.methodD();                                                            
        dc.methodD();                                                             
        ((BaseClass)dc).methodD();                                                
        
        dc.methodStyle();                                                         
        Console.WriteLine("Area returned in DerivedClass = " + dc.methodArea());     
    }
}