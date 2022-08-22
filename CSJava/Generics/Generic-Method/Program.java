import java.lang.System;

class GenericMethod {
    public void setString(String s) {
        s += ", World!";
        System.out.println ("setString:" + s);
    }

    public void setInteger(Integer i) {
        i *= 100;
        System.out.println ("setInt:" + i);
    }
    
    public <T> void Method(T t) {
        switch (t.getClass().getName()) {
            case "java.lang.String":
                setString(String.valueOf(t));
                break;
            case "java.lang.Integer":
                setInteger ((Integer)t); // Note // Explicit cast
                break;
            default:
                break;
        }
        /*
        if (t instanceof java.lang.String)  {
            setString(String.valueOf(t));
        }
        else if(t instanceof java.lang.Integer) {
           setInteger ((Integer)t); // Note // Explicit cast
        }
        */
        System.out.println (t.getClass().getName());
    }
}

public class Program {
    public static void main(String[] args) {
        GenericMethod methodGeneric = new GenericMethod();
        String s = "Hello";
        Integer i = 1;
        methodGeneric.<String>Method(s);
        methodGeneric.<Integer>Method(i);
    }
}
