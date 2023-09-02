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

            int currentBrackeySequence = 1;            

            Console.Write("Введите последовательность скобок: ");
            string brackeys = Console.ReadLine();
            char previousBrackey = ' ';

            foreach (var brackey in brackeys)
            {                
                if (brackey == openBrackey)                
                    brackeysCount++;                     
                else if (brackey == closeBrackey && brackeysCount > 0)                
                    --brackeysCount;                   
                else
                {
                    Console.WriteLine("Последовательность неверная.");
                    return;
                }

                if (brackey == previousBrackey)
                    ++currentBrackeySequence;
                else
                    currentBrackeySequence = 1;

               if (currentBrackeySequence > maxBrackeySequence)
                    maxBrackeySequence = currentBrackeySequence; 
                
                previousBrackey = brackey;
            }

            if (brackeysCount == 0)
                Console.WriteLine("Последовательность верная. Максимальная глубина равняется " + maxBrackeySequence);
            else
                Console.WriteLine("Последовательность неверная.");
        }      
    }
}
