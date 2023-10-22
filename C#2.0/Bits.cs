using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2._0
{
    //Реализуйте операторы неявного приведения из long,int,byt в Bits.
    internal class Bits : IBits
    {
        public long Value { get; set; } = 0;
        private int SizeOfValue { get; set; }

        public Bits(byte b)
        {
            Value = b;
            SizeOfValue = sizeof(byte) * 8;
        }

        public Bits(short b)
        {
            Value = b;
            SizeOfValue = sizeof(short) * 8;
        }

        public Bits(int b)
        {
            Value = b;
            SizeOfValue = sizeof(int) * 8;
        }

        public Bits(long b)
        {
            this.Value = b;
            SizeOfValue = sizeof(long) * 8;
        }
        public static implicit operator long(Bits b) => b.Value;
        public static implicit operator Bits(int b) => new Bits(b);
        public static implicit operator Bits(byte b) => new Bits(b);
        public static implicit operator Bits(short b) => new Bits(b);
        public static implicit operator Bits(long b) => new Bits(b);

        public bool GetBit(int i)
        {
            if (i > SizeOfValue || i < 0)
            {
                throw new Exception("Значение бита дожнобыть в пределах от 0 до 8");
            }
            return ((Value >> i) & 1) == 1;
        }

        public void SetBit(bool bit, int index)
        {
            if (index > SizeOfValue || index < 0) return;
            if (bit == true)
                Value = (byte)(Value | (1 << index));
            else
            {
                var mask = (byte)(1 << index);
                mask = (byte)(0xff ^ mask);
                Value &= (byte)(Value & mask);
            }
        }

        public void PrintBit()
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                for (int i = 0; i < 8; i++)
                {
                    sb.Append(GetBit(i) ? 1 : 0);

                }
                sb.ToString().Reverse();
                Console.WriteLine(sb);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

