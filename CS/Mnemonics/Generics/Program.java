// Generics // Java // CS
import java.lang.System;

class Program {
    public static void main(String[] args) {
        Generics<String> genericText = new Generics<String>("Hello, World!");
        String textGenerics = genericText.getObject();
        System.out.println("Object: " + textGenerics);
        genericText.showType();

        Generics<Integer> genericNumber = new Generics<Integer>(1234567890);
        int numberGenerics = genericNumber.getObject();
        System.out.println("Object: " + numberGenerics);
        genericNumber.showType();

        NonGenerics nonGenericText = new NonGenerics("Hello, World!");
        String textNonGenerics = (String)nonGenericText.getObject();
        System.out.println("Object: " + textNonGenerics);
        nonGenericText.showType();

        NonGenerics nonGenericNumber = new NonGenerics(1234567890);
        int numberNonGenerics = (int)nonGenericNumber.getObject();
        System.out.println("Object: " + numberNonGenerics);
        nonGenericNumber.showType();
    }
}

class Generics<T> {
    T obj;

    public Generics(T obj) {
        this.obj = obj;
    }

    public T getObject() {
        return obj;
    }

    public void showType() {
        System.out.println("Type getClass: " + obj.getClass());
        System.out.println("Type getClass getName: " + obj.getClass().getName());

        // System.out.println("Type class: " + Object.class); // Java only for built-in classes // Unlike CS typeof(T)
	// System.out.println("Type class getName: " + Object.class.getName()); // Java only for built-in classes // Unlike CS typeof(T).Name

    }
}

class NonGenerics {
    Object obj;

    public NonGenerics(Object obj) {
        this.obj = obj;
    }

    public Object getObject() {
        return obj;
    }

    public void showType() {
        System.out.println("Type getClass: " + obj.getClass()); // CS // obj.GetType()
	System.out.println("Type getClass getName: " + obj.getClass().getName()); // CS // obj.GetType().Name

    }
}

// Output
/*
Object: Hello, World!
Type getClass: class java.lang.String
Type getClass getName: java.lang.String
Object: 1234567890
Type getClass: class java.lang.Integer
Type getClass getName: java.lang.Integer
Object: Hello, World!
Type getClass: class java.lang.String
Type getClass getName: java.lang.String
Object: 1234567890
Type getClass: class java.lang.Integer
Type getClass getName: java.lang.Integer
*/