using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2._0
{
    internal interface ICalc
    {
        //Спроектируем интерфейс калькулятора, поддерживающего простые
        //арифметические действия, хранящего результат и также способного
        //выводить информацию о результате  при помощи события

        double Result { get; set; }
        void Sum(double x);
        void Sub(double x);
        void Multy(double x);
        void Divide(double x);
        void CancelLast();
        event EventHandler<EventArgs> MyEventHandler;

    }
}
