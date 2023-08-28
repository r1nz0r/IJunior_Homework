using System;

namespace IJunior {
    internal class Program {
        static void Main(string[] args) {
            Random random = new Random();
            int randomNumber = random.Next(100);
            int sum = 0;

            for (int number = 3; number <= randomNumber; ++number) {
                if (number % 3 == 0 || number % 5 == 0) {
                    sum += number;
                }
            }

            Console.WriteLine($"Сумма чисел кратных 3 или 5 до {randomNumber} (включительно) равна: {sum}");
        }
    }
}
