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

            int minRows = 2;
            int maxRows = 6;
            int minColumns = 2;
            int maxColumns = 6;
            int minArrayValue = 0;
            int maxArrayValue = 10;

            int rows = random.Next(minRows, maxRows);
            int columns = random.Next(minColumns, maxColumns);
            int[,] array = new int[rows, columns];

            int zeroIndex = 0;
            int firstIndex = 1;
            
            for (int i = 0; i < array.GetLength(zeroIndex); i++)
            {
                for (int j = 0; j < array.GetLength(firstIndex); j++)
                {
                    array[i, j] = random.Next(minArrayValue, maxArrayValue);
                    Console.Write(array[i, j] + " ");
                }

                Console.WriteLine();
            }

            int sumRow = 0;

            for (int i = 0; i < array.GetLength(firstIndex); i++)
            {
                sumRow += array[firstIndex, i];
            }

            int productColumn = 1;

            for (int i = 0; i < array.GetLength(zeroIndex); i++)
            {
                productColumn *= array[i, zeroIndex];
            }

            Console.WriteLine($"Сумма второй строки - {sumRow}, произведение первого столбца - {productColumn}");
        }
    }
}
