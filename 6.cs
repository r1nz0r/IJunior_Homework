using System;

namespace IJunior {
    internal class Program {
        static void Main(string[] args) {
            int minutesForPatient = 10;

            Console.Write("Введите кол-во старушек: ");
            int.TryParse(Console.ReadLine(), out int grannyAmmount);

            int minutesInQueue = grannyAmmount * minutesForPatient;
            int hoursInQueue = minutesInQueue / 60;
            minutesInQueue %= 60;

            Console.WriteLine($"Вы должны отстоять в очереди: часов - {hoursInQueue}, минут - {minutesInQueue}");
        }
    }
}
