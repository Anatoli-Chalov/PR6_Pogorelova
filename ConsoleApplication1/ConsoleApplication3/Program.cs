using System;
using System.IO;
using System.Security.Cryptography;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Путь к файлу
                string filePath = @"C:\Users\Admin\Desktop\ \Cod C\MDK 01.04\PR6_Pogorelova\ConsoleApplication1\ConsoleApplication3/input.txt";

                // Чтение всех строк из файла
                string[] lines = File.ReadAllLines(filePath);

                // Поиск первой самой длинной строки
                string longestLine = "";
                foreach (string line in lines)
                {
                    if (line.Length > longestLine.Length)
                    {
                        longestLine = line;
                    }
                }

                // Вывод результата
                if (longestLine.Length > 0)
                {
                    Console.WriteLine("Первая самая длинная строка:");
                    Console.WriteLine(longestLine);
                }
                else
                {
                    Console.WriteLine("Файл пуст.");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден. Убедитесь, что файл input.txt существует.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
        }
    }
}