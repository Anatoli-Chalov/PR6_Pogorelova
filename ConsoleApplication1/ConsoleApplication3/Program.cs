using System;
using System.IO;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Создаем два файла и записываем в них случайные числа
                FileStream f1 = new FileStream("F1.txt", FileMode.Create, FileAccess.Write);
                FileStream f2 = new FileStream("F2.txt", FileMode.Create, FileAccess.Write);
                byte[] numbers1 = new byte[10];
                byte[] numbers2 = new byte[10];
                Random random = new Random();

                // Заполняем массивы случайными числами
                for (int i = 0; i < 10; i++)
                {
                    numbers1[i] = (byte)random.Next(0, 256); // Генерация чисел от 0 до 255
                    numbers2[i] = (byte)random.Next(0, 256);
                }

                // Записываем числа в файлы
                f1.Write(numbers1, 0, numbers1.Length);
                f2.Write(numbers2, 0, numbers2.Length);
                f1.Close();
                f2.Close();

                // Чтение данных из файлов
                f1 = new FileStream("F1.txt", FileMode.Open, FileAccess.Read);
                f2 = new FileStream("F2.txt", FileMode.Open, FileAccess.Read);
                byte[] readNumbers1 = new byte[10];
                byte[] readNumbers2 = new byte[10];
                f1.Read(readNumbers1, 0, readNumbers1.Length);
                f2.Read(readNumbers2, 0, readNumbers2.Length);
                f1.Close();
                f2.Close();

                // Вывод содержимого файлов до обмена
                Console.WriteLine("Содержимое F1 до обмена:");
                foreach (byte number in readNumbers1)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine();

                Console.WriteLine("Содержимое F2 до обмена:");
                foreach (byte number in readNumbers2)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine();

                // Обмен данными между файлами
                f1 = new FileStream("F1.txt", FileMode.Create, FileAccess.Write);
                f2 = new FileStream("F2.txt", FileMode.Create, FileAccess.Write);
                f1.Write(readNumbers2, 0, readNumbers2.Length); // Записываем данные из F2 в F1
                f2.Write(readNumbers1, 0, readNumbers1.Length); // Записываем данные из F1 в F2
                f1.Close();
                f2.Close();

                // Чтение данных из файлов после обмена
                f1 = new FileStream("F1.txt", FileMode.Open, FileAccess.Read);
                f2 = new FileStream("F2.txt", FileMode.Open, FileAccess.Read);
                byte[] readNumbers1After = new byte[10];
                byte[] readNumbers2After = new byte[10];
                f1.Read(readNumbers1After, 0, readNumbers1After.Length);
                f2.Read(readNumbers2After, 0, readNumbers2After.Length);
                f1.Close();
                f2.Close();

                // Вывод содержимого файлов после обмена
                Console.WriteLine("Содержимое F1 после обмена:");
                foreach (byte number in readNumbers1After)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine();

                Console.WriteLine("Содержимое F2 после обмена:");
                foreach (byte number in readNumbers2After)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка работы с файлом: " + e.Message);
            }
        }
    }
}