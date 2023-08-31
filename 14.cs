using System;

namespace IJunior {
    internal class Program {
        static void Main(string[] args) {
            string password = "keyword";
            string hiddenMessage = "Красава!";

            int tryCount = 0;
            int maxTries = 3;

            string userInput = "";

            while (tryCount < maxTries && userInput != password) {
                Console.Write("Введите пароль: ");
                userInput = Console.ReadLine();

                if (userInput == password) 
                    Console.WriteLine(hiddenMessage);
                else 
                    Console.WriteLine($"Попытка №{++tryCount} неудачна. Осталось попыток: {maxTries - tryCount}");
                
                Console.WriteLine();
            }
        }
    }
}
