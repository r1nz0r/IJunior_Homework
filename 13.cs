using System;

namespace IJunior {
    internal class Program {
        static void Main(string[] args) {

            string name = Console.ReadLine();
            char symbol = (char)Console.Read();

            int symbolsOffset = 2;
            int symbolsInRow = name.Length + symbolsOffset;

            for (int i = 0; i < symbolsInRow; ++i) {
                Console.Write(symbol);
            }

            Console.WriteLine();
            Console.WriteLine(symbol + name + symbol);

            for (int i = 0; i < symbolsInRow; ++i) {
                Console.Write(symbol);
            }

            Console.WriteLine();
        }
    }
}
