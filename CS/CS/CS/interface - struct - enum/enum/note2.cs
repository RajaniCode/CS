using System;

enum AppleEnum {Jonathan, GoldenDel, RedDel, Winesap, Cortland, McIntosh}; 

enum ColorEnum {Green, Yellow, Red, ReddishGreen, ReddishYellow, GreenishYellow};

class MainClass
{     
     static void Main()
    {
        AppleEnum aE;
        
        aE = AppleEnum.McIntosh;

        ColorEnum cE;

        cE = (ColorEnum)aE;

        Console.WriteLine(cE);

        Console.WriteLine((int)cE);
    }
}