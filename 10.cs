using System;

namespace IJunior {
    internal class Program {
        static void Main(string[] args) {            
            int multipleOne = 3;
            int multipleTwo = 5;
            int maxNumberExcluded = 101;
            
            Random random = new Random();
            int randomNumber = random.Next(maxNumberExcluded);
            int sum = 0;

            for (int i = 0; i <= randomNumber; ++i) {
                if (i % multipleOne == 0 || i % multipleTwo == 0) {
                    sum += i;
                }
            }

            Console.WriteLine($"Сумма чисел кратных {multipleOne} или {multipleTwo} до {randomNumber} (включительно) равна: {sum}");
        }
    }
}
