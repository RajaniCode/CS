// Inheritance - Constructor Overloading // virtual // base()

// ?NOTE: virtual method overloaded


using System;

class TwoD
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

    public TwoD()
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

    public virtual double virtualmethodArea()
    {
        Console.WriteLine("virtualmethodArea() in TwoD, may be overridden");
        return 0.0;
    }

    public virtual double virtualmethodArea(int i) // ?NOTE
    {
        Console.WriteLine("virtualmethodArea() in TwoD, may be overridden");
        return 0.0;
    }
 
    public void methodD()
    {
        Console.WriteLine("width and height in TwoD are " + width + " and " + height);
    }
}

class Triangle : TwoD
{
    string style;

    public Triangle()
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

    public override double virtualmethodArea()
    {
        Console.WriteLine("virtualmethodArea() overridden in Triangle");    
        return (width * height) / 2;
    }

    public override double virtualmethodArea(int i) // ?NOTE
    {
        Console.WriteLine("virtualmethodArea() overridden in Triangle");    
        return (width * height) / 2;
    }

    public void methodStyle()
    {
        Console.WriteLine("\nstyle in Triangle: {0}\n", style);
    }
}
   
class Rectangle : TwoD
{
    public Rectangle()
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

    public override double virtualmethodArea()
    {
        Console.WriteLine("virtualmethodArea() overridden in Rectangle"); 
        return width * height;
           
    }

    public override double virtualmethodArea(int i) // ?NOTE
    {
        Console.WriteLine("virtualmethodArea() overridden in Rectangle"); 
        return width * height;
           
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
        TwoD[] TwoDObject = new TwoD[9];
        TwoDObject[0] = new TwoD(8D, 12D, "generic");                    // like bc
        TwoDObject[1] = new TwoD(10D, "generic");                        // like bc
        TwoDObject[2] = new TwoD(new TwoD());                // NOTE     // like bc
  
        TwoDObject[3] = new Triangle("right", 8D, 12D);                  // like bcr
        TwoDObject[4] = new Triangle(10D);                               // like bcr
        TwoDObject[5] = new Triangle(new Triangle());        // NOTE     // like bcr
       
        TwoDObject[6] = new Rectangle(8D, 12D);                          // like bcr
        TwoDObject[7] = new Rectangle(10D);                              // like bcr
        TwoDObject[8] = new Rectangle(new Rectangle());      // NOTE     // like bcr
        
        
        for(int i=0; i<TwoDObject.Length; i++)
        {
            Console.WriteLine("Name: " + TwoDObject[i].name);            
            Console.WriteLine("Area: " + TwoDObject[i].virtualmethodArea());
            Console.WriteLine();
        }
    }
}