// Override // Java // CS
import java.lang.System;

class Program {
    public static void main(String[] args) {     
	BaseClass bc = new BaseClass();                                                                                                                                                      
        BaseClass bcr;                                                                             
        DerivedClass dc = new DerivedClass();                                                                                                                        
        bcr = dc;                                                                              
                   
	System.out.println(bc.instanceMethod()); // BaseClass
	System.out.println(dc.instanceMethod()); // DerivedClass // if instanceMethod() not implemented in DerivedClass, BaseClass                                                                                                                                       
        System.out.println(bcr.instanceMethod()); // DerivedClass // Differs from CS regardless of 'new' modifier as methods are virtual by default in Java // if instanceMethod() not implemented in DerivedClass, BaseClass
        System.out.println(((BaseClass)dc).instanceMethod()); // DerivedClass // Differs from CS regardless of 'new' modifier as methods are virtual by default in Java // if instanceMethod() not implemented in DerivedClass, BaseClass
     }
}

class BaseClass {
    // hiding intended in CS // virtual by default in Java hence @Override  
    public String instanceMethod() {   
        return "instanceMethod() in BaseClass";
    }
}

class DerivedClass extends BaseClass {
    @Override // default
    // hiding intended in CS // virtual by default in Java hence @Override
    public String instanceMethod() {     
        return "instanceMethod() in DerivedClass";
    }
}

// Output
/*
instanceMethod() in BaseClass
instanceMethod() in DerivedClass
instanceMethod() in DerivedClass
instanceMethod() in DerivedClass
*/