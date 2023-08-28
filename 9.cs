using System;

namespace IJunior {
    internal class Program {
        static void Main(string[] args) {
            int startNumber = 5;
            int lastNumber = 96;
            int increment = 7;

            for (int number = startNumber; number <= lastNumber; number += increment) {
                Console.Write(number + " ");
            }
        }
    }
}
