using System;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Создаем файл и записываем в него 10 случайных чисел
                FileStream f = new FileStream("F.txt", FileMode.Create, FileAccess.Write);
                byte[] numbers = new byte[10];
                Random random = new Random();

                for (int i = 0; i < 10; i++)
                {
                    numbers[i] = (byte)random.Next(0, 256); // Генерация чисел от 0 до 255
                }

                f.Write(numbers, 0, numbers.Length); // Запись чисел в файл
                f.Close();

                // Чтение файла и вывод всех чисел
                f = new FileStream("F.txt", FileMode.Open, FileAccess.Read);
                byte[] readNumbers = new byte[10];
                f.Read(readNumbers, 0, readNumbers.Length);

                Console.WriteLine("Все числа из файла:");
                foreach (byte number in readNumbers)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine();

                // Вывод четных чисел
                Console.WriteLine("Четные числа из файла:");
                foreach (byte number in readNumbers)
                {
                    if (number % 2 == 0) // Проверка на четность
                    {
                        Console.Write(number + " ");
                    }
                }

                f.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка работы с файлом: " + e.Message);
            }
        }
    }
}