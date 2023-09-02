using System;

namespace IJunior
{
    internal class Program
    {
        //Дана строка из символов '(' и ')'. Определить, является ли она корректным скобочным выражением.
        //Определить максимальную глубину вложенности скобок.

        //Пример “(()(()))” - строка корректная и максимум глубины равняется 3.
        //Пример не верных строк: "(()", "())", ")(", "(()))(()"
      
        static void Main(string[] args)
        {
            char openBrackey = '(';
            char closeBrackey = ')';

            int brackeysCount = 0;
            int maxBrackeySequence = 0;

            Console.Write("Введите последовательность скобок: ");
            string brackeys = Console.ReadLine();

            foreach (var brackey in brackeys)
            {
                if (brackey == openBrackey)
                {
                    brackeysCount++;
                    maxBrackeySequence = 0;
                }
                else if (brackey == closeBrackey && brackeysCount > 0)
                {
                    --brackeysCount;
                    ++maxBrackeySequence;
                }
                else
                {
                    Console.WriteLine("Последовательность неверная.");
                    return;
                }
            }

            if (brackeysCount == 0)
                Console.WriteLine("Последовательность верная. Максимальная глубина равняется " + maxBrackeySequence);
            else
                Console.WriteLine("Последовательность неверная.");
        }
    }
}
