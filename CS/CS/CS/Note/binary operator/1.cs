// binary operator


using System; 

class MainClass
{
    static void Main()
    {
        int x, y, r;
        float fr;

        x = 7;
        y = 5;

        r = x + y;        
        Console.WriteLine("{0} \"plus\" {1} is {2}", x, y, r);

        r = x - y;        
        Console.WriteLine("{0} \"minus\" {1} is {2}", x, y, r);
 
        r = x * y;        
        Console.WriteLine("{0} \"multiplied by\" {1} is {2}", x, y, r);

        fr =  (float) x / (float) y;        
        Console.WriteLine("{0} \"divided by\" {1} is {2}", x, y, fr);

        r = x % y;        
        Console.WriteLine("{0} \"modulo\" {1} is {2}", x, y, r);

        r += x;        
        Console.WriteLine("{0} += {1} is {2}", (x % y), (x), r);

    }
}
