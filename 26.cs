using System;

namespace IJunior
{
    internal class Program
    {
        // Дан массив чисел.Нужно его сдвинуть циклически на указанное пользователем значение позиций влево, не используя других массивов.
        // Пример для сдвига один раз: {1, 2, 3, 4} => {2, 3, 4, 1}

        static void Main (string[] args)
        {
            Random random = new Random();

            int arraySize = 10;
            var array = new int[arraySize];

            for (int i = 0; i < array.Length; ++i)
                array[i] = random.Next(10);

            Console.WriteLine("Исходный массив:");

            for (int i = 0; i < array.Length; ++i)
                Console.Write(array[i] + " ");

            Console.WriteLine();
            Console.WriteLine("Введите значение сдвига массива");
            int.TryParse(Console.ReadLine(), out int shift);

            for (int i = 0; i < shift; ++i)
            {
                for (int j = 0; j < array.Length - 1; ++j)
                {
                    var temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }

            Console.WriteLine("Массив после сдвига:");

            for (int i = 0; i < array.Length; ++i)
                Console.Write(array[i] + " ");
        }
    }
}
