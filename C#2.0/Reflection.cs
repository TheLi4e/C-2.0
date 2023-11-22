using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace C_2._0
{
    internal class Reflection
    {
        internal void Run(string[] args)
        {
            Type type = typeof(TestClass);
            var s = ObjectToString(new TestClass(32, "string", 1.1m, new char[] { 'S', 't', 'R' }));
            Console.WriteLine(s);
            var o = StringToObject(s) as TestClass;
            Console.WriteLine(o.GetType());
        }

        static string ObjectToString(object obj)
        {
            StringBuilder sb = new();
            Type type = obj.GetType();
            sb.Append(type.Assembly.FullName + ":");
            sb.Append(type.Name + "|");
            List<PropertyInfo> properties = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance).ToList();
            properties.AddRange(type.GetProperties(BindingFlags.Public | BindingFlags.Instance));
            foreach (var prop in properties)
            {
                Console.WriteLine(prop.Name);
                var value = prop.GetValue(obj);
                sb.Append((prop.Name) + ":");
                if (prop.PropertyType == typeof(char[]))
                {
                    sb.Append(new String(value as char[]) + "|");
                }
                else
                    sb.Append(value + "|");
            }
            return sb.ToString();
        }

        static object StringToObject(string s)
        {
            var values = s.Split("|").ToList();
            values.Remove("");
            var classAssemblyAndName = values[0].Split(':');
            var obj = Activator.CreateInstance(classAssemblyAndName[0], "C_2._0.TestClass")?.Unwrap();
            if (values.Count > 1 && obj is not null)
            {
                var type = obj.GetType();
                Console.WriteLine(type);
                for (int i = 1; i < values.Count; i++)
                {
                    var nameAndValue = values[i].Split(':');
                    var pi = type.GetProperty(nameAndValue[0]);
                    Console.WriteLine($"{nameAndValue[0]}:{nameAndValue[1]}");
                    if (pi == null)
                        continue;
                    if (pi.PropertyType == typeof(int))
                    {
                        pi.SetValue(obj, int.Parse(nameAndValue[1]));
                    }
                    if (pi.PropertyType == typeof(string))
                    {
                        pi.SetValue(obj, nameAndValue[1]);
                    }
                    if (pi.PropertyType == typeof(decimal))
                    {
                        pi.SetValue(obj, decimal.Parse(nameAndValue[1]));
                    }
                    if (pi.PropertyType == typeof(char[]))
                    {
                        pi.SetValue(obj, nameAndValue[1].ToCharArray());
                    }
                }
            }
            return obj;
        }
    }
}