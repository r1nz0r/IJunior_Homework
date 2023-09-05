using System;

namespace IJunior
{
    internal class Program
    {
        // Найти наибольший элемент матрицы A(10,10) и записать ноль в те ячейки, где он находятся.
        // Вывести наибольший элемент, исходную и полученную матрицу.
        // Массив под измененную версию не нужен.

        static void Main(string[] args)
        {
            Random random = new Random();

            int rows = 10;
            int columns = 10;
            int[,] array = new int[rows, columns];

            int maxNumber = int.MinValue;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array[i, j] = random.Next(0, 20);

                    if (array[i, j] > maxNumber)
                        maxNumber = array[i, j];
                }
            }

            Console.WriteLine("\nНаибольший элемент матрицы - " + maxNumber);
            Console.WriteLine("Исходная матрица:");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(String.Format("{0,5}", array[i, j]));
                }

                Console.WriteLine();
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (array[i, j] == maxNumber)
                        array[i, j] = 0;
                }
            }

            Console.WriteLine("\nПолученная матрица:");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(String.Format("{0,5}", array[i, j]));
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
