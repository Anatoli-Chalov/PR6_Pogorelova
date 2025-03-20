using System;
using System.IO;

namespace ConsoleApplication2
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

                // Чтение файла и подсчет нечетных чисел
                f = new FileStream("F.txt", FileMode.Open, FileAccess.Read);
                byte[] readNumbers = new byte[10];
                f.Read(readNumbers, 0, readNumbers.Length);

                int oddCount = 0; // Счетчик нечетных чисел
                Console.WriteLine("Числа из файла:");
                foreach (byte number in readNumbers)
                {
                    Console.Write(number + " "); // Вывод всех чисел для наглядности
                    if (number % 2 != 0) // Проверка на нечетность
                    {
                        oddCount++;
                    }
                }

                Console.WriteLine("\nКоличество нечетных чисел: " + oddCount);
                f.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка работы с файлом: " + e.Message);
            }
        }
    }
}