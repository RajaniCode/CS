// unary operator


using System;

class MainClass
{
    static void Main()
    {
        int unary = 0;
        int preincrement;
        int predecrement;
        int postdecrement;
        int postincrement;
        int positive;
        int negative;
                    
        Console.WriteLine("Unary: {0}", unary);

        preincrement = ++unary;
        Console.WriteLine("Preincrement: {0}", preincrement);

        predecrement = --unary;
        Console.WriteLine("Predecrement: {0}", predecrement);

        postdecrement = unary--;
        Console.WriteLine("Postdecrement: {0}", postdecrement);

        postincrement = unary++;
        Console.WriteLine("Postincrement: {0}", postincrement );

        positive = -postincrement;
        Console.WriteLine("Positive: {0}", positive);

        negative = +postincrement;
        Console.WriteLine("Negative: {0}", negative);

        sbyte bitwiseNot;
        bitwiseNot = 127;
        bitwiseNot = (sbyte) ~bitwiseNot;
        Console.WriteLine("Bitwise not: {0}", bitwiseNot);
        
        short shortNot;
        shortNot = 32767;
        shortNot = (short) ~shortNot;
        Console.WriteLine("Bitwise not: {0}", shortNot);

        int intNot;
        intNot = 2147483647;
        intNot = (int) ~intNot;
        Console.WriteLine("Bitwise not: {0}", intNot);

        long longNot;
        longNot = 9223372036854775807;
        longNot = (long) ~longNot;
        Console.WriteLine("Bitwise not: {0}", longNot);

        bool logicalNot;
        logicalNot = false;
        logicalNot = !logicalNot;
        Console.WriteLine("Logical not: {0}", logicalNot);
    }
}


