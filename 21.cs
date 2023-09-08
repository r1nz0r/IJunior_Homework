using System;

namespace IJunior
{
    internal class Program
    {
        //  Дан одномерный массив целых чисел из 30 элементов.
        //  Найдите все локальные максимумы и вывести их.
        //  (Элемент является локальным максимумом, если он больше своих соседей).
        //  Крайний элемент является локальным максимумом, если он больше своего соседа.
        //  Программа должна работать с массивом любого размера.
        //  Массив всех локальных максимумов не нужен.

        static void Main(string[] args)
        {
            Random random = new Random();

            int arraySize = 30;

            if (arraySize == 0)
            {
                Console.WriteLine("Размер массива равен нулю, работа прекращена.");
                return;
            }

            int[] numbers = new int[arraySize];
            int minArrayNumber = 0;
            int maxArrayNumber = 20;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minArrayNumber, maxArrayNumber);
                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine();

            if (numbers.Length == 1)
            {
                Console.WriteLine("Локальный максимум - " + numbers[0]);
                return;
            }
            else
            {
                if (numbers[0] > numbers[1])
                    Console.WriteLine("Локальный максимум - " + numbers[0]);

                int lastIndex = numbers.Length - 1;

                for (int i = 1; i < lastIndex; i++)
                {
                    if (numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1])
                        Console.WriteLine("Локальный максимум - " + numbers[i]);
                }

                if (numbers[lastIndex] > numbers[lastIndex - 1])
                    Console.WriteLine("Локальный максимум - " + numbers[lastIndex]);
            }
        }
    }
}
