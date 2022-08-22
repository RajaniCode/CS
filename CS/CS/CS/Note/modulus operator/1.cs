// modulus operator


using System;

class MainClass
{
    static void Main()
    {
        
        //Denominator cannot be 0 and if numerator is 0 both % and / returns 0
        
        
        //If signed or |numerator| < |denominator|, % returns numerator with its original sign
        Console.WriteLine(-5 % 6);
        Console.WriteLine(-5 % -6);
        Console.WriteLine(5 % -6);
        Console.WriteLine(5 % 6);
        Console.WriteLine();

        //If signed or |numerator| < |denominator|, % returns numerator with its original sign 
        Console.WriteLine(-5.2 % 6.1);
        Console.WriteLine(-5.8 % -6.9);
        Console.WriteLine(5.4 % -6.2);
        Console.WriteLine(5.9 % 6);
        Console.WriteLine() ;
         

        //If signed or |numerator| > |denominator|, % returns remainder with the original sign of the numerator whether denominator is positive or negative
        Console.WriteLine(-5 % 3);
        Console.WriteLine(-5 % -3);
        Console.WriteLine(5 % -3);
        Console.WriteLine(5 % 3);
        Console.WriteLine();

        //If signed or |numerator| > |denominator|, % returns remainder with the original sign of the numerator whether denominator is positive or negative
        Console.WriteLine(-5.2 % 3.1);
        Console.WriteLine(-5.8 % -3.9);        
        Console.WriteLine(5.4 % -3.2);
        Console.WriteLine(5.9 % 3.1);
        Console.WriteLine();
        
        //But for division: If signed or |numerator| < or > |denominator|, normal division but decimal point for fraction
        Console.WriteLine(-5.0  / 6.0);
        Console.WriteLine(-5.0 / -6.0);
        Console.WriteLine(5.0  / -6.0);
        Console.WriteLine(5.0 / 6.0);
        Console.WriteLine(-5.0 / 3.0);
        Console.WriteLine(-5.0 / -3.0);
        Console.WriteLine(5.0 / -3.0);
        Console.WriteLine(5.0 / 3.0);
        Console.WriteLine();            
    }
}