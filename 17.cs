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

            int currentOpenBrackeySequence = 0;
            int currentCloseBrackeySequence = 0;

            Console.Write("Введите последовательность скобок: ");
            string brackeys = Console.ReadLine();

            foreach (var brackey in brackeys)
            {                

                if (brackey == openBrackey)
                {
                    brackeysCount++;
                    ++currentOpenBrackeySequence;
                    currentCloseBrackeySequence = 0;
                }
                else if (brackey == closeBrackey && brackeysCount > 0)
                {
                    --brackeysCount;
                    ++currentCloseBrackeySequence;
                    currentOpenBrackeySequence = 0;
                }
                else
                {
                    Console.WriteLine("Последовательность неверная.");
                    return;
                }

                if (currentOpenBrackeySequence > maxBrackeySequence)
                    maxBrackeySequence = currentOpenBrackeySequence;
                else if (currentCloseBrackeySequence > maxBrackeySequence)
                    maxBrackeySequence = currentCloseBrackeySequence;
            }

            if (brackeysCount == 0)
                Console.WriteLine("Последовательность верная. Максимальная глубина равняется " + maxBrackeySequence);
            else
                Console.WriteLine("Последовательность неверная.");
        }
    }
}
