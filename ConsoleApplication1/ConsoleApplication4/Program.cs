using System;
using System.IO;

namespace ConsoleApplication4
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
                    numbers[i] = (byte)random.Next(0, 256); // Генерация чисел от 0 до 255
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

                // Фильтрация четных чисел и запись их в файл G
                FileStream g = new FileStream("G.txt", FileMode.Create, FileAccess.Write);
                foreach (byte number in readNumbers)
                {
                    if (number % 2 == 0) // Проверка на четность
                    {
                        g.WriteByte(number); // Запись четного числа в файл G
                    }
                }
                g.Close();

                // Чтение данных из файла G
                g = new FileStream("G.txt", FileMode.Open, FileAccess.Read);
                byte[] evenNumbers = new byte[g.Length];
                g.Read(evenNumbers, 0, evenNumbers.Length);
                g.Close();

                // Вывод содержимого файла G
                Console.WriteLine("Содержимое файла G (четные числа из F):");
                foreach (byte number in evenNumbers)
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