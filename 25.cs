using System;

namespace IJunior
{
    internal class Program
    {
        // Дана строка с текстом, используя метод строки String.Split() получить массив слов,
        // которые разделены пробелом в тексте и вывести массив, каждое слово с новой строки.

        static void Main (string[] args)
        {
            Console.WriteLine("Введите строку текста: ");
            string text = Console.ReadLine();

            string[] words = text.Split(' ');

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
