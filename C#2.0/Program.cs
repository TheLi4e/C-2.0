
using C_2._0;
internal class Program
{
    private static void Main(string[] args)
    {
        string path = "../../../";
        foreach (var file in HW10.SerchFilesByExtension(path))
        {
            Console.WriteLine(file);
        }

        Console.WriteLine();

        HW10.SerchTextInFiles(HW10.SerchFilesByExtension(path), "HW10");
    }
}
