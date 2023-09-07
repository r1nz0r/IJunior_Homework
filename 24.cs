using System;

namespace IJunior
{
    internal class Program
    {
        //Дан массив чисел (минимум 10 чисел). Надо вывести в консоль числа отсортированы, от меньшего до большего.
        //Нельзя использовать Array.Sort.Можно найти подходящий алгоритм сортировки и использовать его для задачи.

        static void Main (string[] args)
        {
            Random random = new Random();

            int arraySize = 10;
            int[] array = new int[arraySize];

            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = random.Next(0, 10);
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();

            for (int i = 1; i < array.Length; ++i)
            {
                for (int j = 0; j < array.Length - i; ++j)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            for (int i = 0; i < array.Length; ++i)
            {
                Console.Write(array[i] + " ");
            }

            Console.ReadKey();
        }
    }
}
