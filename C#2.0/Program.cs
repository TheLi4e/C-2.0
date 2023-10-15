using System.Collections.Immutable;
using System.Text;
using C_2._0;
if (args.Length > 1)
{
    List<string> list = args.ToList();

    while (list.Contains("*") || list.Contains("/"))
    {
        list = MathForString.CalculateStringMultAndDiv(list);
    }
    while (list.Contains("+") || list.Contains("-"))
    {
        list = MathForString.CalculateStringSumAndMinus(list);
    }

    Console.WriteLine($"Результат: {list[0]}");
}

int[,] a =
        {
            { 7, 3, 2 },
            { 4, 9, 6 },
            { 1, 8, 2 }
        };
int p = 0;
int[] b = new int[a.GetLength(0) * a.GetLength(1)];

for (int j = 0; j < a.GetLength(0); j++)
{
    for (int k = 0; k < a.GetLength(1); k++)
    {
        b[p] = a[j, k];
        p++;
    }
}
p = 0;
Array.Sort(b);

p = 0;
for (int j = 0; j < a.GetLength(0); j++)
{
    for (int k = 0; k < a.GetLength(1); k++)
    {
        a[j, k] = b[p];
        p++;
    }
}

for (int i = 0; i < a.GetLength(0); i++)
{
    for (int j = 0; j < a.GetLength(1); j++)
    {
        Console.Write(a[i, j]);
    }
    Console.WriteLine();
}

Console.ReadKey();



