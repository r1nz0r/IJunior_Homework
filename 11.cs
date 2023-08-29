using System;

namespace IJunior {
    internal class Program {    
        static void Main(string[] args) {
            const double RubToCny = 0.0759;
            const double CnyToRub = 13.17;
            const double RubToUsd = 0.0106;
            const double UsdToRub = 94.5;
            const double CnyToUsd = 0.137;
            const double UsdToCny = 7.29;

            double rubBalance = 5000.0;
            double usdBalance = 100.0;
            double cnyBalance = 400.0;

            while (true) {
                Console.WriteLine("Добро пожаловать! У вас сейчас на балансе:" +
                $"\nДолларов - {usdBalance}" +
                $"\nРублей - {rubBalance}" +
                $"\nЮаней - {cnyBalance}\n");
                Console.WriteLine("Выберите операцию:" +
                    "\n1 - Рубли в юани" +
                    "\n2 - Юани в рубли" +
                    "\n3 - Рубли в доллары" +
                    "\n4 - Доллары в рубли" +
                    "\n5 - Юани в доллары" +
                    "\n6 - Доллары в юани" +
                    "\nexit - Выход");
                string userInput = Console.ReadLine().ToLower();
                Console.Clear();

                if (userInput == "exit") {
                    break;
                }
                else if (userInput == "1") {
                    Console.WriteLine($"Конвертация рублей в юани по курсу {RubToCny} юаней за рубль");
                    Console.Write("Сколько рублей хотите обменять?: ");
                    double.TryParse(Console.ReadLine(), out double ammountCurrency);

                    if (ammountCurrency > rubBalance) {
                        Console.WriteLine("К сожалению на вашем балансе недостаточно средств.");
                    }
                    else {
                        rubBalance -= ammountCurrency;
                        cnyBalance += ammountCurrency * RubToCny;
                        Console.WriteLine($"\nУспешный обмен.\n");
                    }
                }
                else if (userInput == "2") {
                    Console.WriteLine($"Конвертация юаней в рубли по курсу {CnyToRub} рублей за юань");
                    Console.Write("Сколько юаней хотите обменять?: ");
                    double.TryParse(Console.ReadLine(), out double ammountCurrency);

                    if (ammountCurrency > cnyBalance) {
                        Console.WriteLine("К сожалению на вашем балансе недостаточно средств.");
                    }
                    else {
                        cnyBalance -= ammountCurrency;
                        rubBalance += ammountCurrency * CnyToRub;
                        Console.WriteLine($"\nУспешный обмен.\n");
                    }
                }
                else if (userInput == "3") {
                    Console.WriteLine($"Конвертация рублей в доллары по курсу {RubToUsd} долларов за рубль");
                    Console.Write("Сколько рублей хотите обменять?: ");
                    double.TryParse(Console.ReadLine(), out double ammountCurrency);

                    if (ammountCurrency > rubBalance) {
                        Console.WriteLine("К сожалению на вашем балансе недостаточно средств.");
                    }
                    else {
                        rubBalance -= ammountCurrency;
                        usdBalance += ammountCurrency * RubToUsd;
                        Console.WriteLine($"\nУспешный обмен.\n");
                    }
                }
                else if (userInput == "4") {
                    Console.WriteLine($"Конвертация долларов в рубли по курсу {UsdToRub} рублей за доллар");
                    Console.Write("Сколько долларов хотите обменять?: ");
                    double.TryParse(Console.ReadLine(), out double ammountCurrency);

                    if (ammountCurrency > usdBalance) {
                        Console.WriteLine("К сожалению на вашем балансе недостаточно средств.");
                    }
                    else {
                        usdBalance -= ammountCurrency;
                        rubBalance += ammountCurrency * UsdToRub;
                        Console.WriteLine($"\nУспешный обмен.\n");
                    }
                }
                else if (userInput == "5") {
                    Console.WriteLine($"Конвертация юаней в доллары по курсу {CnyToUsd} долларов за юань");
                    Console.Write("Сколько юаней хотите обменять?: ");
                    double.TryParse(Console.ReadLine(), out double ammountCurrency);

                    if (ammountCurrency > usdBalance) {
                        Console.WriteLine("К сожалению на вашем балансе недостаточно средств.");
                    }
                    else {
                        cnyBalance -= ammountCurrency;
                        usdBalance += ammountCurrency * CnyToUsd;
                        Console.WriteLine($"\nУспешный обмен.\n");
                    }
                }
                else if (userInput == "6") {
                    Console.WriteLine($"Конвертация долларов в юани по курсу {UsdToCny} юаней за доллар");
                    Console.Write("Сколько долларов хотите обменять?: ");
                    double.TryParse(Console.ReadLine(), out double ammountCurrency);

                    if (ammountCurrency > usdBalance) {
                        Console.WriteLine("К сожалению на вашем балансе недостаточно средств.");
                    }
                    else {
                        usdBalance -= ammountCurrency;
                        cnyBalance += ammountCurrency * UsdToCny;
                        Console.WriteLine($"\nУспешный обмен.\n");
                    }
                }
            }
        }
    }
}
