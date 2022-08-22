// Inheritance - Constructor Overloading // abstract // base()

// ?NOTE: abstract method overloaded


using System;

abstract class TwoD
{
    double pwidth;
    double pheight;
    string pname;

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
        
    public string name
    {
        get
        {
            return pname;
        }
        set
        {
            pname = value;
        }
    }

    public TwoD() // #NOTE
    {
    
    }

    public TwoD(double w, double h, string n)
    {
        width = w;
        height = h;
        name = n;
    }

    public TwoD(double d, string n)
    {
        width = height = d;
        name = n;
    }    

    public TwoD(TwoD TwoDObject) // NOTE
    {
        width = TwoDObject.width;
        height = TwoDObject.height;
        name = TwoDObject.name;
    }

    public abstract double abstractmethodArea(); // MUST be overridden
    
    public abstract double abstractmethodArea(int i); // MUST be overridden // ?NOTE

    public void methodD()
    {
        Console.WriteLine("width and height in TwoD are " + width + " and " + height);
    }
}

class Triangle : TwoD
{
    string style;

    public Triangle() // #NOTE
    {

    }
    
    public Triangle(string s, double w, double h) : base(w, h, "triangle") // NOTE: "triangle" for string n (name = n) in base class
    {
        style = s;
    }

    public Triangle(double d) : base(d, "triangle") // NOTE: "triangle" for string n (name = n) in base class
    {
        style = "isosceles";
    }
            
    public Triangle(Triangle TriangleObject) : base(TriangleObject)  // NOTE
    {
        style = TriangleObject.style; // NOTE
    }

    public override double abstractmethodArea()
    {
        Console.WriteLine("abstractmethodArea() overridden in Triangle");    
        return (width * height) / 2;
    }

    public override double abstractmethodArea(int i)
    {
        Console.WriteLine("abstractmethodArea(int i) overridden in Triangle"); // ?NOTE   
        return (width * height) / 2;
    }

    public void methodStyle()
    {
        Console.WriteLine("\nstyle in Triangle: {0}\n", style);
    }
}
   
class Rectangle : TwoD
{
    public Rectangle() // #NOTE
    {

    }
 
    public Rectangle(double w, double h) : base(w, h, "rectangle") // NOTE: "rectangle" for string n (name = n) in base class
    {

    }

    public Rectangle(double d) : base(d, "rectangle") // NOTE: "rectangle" for string n (name = n) in base class
    {

    }
            
    public Rectangle(Rectangle RectangleObject) : base(RectangleObject) // NOTE
    {
 
    }

    public override double abstractmethodArea()
    {
        Console.WriteLine("abstractmethodArea() overridden in Rectangle");  
        return width * height;
           
    }

    public override double abstractmethodArea(int i) // ?NOTE 
    {
        Console.WriteLine("abstractmethodArea(int i) overridden in Triangle");    
        return (width * height) / 2;
    }

    public bool methodSquare()
    {
        if(width==height)
            return true;
        else
            return false;
    }
}





class MainClass
{
    static void Main()
    {
        TwoD[] TwoDObject = new TwoD[6]; //
        // TwoDObject[0] = new TwoD(8D, 12D, "generic");                 // NOT POSSIBLE because abstract
        // TwoDObject[1] = new TwoD(10D, "generic");                     // NOT POSSIBLE because abstract
        // TwoDObject[2] = new TwoD(new TwoD());             // #NOTE    // NOT POSSIBLE because abstract
                                                                           
        TwoDObject[0] = new Triangle("right", 8D, 12D);                  // like bcr
        TwoDObject[1] = new Triangle(10D);                               // like bcr
        TwoDObject[2] = new Triangle(new Triangle());        // #NOTE    // like bcr
       
        TwoDObject[3] = new Rectangle(8D, 12D);                          // like bcr
        TwoDObject[4] = new Rectangle(10D);                              // like bcr
        TwoDObject[5] = new Rectangle(new Rectangle());      // #NOTE    // like bcr
        
        
        for(int i=0; i<TwoDObject.Length; i++)
        {
            Console.WriteLine("Name: " + TwoDObject[i].name);            
            Console.WriteLine("Area: " + TwoDObject[i].abstractmethodArea());
            Console.WriteLine();
        }
    }
}