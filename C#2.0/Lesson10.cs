using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2._0
{
    internal class Lesson10
    {
        //Напишите консольную утилиту для копирования файлов
        //Пример запуска: utility.exe file1.txt file2.txt

        public Lesson10() { }
        
        public void CopyFile (string path, string fileName2) 
        { 
            File.Copy (path, fileName2);
        }

        public void MyCopyFile (string path, string fileName1, string fileName2) 
        {
            if (!Path.Exists(path))
            {
                Console.WriteLine("Файл отсутствует");
                return;
            }

            using (StreamReader sr = new StreamReader(Path.Combine(path, fileName1)))
            {
                using (StreamWriter sr2 = new StreamWriter(fileName2))
                {
                    sr2.WriteLine(sr.ReadToEnd());
                }
            }
        }
    }
}
