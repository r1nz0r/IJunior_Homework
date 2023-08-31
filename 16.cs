using System;

namespace IJunior {
    class Program {
        private static void Main(string[] args) {
            Random random = new Random();
            int minRandomValue = 1;
            int maxRandomValueExcluded = 3;            
            int N = random.Next(minRandomValue, maxRandomValueExcluded);

            int sum = 0;
            int multiplesCounter = 0;
            int minThreeDigitNumber = 100;
            int maxThreeDigitNumber = 999;

            while (sum <= maxThreeDigitNumber) {
                if (sum >= minThreeDigitNumber)
                    multiplesCounter++;

                sum += N;                
            }

            Console.WriteLine($"N = {N}, кол-во трехзначных кратных ему чисел: {multiplesCounter}.");
            Console.ReadKey();
        }
    }
}
