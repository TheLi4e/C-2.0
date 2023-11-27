using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2._0
{
    internal class HW10
    {
        public static IEnumerable<string> SerchFilesByExtension(string path)
        {
            return Directory.EnumerateFiles(path, "*.cs", SearchOption.AllDirectories);
        }

        public static void SerchTextInFiles(IEnumerable<string> files, string serchText)
        {
            foreach (var file in files)
            {
                using (StreamReader sr = new(file))
                {
                    while (!sr.EndOfStream)
                    {
                        string? readedString = sr.ReadLine();
                        if (readedString is null)
                            continue;
                        if (readedString.Contains(serchText))
                            Console.WriteLine($"Текст {serchText} содержится в файле: {file}");
                    }
                }
            }
        }
    }
}
