using System;

namespace IJunior {
    internal class Program {
        static void Main(string[] args) {

            string name = Console.ReadLine();
            char symbol = Console.ReadKey(true).KeyChar;
            string middleRow = symbol + name + symbol;
            string frameTopBottom = "";

            for (int i = 0; i < middleRow.Length; ++i) {
                frameTopBottom += symbol;
            }

            Console.WriteLine(frameTopBottom);
            Console.WriteLine(middleRow);
            Console.WriteLine(frameTopBottom);
        }
    }
}
