using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2._0
{
    internal class Calc
    {
        internal Action<object?, EventArgs> handler;

        public double _result { get; set; } = 0D;
        private Stack<double> LastResult { get; set; } = new Stack<double>();

        public event EventHandler<EventArgs> MyEventHandler;

        public Dictionary<string, string> Dict { get; set; } = new Dictionary<string, string>()
            {
            {"+", "Сложение" },
            {"-", "Вычитание" },
            {"*", "Умножение" },
            {"/", "Деление" },
            {"Отмена", "Отмена последней операции" },
            {" ", "Выход" }
            };
        private void PrintResult()
        {
            MyEventHandler?.Invoke(this, new EventArgs());
        }


        public void Divide(int x)
        {
            _result /= x;
            PrintResult();
            LastResult.Push(_result);
        }

        public void Multy(int x)
        {
            _result *= x;
            PrintResult();
            LastResult.Push(_result);
        }

        public void Sub(int x)
        {
            _result -= x;
            PrintResult();
            LastResult.Push(_result);
        }

        public void Sum(int x)
        {
            _result += x;
            PrintResult();
            LastResult.Push(_result);
        }

        public void CancelLast()
        {
            if (LastResult.TryPop(out double res))
            {
                _result = res;
                Console.WriteLine("Последнее действие отменено. Результат равен:");
                PrintResult();
            }
            else
            {
                Console.WriteLine("Невозможно отменить послдеднее действие!");
            }
        }

        public void PrintOperations()
        {
            Console.WriteLine("Доступные операции: ");
            foreach (var item in Dict)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
                Console.WriteLine();
            }
        }


        public int EnterNum()
        {
            Console.Write("Введите первое число: ");
            _result = int.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            var sNum = Console.ReadLine();
            if (int.TryParse(sNum, out int num)) { }
            Console.Clear();
            return num;
        }
        public void Run(int num)
        {
            bool a = true;
            PrintOperations();
            Console.Write("Введите знак математической операции:  ");
            string operation = Console.ReadLine()!;


            switch (operation)
            {
                case "+":
                    Sum(num);
                    break;
                case "-":
                    Sub(num); ;
                    break;
                case "/":
                    Divide(num); ;
                    break;
                case "*":
                    Multy(num); ;
                    break;
                case "Отмена":
                    CancelLast();
                    break;
                default:
                    Console.WriteLine("Введен некорректный символ. Попробуйте снова");
                    break;
            }
        }
    }
}

