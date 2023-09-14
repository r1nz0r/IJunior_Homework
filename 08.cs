using System;

namespace IJunior {
    internal class Program {
        static void Main(string[] args) {
            string exitWord = "exit";
            int throwCounter = 0;
            string userInput;
            
            do {
                Console.WriteLine($"Это ваш бросок под номером {++throwCounter}");
                Console.Write("Желаете совершить бросок или выйти? (да/exit): ");
                userInput = Console.ReadLine();                
            } while (userInput != exitWord);
        }
    }
}
