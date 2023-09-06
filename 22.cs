using System;
using System.Collections.Generic;

namespace IJunior
{
    internal class Program
    {
        // Пользователь вводит числа, и программа их запоминает.
        // Как только пользователь введёт команду sum, программа выведет сумму всех введенных чисел.
        // Выход из программы должен происходить только в том случае, если пользователь введет команду exit.        
        // Если введено не sum и не exit, значит это число и его надо добавить в массив.
        // Программа должна работать на основе расширения массива.
        // Внимание, нельзя использовать List<T> и Array.Resize.

        static void Main(string[] args)
        {
            string CommandExit = "exit";
            string CommandSum = "sum";

            int[] array = new int[0];
            string userInput = "";
            while (userInput != CommandExit)
            {
                Console.WriteLine("Введите число для добавления в массив, команду exit для выхода, " +
                    "или команду sum для вывода суммы элементов массива");
                userInput = Console.ReadLine();

                if (userInput == CommandSum)
                {
                    if (array.Length != 0)
                    {
                        int sum = 0;

                        foreach (int number in array)
                        {
                            sum += number;
                        }

                        Console.WriteLine("Сумма чисел массива: " + sum);
                    }
                    else
                    {
                        Console.WriteLine("Массив пуст, суммировать нечего.");
                    }
                }

                else if (userInput != CommandExit)
                {
                    int number = Convert.ToInt32(userInput);
                    int[] tempArray = new int[array.Length + 1];

                    for (int i = 0; i < array.Length; i++)
                    {
                        tempArray[i] = array[i];
                    }

                    tempArray[tempArray.Length - 1] = number;
                    array = tempArray;
                }
            }
        }
    }
}
