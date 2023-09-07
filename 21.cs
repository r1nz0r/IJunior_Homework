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

            int[] array = new int[arraySize];
            int minArrayNumber = 0;
            int maxArrayNumber = 20;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minArrayNumber, maxArrayNumber);
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();

            if (arraySize == 1)
            {
                Console.WriteLine("Локальный максимум - " + array[0]);
                return;
            }
            else
            {
                if (array[0] > array[1])
                    Console.WriteLine("Локальный максимум - " + array[0]);

                for (int i = 1; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i - 1] && array[i] > array[i + 1])
                        Console.WriteLine("Локальный максимум - " + array[i]);
                }

                if (array[arraySize - 1] > array[array.Length - 2])
                    Console.WriteLine("Локальный максимум - " + array[array.Length - 1]);
            }
        }
    }
}
