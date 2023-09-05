using System;

namespace IJunior
{
    internal class Program
    {
        // Дан двумерный массив.
        // Вычислить сумму второй строки и произведение первого столбца.
        // Вывести исходную матрицу и результаты вычислений.

        static void Main(string[] args)
        {
            Random random = new Random();

            int rows = random.Next(2, 5);
            int columns = random.Next(2, 5);
            int[,] array = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array[i, j] = random.Next(0, 10);
                    Console.Write(array[i, j] + " ");
                }

                Console.WriteLine();
            }

            int sumRow = 0;

            for (int i = 0; i < columns; i++)
            {
                sumRow += array[1, i];
            }

            int productColumn = 1;

            for (int i = 0; i < rows; i++)
            {
                productColumn *= array[i, 0];
            }

            Console.WriteLine($"Сумма второй строки - {sumRow}, произведение первого столбца - {productColumn}");
            Console.ReadKey();
        }
    }
}
