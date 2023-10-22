using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2._0
{
    internal interface IBits
    {
        public bool GetBit(int i);
        public void SetBit(bool bit, int index);
    }
}
