// Inheritance - Constructor Overloading // ONLY base() for readonly


using System;

class BaseClass
{

    public readonly double width;  
   
    public readonly double height;  
           
    public BaseClass() 
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
 
    public DerivedClass(string s, double w, double h) : base(w, h) 
    {
        // width = w;   // NOT POSSIBLE because readonly
        // height = h;  // NOT POSSIBLE because readonly

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