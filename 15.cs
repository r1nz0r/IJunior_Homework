using System;

namespace IJunior {
    internal class Program {
        static void Main(string[] args) {
            Random random = new Random();
            int minNumber = 1;
            int maxNumber = 1025;
            int number = random.Next(minNumber, maxNumber);

            int result = 1;
            int powBase = 2;
            int pow = 0;

            while (result <= number) {
                ++pow;
                result *= powBase;
            }                

            Console.WriteLine($"Исходное число - {number}." +
                $"\nПолученная степень двойки - {pow}" +
                $"\nПолученное число - {result}");
        }        
    }
}
