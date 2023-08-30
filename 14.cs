using System;

namespace IJunior {
    internal class Program {
        static void Main(string[] args) {
            string password = "keyword";
            string hiddenMessage = "Красава!";

            int tryCount = 0;
            int maxTries = 3;

            while (tryCount < maxTries) {
                Console.Write("Введите пароль: ");
                string userInput = Console.ReadLine();

                if (userInput == password) {
                    Console.WriteLine(hiddenMessage);
                    break;
                }
                else {
                    Console.WriteLine($"Попытка №{++tryCount} неудачна. Осталось попыток: {maxTries - tryCount}");
                }

                Console.WriteLine();
            }
        }
    }
}
