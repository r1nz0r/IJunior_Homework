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
            int[,] numbersArray = new int[rows, columns];

            for (int i = 0; i < numbersArray.GetLength(0); i++)
            {
                for (int j = 0; j < numbersArray.GetLength(1); j++)
                {
                    numbersArray[i, j] = random.Next(minArrayValue, maxArrayValue);
                    Console.Write(numbersArray[i, j] + " ");
                }

                Console.WriteLine();
            }

            int sumRow = 0;
            int firstColumn = 0;
            int secondRow = 1;

            for (int i = 0; i < numbersArray.GetLength(1); i++)
            {
                sumRow += numbersArray[secondRow, i];
            }

            int productColumn = 1;

            for (int i = 0; i < numbersArray.GetLength(0); i++)
            {
                productColumn *= numbersArray[i, firstColumn];
            }

            Console.WriteLine($"Сумма второй строки - {sumRow}, произведение первого столбца - {productColumn}");
        }
    }
}
