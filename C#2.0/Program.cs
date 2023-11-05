using C_2._0;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography.X509Certificates;

internal class Program
{

    private static void Main(string[] args)
    {
        /*Отсортировать заказы по сумме в убывающем порядке.
        Сгруппировать заказы по клиентам и вывести количество заказов для каждого клиента.
        Найти клиента с наибольшей суммой заказов.
        Вывести список клиентов и общую сумму их заказов.
        Попросите студентов использовать LINQ для сортировки и группировки данных.*/
        List<Order> orders = new List<Order>
        {
            new Order { OrderID = 1, CustomerName = "Alice", OrderDate = new DateTime(2023, 6, 1), TotalAmount = 150.0 },
            new Order { OrderID = 2, CustomerName = "Bob", OrderDate = new DateTime(2023, 6, 2), TotalAmount = 75.5 },
            new Order { OrderID = 3, CustomerName = "Charlie", OrderDate = new DateTime(2023, 6, 2), TotalAmount = 220.0 },
            new Order { OrderID = 4, CustomerName = "David", OrderDate = new DateTime(2023, 6, 3), TotalAmount = 100.0 },
            new Order { OrderID = 5, CustomerName = "Alice", OrderDate = new DateTime(2023, 6, 4), TotalAmount = 85.5 },
            // Добавьте другие заказы по вашему усмотрению
        };

        //Отсортировать заказы по сумме в убывающем порядке.
        var sum = orders.OrderByDescending(x => x.TotalAmount);
        var sum2 = from order in orders
                   orderby order.TotalAmount
                   select order;
        //Сгруппировать заказы по клиентам и вывести количество заказов для каждого клиента.
        var totalAmountForClients = orders.GroupBy(x => x.CustomerName).Select(x => new { name = x.Key, count = x.Count() });
        //Найти клиента с наибольшей суммой заказов.
        var richClient = orders.GroupBy(x => x.CustomerName)
            .Select(x => new { name = x.Key, sumTotalAmount = x.Sum(ta => ta.TotalAmount) })
            .OrderBy(ta => ta.sumTotalAmount).Last().name;
        // Вывести список клиентов и общую сумму их заказов.
        var clientsTA = orders.GroupBy(x => x.CustomerName)
            .Select(x => new { name = x.Key, sumTotalAmount = x.Sum(ta => ta.TotalAmount) });

        sum.ToList().ForEach(x => Console.WriteLine($"{x.CustomerName} - {x.TotalAmount}"));
        totalAmountForClients.ToList().ForEach(x => Console.WriteLine($"{x.name} {x.count} "));
        Console.WriteLine(richClient);
        clientsTA.ToList().ForEach(x => Console.WriteLine($"{x.name} - {x.sumTotalAmount}"));

        /*В этой задаче у вас есть список строк, и ваша задача – отсортировать этот список 
         * в порядке возрастания длины строк, используя лямбда-выражение. 
         * Ниже приведены начальные данные и возможное решение:*/
        List<string> strings = new List<string>
        {
            "Apple",
            "Banana",
            "Cherry",
            "Date",
            "Fig",
            "Grapes"
        };

        strings.OrderBy(x=>x.Length).ToList().ForEach(x => Console.WriteLine(x));

        //Мы хотим выбрать все строки, содержащие определенную подстроку, с использованием лямбда - выражения.Вот начальные данные и решение задачи:
        List<string> words = new List<string>
        {
            "apple",
            "banana",
            "cherry",
            "date",
            "grape",
            "kiwi",
            "lemon",
        };

        string searchTerm = "an";
        words.Where(x => x.Contains(searchTerm)).ToList().ForEach(Console.WriteLine);

        //у нас есть список чисел, и мы хотим умножить каждое число в списке на 2, используя анонимный метод
        var numbedList2 = new List<int>() { 1,2,3,4,122,123,2323,212,23123,90};
        numbedList2.Select(x => x * 2).ToList().ForEach(Console.WriteLine);
    }
}