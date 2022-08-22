// Generic class // using multiple constraints

using System;

class G<T1, T2> where T1: class where T2 : struct
{
    T1 t1;
    T2 t2;

    public G(T1 t1p, T2 t2p)
    {
        t1 = t1p;
        t2 = t2p;
    }       
}

enum e1{a, b, c, d}; // MUST

class MainClass
{
    enum e2{a, b, c, d}; // MUST

    bool[] args2 = new bool[2]; 

    static char[] args3 = new char[2]; 

    static void Main()
    {     
        MainClass mc = new MainClass();

        int[] args1 = new int[2];           

        G<string, int> Gsi = new G<string, int>("Hi", 1);

        G<MainClass, bool> GMCb = new G<MainClass, bool>(new MainClass(), true);
 
        G<int[], char> Giac = new G<int[], char>(args1, args3[1]);

        G<bool[], e1> Gbae1 = new G<bool[], e1>(mc.args2, e1.a);  

        G<char[], e2> Gcae2 = new G<char[], e2>(args3, e2.a);   
    }
}
             
       
                

    