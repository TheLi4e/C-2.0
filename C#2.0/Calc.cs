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

        private void Print ()
        {

            Console.Write($"Ответ: {_result}\n");
        }


        public void Divide(double x, double y)
        {
            var answer = x / y;
            PrintResult();
            _result = answer;
            LastResult.Push(_result);
            Print();
        }

        public void Multy(double x, double y)
        {
            var answer = x * y;
            PrintResult();
            _result = answer;
            LastResult.Push(_result);
            Print();
        }

        public void Sub(double x, double y)
        {
            try
            {
                var answer = x - y;

                if (answer < 0)
                {
                    throw new ArgumentException("Нельзя получить ответ меньше 0");
                }
                PrintResult();
                _result = answer;
                LastResult.Push(_result);
                Print();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public void Sum(double x, double y)
        {
            var answer = x + y;
            PrintResult();
            _result = answer;
            LastResult.Push(_result);
            Print();
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


        public double EnterNum()
        {
            Console.WriteLine("Введите число: ");
            var fNum = Console.ReadLine();
            if (DoubleTryParse.MyDoubleTryParse(fNum, out double num))
            {
                if (num < 0)
                    throw new ArgumentException("Число не может быть меньше 0");

            }
            return num;
        }
        public void Run()
        {
            try
            {
                var x = EnterNum();
                var y = EnterNum();

                bool a = true;
                PrintOperations();
                Console.Write("Введите знак математической операции:  ");
                string operation = Console.ReadLine()!;

                switch (operation)
                {
                    case "+":
                        Sum(x, y);
                        break;
                    case "-":
                        Sub(x, y);
                        break;
                    case "/":
                        Divide(x, y);
                        break;
                    case "*":
                        Multy(x, y);
                        break;
                    case "Отмена":
                        CancelLast();
                        break;
                    default:
                        Console.WriteLine("Введен некорректный символ. Попробуйте снова");
                        break;
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}

