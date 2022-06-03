// Reflection


// obtaining types from assembly


using System;
using System.Reflection; // Note


class MainClass
{
    static void Main()
    {
        Assembly a = Assembly.LoadFrom("MyClasses.dll");
 
        Type[] to = a.GetTypes();
 
        foreach(Type temp in to) // Note
        {
            Console.WriteLine("Type name {0}", temp.Name);

        }

        Type t = to[0]; // First type

        Console.WriteLine("Using type name: {0}", t.Name);

        ConstructorInfo[] co = t.GetConstructors();
       
        foreach(ConstructorInfo c in co)
        {
            Console.Write(t.Name + "("); // note

            ParameterInfo[] po = c.GetParameters();
        
            for(int i=0; i<po.Length; i++)
            {
                Console.Write(po[i].ParameterType.Name + " " + po[i].Name);

                if(i+1 < po.Length)
                    Console.Write(" , ");
                
            }
            Console.Write(")");
            Console.WriteLine();
        }

        int x;

        for(x=0; x<co.Length; x++)
        {
            ParameterInfo[] po = co[x].GetParameters();
            
            if(po.Length==2)
            break;
        }
       
        if(x==co.Length)
        {
            Console.WriteLine("Constructor not found");
            return;
        }
        else
            Console.WriteLine("Two-parameter constructor found");
      
        object[] constructorargs = new object[2];
        constructorargs[0] = 10;
        constructorargs[1] = 20;
        object mc = co[x].Invoke(constructorargs);

        MethodInfo[] mo = t.GetMethods();
        
        foreach(MethodInfo m in mo)
        {
            ParameterInfo[] po = m.GetParameters();
        
            if( (m.Name.CompareTo("setMethod")==0) && (po[0].ParameterType==typeof(int)))
            {   
                object[] args = new object[2];
                args[0] = 9;
                args[1] = 18;
                m.Invoke(mc, args);
            }
        
            if((m.Name.CompareTo("setMethod")==0) && (po[0].ParameterType==typeof(double)))
            {   
                object[] args = new object[2];
                args[0] = 1.12;
                args[1] = 23.4;
                m.Invoke(mc, args);
            }
           
            if(m.Name.CompareTo("isBetweenMethod")==0)
            {   
                object[] args = new object[1];
                args[0] = 14;
                if((bool)m.Invoke(mc, args))
                    Console.WriteLine("14 is between x and y");
                else
                    Console.WriteLine("14 is not between x and y");    
            }     
             
            if(m.Name.CompareTo("additionMethod")==0)
            {   
                Console.WriteLine("Addition: {0}", ((int)m.Invoke(mc, null)));
            }
            
            if(m.Name.CompareTo("printMethod")==0)
            {   
                m.Invoke(mc, null);
            }
        }
    }
}     
 
       