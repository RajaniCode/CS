// Reflection // Java // CS
import java.lang.reflect.Modifier;
import java.lang.StringBuilder;

class Program {   
    void Print(Class type) {       
        System.out.println("isArray(): " + type.isArray());
        System.out.println("getName(): " + type.getName());
        System.out.println("Modifier.isFinal(): " + Modifier.isFinal(type.getModifiers()));
        System.out.println("getSuperclass().getName(): " + type.getSuperclass().getName());
        System.out.println();
    }

    public static void main(String[] args) {        
        Class type1 = StringBuilder.class;
        Class type2 = String.class;
        Class type3 = String[].class;
        Class type4 = A.class;

        try {  
            Class clas = Class.forName("java.lang.StringBuilder");
            Object o = clas.newInstance();
            StringBuilder builder = (StringBuilder) o;
            builder.append("Hello, World!");
            String s = builder.toString();
            System.out.println(s);
            System.out.println();
        } catch(ClassNotFoundException e) {
            e.printStackTrace();
        } catch(InstantiationException e) {
            e.printStackTrace();
        } catch(IllegalAccessException e) {
            e.printStackTrace();
        }

        Program prgm = new Program();
        prgm.Print(type1);
        prgm.Print(type2);
        prgm.Print(type3);
        prgm.Print(type4);
    }
}

final class A { }

/*
import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.lang.reflect.Modifier;

class Program {
  public static void main(String[] argv) {
    Class cls = java.lang.String.class;
    Method method = cls.getMethods()[0];
    Field field = cls.getFields()[0];

    System.out.println(isPublicStaticFinal(field));
  }

  public static boolean isPublicStaticFinal(Field field) {
    int modifiers = field.getModifiers();
    return (Modifier.isPublic(modifiers) && Modifier.isStatic(modifiers) && Modifier.isFinal(modifiers));
  }
}
*/


// Output
/*
Note: Program.java uses or overrides a deprecated API.
Note: Recompile with -Xlint:deprecation for details.
Hello, World!

isArray(): false
getName(): java.lang.StringBuilder
Modifier.isFinal(): true
getSuperclass().getName(): java.lang.AbstractStringBuilder

isArray(): false
getName(): java.lang.String
Modifier.isFinal(): true
getSuperclass().getName(): java.lang.Object

isArray(): true
getName(): [Ljava.lang.String;
Modifier.isFinal(): true
getSuperclass().getName(): java.lang.Object

isArray(): false
getName(): A
Modifier.isFinal(): true
getSuperclass().getName(): java.lang.Object
*/