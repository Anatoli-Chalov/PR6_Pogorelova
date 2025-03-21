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
                // Создаем файл F и записываем в него 10 символов
                FileStream f = new FileStream("F.txt", FileMode.Create, FileAccess.Write);
                char[] symbols = new char[10];
                int index = 0;

                Console.WriteLine("Введите 10 символов:");
                while (index < 10)
                {
                    char c = Console.ReadKey().KeyChar; // Чтение символа с клавиатуры
                    if (c != ' ') // Игнорируем пробел
                    {
                        symbols[index] = c;
                        f.WriteByte((byte)symbols[index]); // Запись символа в файл
                        index++;
                    }
                }
                f.Close();

                // Чтение данных из файла F
                f = new FileStream("F.txt", FileMode.Open, FileAccess.Read);
                byte[] readBytes = new byte[10];
                f.Read(readBytes, 0, readBytes.Length);
                f.Close();

                // Подсчет больших латинских букв
                int uppercaseCount = 0;
                Console.WriteLine("\nСодержимое файла F:");
                foreach (byte b in readBytes)
                {
                    char c = (char)b;
                    Console.Write(c + " "); // Вывод символов для наглядности
                    if (c >= 'A' && c <= 'Z') // Проверка на большую латинскую букву
                    {
                        uppercaseCount++;
                    }
                }

                // Вывод результата
                Console.WriteLine("\nКоличество больших латинских букв: " + uppercaseCount);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка работы с файлом: " + e.Message);
            }
        }
    }
}
