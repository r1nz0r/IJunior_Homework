using System;

namespace IJunior {
    internal class Program {
        static void Main(string[] args) {
            string firstName = "Petrov";
            string surName = "Egor";

            Console.WriteLine($"Имя - {firstName}, Фамилия - {surName}");

            string temp = firstName;
            firstName = surName;
            surName = temp;

            Console.WriteLine($"Имя - {firstName}, Фамилия - {surName}");
        }
    }
}
