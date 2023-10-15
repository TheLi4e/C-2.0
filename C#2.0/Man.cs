using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2._0
{
    internal class Man : Human
    {
        public Man(string name, string surname, Enum gender, DateTime birthday)
            : base(name, surname, gender, birthday)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
