using System;
using System.IO;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Создаем файл F и записываем в него случайные числа
                FileStream f = new FileStream("F.txt", FileMode.Create, FileAccess.Write);
                byte[] numbers = new byte[10];
                Random random = new Random();

                // Заполняем массив случайными числами
                for (int i = 0; i < 10; i++)
                {
                    numbers[i] = (byte)random.Next(1, 256); // Генерация чисел от 1 до 255
                }

                // Записываем числа в файл F
                f.Write(numbers, 0, numbers.Length);
                f.Close();

                // Чтение данных из файла F
                f = new FileStream("F.txt", FileMode.Open, FileAccess.Read);
                byte[] readNumbers = new byte[10];
                f.Read(readNumbers, 0, readNumbers.Length);
                f.Close();

                // Вывод содержимого файла F
                Console.WriteLine("Содержимое файла F:");
                foreach (byte number in readNumbers)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine();

                // Вычисление произведения чисел
                long product = 1; // Используем long, чтобы избежать переполнения
                foreach (byte number in readNumbers)
                {
                    product *= number;
                }

                // Вывод результата
                Console.WriteLine("Произведение чисел из файла F: " + product);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка работы с файлом: " + e.Message);
            }
        }
    }
}