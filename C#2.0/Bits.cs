using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace C_2._0
{
    //Реализуйте операторы неявного приведения из long,int,byt в Bits.
    internal class Bits
    {
        byte Value { get; set; }
        public Bits(byte bits) { Value = bits; }

        public static implicit operator byte(Bits bits)
        {
            return new Bits(Convert.ToByte(bits)); 
        }

        public static implicit operator long(Bits bits)
        {
            return new Bits(Convert.ToByte(bits)); 
        }

        public static implicit operator int(Bits bits)
        {
            return new Bits(Convert.ToByte((bits)));
        }
    }
}

