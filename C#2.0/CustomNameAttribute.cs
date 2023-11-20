using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2._0
{
    [AttributeUsage(AttributeTargets.Property)]
    class CustomNameAttribute : Attribute
    {
        public string Name { get; }
        public CustomNameAttribute(string name) => Name = name;
    }
}