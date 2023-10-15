using C_2._0;

//Создаем двумерный массив
int[,] a = { { 7, 3, 2 }, { 4, 9, 6 }, { 1, 8, 5 } };

//Выводим на печать заданный массив
for (int i = 0; i <a.GetLength(0); i++)
{
    for (int j = 0; j < a.GetLength(1); j++)
    {
        Console.Write($"{a[i, j]}\t");
        
    }
    Console.WriteLine();
}

Console.WriteLine();

//Сортируем двумерный массив с помощью класса Arrays
var sortedArray = Arrays.Task1(Arrays.ConcatArray(a));

//Выводим на печать отсортированный массив
for (int i = 0; i < sortedArray.GetLength(0); i++)
{
    for (int j = 0; j < sortedArray.GetLength(1); j++)
    {
        Console.Write($"{sortedArray[i, j]}\t");

    }
    Console.WriteLine();
}