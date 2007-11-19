using System;
using System.Collections.Generic;
using System.Reflection;

namespace Dolphin
{
    public class FunctionLoader
    {
        private static Dictionary<string, Assembly> assemblies = new Dictionary<string, Assembly>();

        public static PluginFunction GetFunction(string name)
        {
            string[] parts = name.Split(new char[] {','});
            if (parts.Length != 2)
            {
                throw new Exception("A fully qualified function name is required in form 'Namespace.Class, Assembly'");
            }

            return GetFunction(parts[1].Trim(), parts[0].Trim());
        }

        public static PluginFunction GetFunction(string module, string name)
        {
            LoadModule(module);
            return assemblies[module].CreateInstance(name) as PluginFunction;
        }

        public static List<Type> ListFunctionsInModule(string module, Type type)
        {
            LoadModule(module);
            List<Type> lst = new List<Type>();
            foreach (Type t in assemblies[module].GetTypes())
            {
                if (t.IsSubclassOf(type)) lst.Add(t);
            }

            return lst;
        }

        public static void LoadModule(string module)
        {
            if (!assemblies.ContainsKey(module))
            {
                assemblies[module] = Assembly.LoadFrom(module + ".dll");
            }
        }
    }
}