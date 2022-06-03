// class (essentially namespace)

// accessibility levels 1. public 2. intenal 3. default (A base class(internal, default) cannot be less accessible than derived class(public)


using System;

internal class A 
{
    public static int a1 = 1;
    private static int a2 = 2;
    protected static int a3 = 3;
    internal static int a4 = 4;
    protected internal static int a5 = 5;
    static int a6 = 6;
}

internal class B 
{
    public static int b1 = 7;
    private static int b2 = 8;
    protected static int b3 = 9;
    internal static int b4 = 10;
    protected internal static int b5 = 11;
    static int b6 = 12;

    public class C : A // Not possible if B is public as base class 'A' will be less accessible than class 'B.C'
    {
        public static int c1 = 13;
        private static int c2 = 14; 
        protected static int c3 = 15;
        internal static int c4 = 16; 
        protected internal static int c5 = 17;
        static int c6 = 18;
    }
 
    private class D
    {
        public static int d1 = 18;
        private static int d2 = 20;
        protected static int d3 = 21;
        internal static int d4 = 22;
        protected internal static int d5 = 23; 
        static int d6 = 24;
    }
          
    protected class E
    {     
        public static int e1 = 25;
        private static int e2 = 26;
        protected static int e3 = 27;
        internal static int e4 = 28;
        protected internal static int e5 = 29;
        static int e6 = 30;
    }  

    internal class F
    {
        public static int f1 = 31;
        private static int f2 = 32;
        protected static int f3 = 33;
        internal static int f4 = 34;
        protected internal static int f5 = 35;
        static int f6 = 36;
    }     
         
    protected internal class G
    {
        public static int g1 = 37;
        private static int g2 = 38;
        protected static int g3 = 39;
        internal static int g4 = 40;
        protected internal static int g5 = 41;
        static int g6 = 42;
    }
    
    class H
    {
        public static int h1 = 43;
        private static int h2 = 44;
        protected static int h3 = 45;
        internal static int h4 = 46;
        protected internal static int h5 = 47;
        static int h6 = 48;
    }  


    internal static class I 
    {
        public static int i1 = 49;
        private static int i2 = 50;
 
        internal static int i4 = 52;
   
        static int i6 = 54;
    }      
}

class J : B.C
{
    void myMethod()
    {
        J.c1 = 10; // But not J.b1 = 10;
    }
}

// Note: B.E cannot be derived because the base class cannot be less accessible than derived class

class K : B.F 
{

}

class L : B.G 
{

}


// Note: B.I cannot be derived because it's a static class

internal class MainClass
{
    static void Main()
    {
        A a = new A();
        
        B b = new B();

        B.C c = new B.C();
       
        B.F f = new B.F();

        B.G g = new B.G();                      
       
    }
}

