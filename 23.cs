using System;

namespace IJunior
{
    internal class Program
    {
        // В массиве чисел найдите самый длинный подмассив из одинаковых чисел.
        // Дано 30 чисел.Вывести в консоль сам массив, число, которое само больше раз повторяется подряд и количество повторений.
        // Дополнительный массив не надо создавать.
        // Пример: { 5, 5, 9, 9, 9, 5, 5} - число 9 повторяется большее число раз подряд.

        static void Main (string[] args)
        {
            Random random = new Random();

            int arraySize = 30;
            int[] array = new int[arraySize];

            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = random.Next(0, 10);
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();

            int currentRepeatCount = 1;
            int maxRepeatCount = 0;
            int maxRepeatedNumber = 0;

            for (int i = 0; i < array.Length - 1; ++i)
            {
                if (array[i] == array[i + 1])
                {
                    ++currentRepeatCount;

                    if (currentRepeatCount > maxRepeatCount)
                    {
                        maxRepeatedNumber = array[i];
                        maxRepeatCount = currentRepeatCount;
                    }
                }
                else
                {
                    currentRepeatCount = 1;
                }
            }

            if (maxRepeatCount == 0)
                Console.WriteLine("Нет повторяющихся последовательностей в массиве.");
            else
                Console.WriteLine($"Число {maxRepeatedNumber} повторяется наибольшее число раз подряд. Количество повторов - {maxRepeatCount}.");

            Console.ReadKey();
        }
    }
}
