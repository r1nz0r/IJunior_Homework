using System;

namespace IJunior {
    internal class Program {
        static void Main(string[] args) {
            int minutesForPatient = 10;
                
            Console.Write("Введите кол-во старушек: ");
            int.TryParse(Console.ReadLine(), out int grannyAmmount);

            int minutesPerHour = 60;
            int totalMinutesInQueue = grannyAmmount * minutesForPatient;
            int hoursInQueue = totalMinutesInQueue / minutesPerHour;
            int remainingMinutesInQueue = totalMinutesInQueue % minutesPerHour;

            Console.WriteLine($"Вы должны отстоять в очереди: часов - {hoursInQueue}, минут - {remainingMinutesInQueue}");
        }
    }
}
