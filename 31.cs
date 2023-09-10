using System;
using System.Text;

namespace IJunior
{
    internal class Program
    {
        // Реализуйте функцию Shuffle, которая перемешивает элементы массива в случайном порядке.

        private static void Main(string[] args)
        {
            int[] numbers = { 0, 4, 6, 9, 12, 15, 19, 40 };
            Print(numbers);

            Shuffle(numbers);
            Print(numbers);

            Console.ReadKey();
        }

        private static void Print(int[] numbers)
        {
            foreach (int number in numbers)
                Console.Write(number + " ");

            Console.WriteLine();
        }

        private static void Shuffle(int[] numbers)
        {
            Random random = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                int shuffleIndexOne = random.Next(0, numbers.Length);
                int shuffleIndexTwo = random.Next(0, numbers.Length);

                int temp = numbers[shuffleIndexOne];
                numbers[shuffleIndexOne] = numbers[shuffleIndexTwo];
                numbers[shuffleIndexTwo] = temp;
            }
        }
    }
}
