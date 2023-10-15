using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2._0
{
    internal class MathForString
    {
        public static List<string> CalculateStringMultAndDiv(List<string> list)
        {
            int index;
            foreach (var item in list)
            {
                if (item.Equals("*"))
                {
                    index = list.IndexOf("*");
                    list[index - 1] = ExecuteOperation(list[index - 1], list[index + 1], "*").ToString();
                    list.RemoveAt(index);
                    list.RemoveAt(index);
                    return list;
                }
                if (item.Equals("/"))
                {
                    index = list.IndexOf("/");
                    list[index - 1] = ExecuteOperation(list[index - 1], list[index + 1], "/").ToString();
                    list.RemoveAt(index);
                    list.RemoveAt(index);
                    return list;
                }
            }
            return list;
        }
        public static List<string> CalculateStringSumAndMinus(List<string> list)
        {
            int index;
            foreach (var item in list)
            {
                if (item.Equals("+"))
                {
                    index = list.IndexOf("+");
                    list[index - 1] = ExecuteOperation(list[index - 1], list[index + 1], "+").ToString();
                    list.RemoveAt(index);
                    list.RemoveAt(index);
                    return list;
                }
                if (item.Equals("-"))
                {
                    index = list.IndexOf("-");
                    list[index - 1] = ExecuteOperation(list[index - 1], list[index + 1], "-").ToString();
                    list.RemoveAt(index);
                    list.RemoveAt(index);
                    return list;
                }
            }
            return list;
        }

        public static int ExecuteOperation(string num1, string num2, string operation)
        {
            switch (operation)
            {
                case "*":
                    return int.Parse(num1) * int.Parse(num2);
                case "/":
                    return int.Parse(num1) / int.Parse(num2);
                case "-":
                    return int.Parse(num1) - int.Parse(num2);
                case "+":
                    return int.Parse(num1) + int.Parse(num2);
            }
            return default;

        }
    }
}
