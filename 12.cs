using System;
using System.Data;
namespace IJunior {
    internal class Program {
        static void Main(string[] args) {
            const string CommandExit = "Exit";
            const string CommandShowCurrentDay = "ShowDay";
            const string CommandShowCurrentMonth = "ShowMonth";
            const string CommandShowCurrentYear = "ShowYear";
            const string CommandShowCurrentDate = "ShowDate";

            string userCommand = "";

            while (userCommand != CommandExit) {
                Console.Clear();
                Console.WriteLine("Введите желаемую команду:" +
                    "\nПоказать текущее число месяца - ShowDay" +
                    "\nПоказать текущий месяц - ShowMonth" +
                    "\nПоказать текущий год - ShowYear" +
                    "\nПоказать текущую дату - ShowDate" +
                    "\nВыйти из программы - Exit");
                userCommand = Console.ReadLine();

                switch (userCommand) {
                    case CommandExit:
                        Console.WriteLine("Всего доброго!");
                        break;
                    case CommandShowCurrentDay:
                        Console.WriteLine($"Сегодня {DateTime.Now.Day} число.");
                        break;
                    case CommandShowCurrentMonth:
                        string month;

                        if (DateTime.Now.Month == 1)
                            month = "январь";
                        else if (DateTime.Now.Month == 2)
                            month = "февраль";
                        else if (DateTime.Now.Month == 3)
                            month = "март";
                        else if (DateTime.Now.Month == 4)
                            month = "апрель";
                        else if (DateTime.Now.Month == 5)
                            month = "май";
                        else if (DateTime.Now.Month == 6)
                            month = "июнь";
                        else if (DateTime.Now.Month == 7)
                            month = "июль";
                        else if (DateTime.Now.Month == 8)
                            month = "август";
                        else if (DateTime.Now.Month == 9)
                            month = "сентябрь";
                        else if (DateTime.Now.Month == 10)
                            month = "октябрь";
                        else if (DateTime.Now.Month == 11)
                            month = "ноябрь";
                        else if (DateTime.Now.Month == 12)
                            month = "декабрь";
                        else
                            month = "unknown";

                        Console.WriteLine($"Сейчас месяц {month}.");
                        break;
                    case CommandShowCurrentYear:
                        Console.WriteLine($"Сейчас {DateTime.Now.Year} год.");
                        break;
                    case CommandShowCurrentDate:
                        Console.WriteLine($"Сегодняшняя дата: {DateTime.Now}");
                        break;
                    default:
                        Console.WriteLine("Неверная команда, повторите попытку.");
                        break;
                }
                Console.Write("Нажмите любую кнопку для продолжения...");
                Console.ReadKey();
            }
        }
    }
}
