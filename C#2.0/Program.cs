using C_2._0;
internal class Program
{
    private static void Main(string[] args)
    {
        //Доработайте программу калькулятор реализовав выбор действий и вывод результатов на экран в цикле так,
        //чтобы калькулятор мог работать до тех пор пока пользователь не нажмет отмена или введёт пустую строку.

       Calc calc = new();
        calc.handler += SubscribeMyEvent;
        string exitCommand = String.Empty;
        string operation = String.Empty;
        string command = String.Empty;
        double num = 0;

        Console.WriteLine("Добро пожаловать в калькулятор.");

        while (true)
        {

            calc.Run();
            Console.WriteLine("Для завершения работы введите: " +
                "отмена или поставьте пробел и нажмите Enter\n" +
                "Для продолжения работы нажмите Enter");
            exitCommand = Console.ReadLine();
            if (exitCommand.ToLower().Equals("отмена") || exitCommand.ToLower().Equals(" "))
            {
                Console.WriteLine("Для завершения работы нажмите любую кнопку");
                Console.ReadKey(true);
                break;
            }
            Console.Clear();
        }
    }
    public static void SubscribeMyEvent(object? sender, EventArgs e)
    {
        if (sender is Calc)
            Console.WriteLine(((Calc)sender)._result);
    }
} 