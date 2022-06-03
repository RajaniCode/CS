// protected // Java // CS
import java.lang.System;

class Program {
    public static void main(String[] args) {   
        A a = new A();
        B b = new B();
        C c = new C();

        a = b; // 
        b = (B)a; // Exception b = (B)a; // When a = b is commented out
        // b = a as B; // No as keyword in Java

        B.methodB();
        c.method();
    }
}

class A {
    // default virtual // default access in Java is within the same package unlike C# where default is private
    void method() {
        System.out.println("Virtual in A");
    }

    // protected
    protected void methodA() {
        System.out.println("method in A");
    }
}

class B extends A { 
    // Scenarios // sealed // public // int
    @Override // default
    void method() { 
        System.out.println("Override in B");
        // return 1;
    }

    // Scenario: static
    public static void methodB() { 
        A a = new A();
        B b = new B();
        C c = new C();

        // methodA(); // Scenario: static
        // this.methodA(); // Scenario: static
        // base.methodA(); // Scenario: static
        a.methodA(); // Also Note: // protected // Unlike CS where protected is accessible from derived class in same/different/friend assembly // Java protected is accessible from derived class in the same/different package
        b.methodA();
        c.methodA();
        System.out.println("method B");
    }
}

class C extends B {
    @Override // default
    // No internal access specifier in Java // default access in Java is within the same package unlike C# where default is private
    void method() {
        System.out.println("Override in C");
    }
}

// Output
/*
method in A
method in A
method in A
method B
Override in C
*/