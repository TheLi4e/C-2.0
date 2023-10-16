using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2._0
{
    internal class GUI
    {
        internal static void DrawWindow(int x, int y, int width, int height)
        {

            //шапка
            Console.SetCursorPosition(x, y);
            Console.Write("┌");
            for (int i = 0; i < width - 2; i++)
                Console.Write("─");
            Console.Write("┐");
            //окно
            Console.SetCursorPosition(x, y + 1);
            for (int i = 0; i < height - 2; i++)
            {
                Console.Write("│");
                for (int j = x + 1; j < x + width - 1; j++)
                    Console.Write(" ");
                Console.Write("│");
            }
            //подвал
            Console.Write("└");
            for (int i = 0; i < width - 2; i++)
                Console.Write("─");
            Console.Write("┘");
            Console.SetCursorPosition(x, y);
        }
    }
}
