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

            int january = 1;
            int february = 2;
            int march = 3;
            int april = 4;
            int may = 5;
            int june = 6;
            int july = 7;
            int august = 8;
            int september = 9;
            int october = 10;
            int november = 11;
            int december = 12;

            string userCommand = "";

            while (userCommand != CommandExit) {
                Console.Clear();
                Console.WriteLine("Введите желаемую команду:" +
                    $"\nПоказать текущее число месяца - {CommandShowCurrentDay}" +
                    $"\nПоказать текущий месяц - {CommandShowCurrentMonth}" +
                    $"\nПоказать текущий год - {CommandShowCurrentYear}" +
                    $"\nПоказать текущую дату - {CommandShowCurrentDate}" +
                    $"\nВыйти из программы - {CommandExit}");
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
                        if (DateTime.Now.Month == january)
                            month = "январь";
                        else if (DateTime.Now.Month == february)
                            month = "февраль";
                        else if (DateTime.Now.Month == march)
                            month = "март";
                        else if (DateTime.Now.Month == april)
                            month = "апрель";
                        else if (DateTime.Now.Month == may)
                            month = "май";
                        else if (DateTime.Now.Month == june)
                            month = "июнь";
                        else if (DateTime.Now.Month == july)
                            month = "июль";
                        else if (DateTime.Now.Month == august)
                            month = "август";
                        else if (DateTime.Now.Month == september)
                            month = "сентябрь";
                        else if (DateTime.Now.Month == october)
                            month = "октябрь";
                        else if (DateTime.Now.Month == november)
                            month = "ноябрь";
                        else if (DateTime.Now.Month == december)
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
