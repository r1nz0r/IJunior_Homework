using System;
using System.Collections.Generic;

namespace IJunior
{
    internal class Program
    {
        // Пользователь вводит числа, и программа их запоминает. Проверка на ввод числа обязательна.       
        // Как только пользователь введёт команду sum, программа выведет сумму всех веденных чисел.
        // Выход из программы должен происходить только в том случае, если пользователь введет команду exit.

        static void Main (string[] args)
        {
            string commandExit = "exit";
            string commandSum = "sum";

            List<int> numbers = new List<int>();
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.Write($"Введите число для добавления в массив, команду {commandExit} для выхода, " +
                    $"или команду {commandSum} для вывода суммы элементов массива: ");
                string userInput = Console.ReadLine();

                if (userInput == commandSum)
                {
                    Sum(numbers);
                    Pause();
                }
                else if (userInput == commandExit)
                {
                    isRunning = false;
                }
                else
                {
                    AddNumber(numbers, userInput);
                    Pause();
                }
            }
        }

        private static void AddNumber (List<int> numbers, string userInput)
        {
            if (int.TryParse(userInput, out int number))
            {
                Console.WriteLine($"Число {number} успешно добавлено.");
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine("Ошибка ввода.");
            }
        }

        private static void Pause ()
        {
            Console.Write("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }

        private static void Sum (List<int> numbers)
        {
            if (numbers.Count != 0)
            {
                int sum = 0;

                foreach (int number in numbers)
                {
                    sum += number;
                }

                Console.WriteLine("Сумма всех чисел равна " + sum);
            }
            else
            {
                Console.WriteLine("Суммировать нечего.");
            }
        }
    }
}
