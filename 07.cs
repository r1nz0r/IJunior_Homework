using System;

namespace IJunior {
    internal class Program {
        static void Main(string[] args) {
            Console.Write("Введите сообщения для повтора: ");
            string message = Console.ReadLine();

            Console.Write("Введите желаемое количество повторов: ");
            int.TryParse(Console.ReadLine(), out int repeatCount);

            for (int i = 0; i < repeatCount; i++) {
                Console.WriteLine(message);
            }
        }
    }
}
