using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2._0
{
    internal class DoubleTryParse
    {
        public static bool MyDoubleTryParse(string s, out double num)
        {

            try
            {
                num = Double.Parse(s);
            }

            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                num = 0;
                return false;
            }

            catch
            {
                num = 0;
                return false;
            }

            return true;
        }
    }
}
