using C_2._0;
internal class Program
{
    private static void Main(string[] args)
    {
        //Дан массив и число. Найдите три числа в массиве сумма которых равна искомому числу.
        //Подсказка: если взять первое число в массиве, можно ли найти в оставшейся его части два числа равных по сумме первому.

        var arr = new int[] { 1, 2, 0, 3, 6, 5, 4,  };
        int number = 6;
        HW6 hW6 = new HW6();
        List<string> result = hW6.FindNumbers(arr, number);
        foreach (string i in result)
            Console.WriteLine(i);
    }
} 