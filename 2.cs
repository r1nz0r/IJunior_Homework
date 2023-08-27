using System;

namespace IJunior {
    internal class Program {
        static void Main(string[] args) {
            Console.Write("Как вас зовут?: ");
            string name = Console.ReadLine();

            Console.Write("Какой ваш знак зодикак?: ");
            string zodiacSign = Console.ReadLine();

            Console.Write("Сколько вам лет?: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Где (кем) вы работаете?: ");
            string work = Console.ReadLine();

            Console.WriteLine($"Вас зовут {name}, вам {age} лет, вы {zodiacSign} и работаете {work}");
            Console.ReadKey();
        }
    }
}
