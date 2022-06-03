// reflection


// fully automatic type discovery


using System;
using System.Reflection;

class MainClass
{
    static void Main()
    {
        Assembly a = Assembly.LoadFrom("MyClasses.dll");
        
        Type[] to = a.GetTypes();
        
        Type t = to[0];

        Console.WriteLine("First type name: {0}", t.Name);
  
        ConstructorInfo[] co = t.GetConstructors();   // Note: For First Type

        ParameterInfo[] cpo = co[0].GetParameters(); // Note: For First Constructor
        
        object ob; // Note

        if(cpo.Length>0)
        {
            object[] constructorargs = new object[cpo.Length];

            for(int n=0; n<cpo.Length; n++)
                constructorargs[n] = 10 + n * 20; // Note: Only 1 Argument in First Constructor

            ob = co[0].Invoke(constructorargs);
        }
        else
            ob = co[0].Invoke(null);

        MethodInfo[] mo = t.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public); // Note: Ignore inherited methods

        foreach(MethodInfo m in mo)
        { 
            ParameterInfo[] po = m.GetParameters();  // Note: For each method

            switch(po.Length) 
            {
                case 0:
                     if(m.ReturnType==typeof(int))
                         Console.WriteLine("Result is : {0}", (int)m.Invoke(ob, null));
                     else if(m.ReturnType==typeof(void))
                         m.Invoke(ob, null);
                     break;

                case 1:
                    if(po[0].ParameterType==typeof(int))
                    {
                        object[] args = new object[1];
                        args[0] = 14;
                        if((bool)m.Invoke(ob, args))
                            Console.WriteLine("14 is between x and y");
                        else
                            Console.WriteLine("14 is not between x and y");
                    } 
                    break;

                case 2:
                    if((po[0].ParameterType==typeof(int)) && (po[1].ParameterType==typeof(int)))
                    {
                        object[] args = new object[2];
                        args[0] = 9;
                        args[1] = 18;
                        m.Invoke(ob, args);                      
                    } 
                    else if((po[0].ParameterType==typeof(double)) && (po[1].ParameterType==typeof(double)))
                    {
                        object[] args = new object[2];
                        args[0] = 1.12;
                        args[1] = 23.4;
                        m.Invoke(ob, args);                        
                    }
                    break;
            }
        }
    }
}