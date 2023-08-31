using System;

namespace IJunior {
    internal class Program {
        static void Main(string[] args) {
            const double RateRubToCny = 0.0759;
            const double RateCnyToRub = 13.17;
            const double RateRubToUsd = 0.0106;
            const double RateUsdToRub = 94.5;
            const double RateCnyToUsd = 0.137;
            const double RateUsdToCny = 7.29;

            const string MenuConvertRubToCny = "1";
            const string MenuConvertCnyToRub = "2";
            const string MenuConvertRubToUsd = "3";
            const string MenuConvertUsdToRub = "4";
            const string MenuConvertCnyToUsd = "5";
            const string MenuConvertUsdToCny = "6";
            const string MenuExit = "exit";

            double rubBalance = 5000.0;
            double usdBalance = 100.0;
            double cnyBalance = 400.0;

            string userInput = "";

            while (userInput != "exit") {
                Console.WriteLine("Добро пожаловать! У вас сейчас на балансе:" +
                $"\nДолларов - {usdBalance}" +
                $"\nРублей - {rubBalance}" +
                $"\nЮаней - {cnyBalance}\n");
                Console.WriteLine("Выберите операцию:" +
                    $"\n{MenuConvertRubToCny} - Рубли в юани" +
                    $"\n{MenuConvertCnyToRub} - Юани в рубли" +
                    $"\n{MenuConvertRubToUsd} - Рубли в доллары" +
                    $"\n{MenuConvertUsdToRub} - Доллары в рубли" +
                    $"\n{MenuConvertCnyToUsd} - Юани в доллары" +
                    $"\n{MenuConvertUsdToCny} - Доллары в юани" +
                    $"\n{MenuExit} - Выход");
                userInput = Console.ReadLine().ToLower();
                Console.Clear();

                if (userInput == MenuConvertRubToCny) {
                    Console.WriteLine($"Конвертация рублей в юани по курсу {RateRubToCny} юаней за рубль");
                    Console.Write("Сколько рублей хотите обменять?: ");
                    double.TryParse(Console.ReadLine(), out double ammountCurrency);

                    if (ammountCurrency > rubBalance) {
                        Console.WriteLine("К сожалению на вашем балансе недостаточно средств.");
                    }
                    else {
                        rubBalance -= ammountCurrency;
                        cnyBalance += ammountCurrency * RateRubToCny;
                        Console.WriteLine($"\nУспешный обмен.\n");
                    }
                }
                else if (userInput == MenuConvertCnyToRub) {
                    Console.WriteLine($"Конвертация юаней в рубли по курсу {RateCnyToRub} рублей за юань");
                    Console.Write("Сколько юаней хотите обменять?: ");
                    double.TryParse(Console.ReadLine(), out double ammountCurrency);

                    if (ammountCurrency > cnyBalance) {
                        Console.WriteLine("К сожалению на вашем балансе недостаточно средств.");
                    }
                    else {
                        cnyBalance -= ammountCurrency;
                        rubBalance += ammountCurrency * RateCnyToRub;
                        Console.WriteLine($"\nУспешный обмен.\n");
                    }
                }
                else if (userInput == MenuConvertRubToUsd) {
                    Console.WriteLine($"Конвертация рублей в доллары по курсу {RateRubToUsd} долларов за рубль");
                    Console.Write("Сколько рублей хотите обменять?: ");
                    double.TryParse(Console.ReadLine(), out double ammountCurrency);

                    if (ammountCurrency > rubBalance) {
                        Console.WriteLine("К сожалению на вашем балансе недостаточно средств.");
                    }
                    else {
                        rubBalance -= ammountCurrency;
                        usdBalance += ammountCurrency * RateRubToUsd;
                        Console.WriteLine($"\nУспешный обмен.\n");
                    }
                }
                else if (userInput == MenuConvertUsdToRub) {
                    Console.WriteLine($"Конвертация долларов в рубли по курсу {RateUsdToRub} рублей за доллар");
                    Console.Write("Сколько долларов хотите обменять?: ");
                    double.TryParse(Console.ReadLine(), out double ammountCurrency);

                    if (ammountCurrency > usdBalance) {
                        Console.WriteLine("К сожалению на вашем балансе недостаточно средств.");
                    }
                    else {
                        usdBalance -= ammountCurrency;
                        rubBalance += ammountCurrency * RateUsdToRub;
                        Console.WriteLine($"\nУспешный обмен.\n");
                    }
                }
                else if (userInput == MenuConvertCnyToUsd) {
                    Console.WriteLine($"Конвертация юаней в доллары по курсу {RateCnyToUsd} долларов за юань");
                    Console.Write("Сколько юаней хотите обменять?: ");
                    double.TryParse(Console.ReadLine(), out double ammountCurrency);

                    if (ammountCurrency > usdBalance) {
                        Console.WriteLine("К сожалению на вашем балансе недостаточно средств.");
                    }
                    else {
                        cnyBalance -= ammountCurrency;
                        usdBalance += ammountCurrency * RateCnyToUsd;
                        Console.WriteLine($"\nУспешный обмен.\n");
                    }
                }
                else if (userInput == MenuConvertUsdToCny) {
                    Console.WriteLine($"Конвертация долларов в юани по курсу {RateUsdToCny} юаней за доллар");
                    Console.Write("Сколько долларов хотите обменять?: ");
                    double.TryParse(Console.ReadLine(), out double ammountCurrency);

                    if (ammountCurrency > usdBalance) {
                        Console.WriteLine("К сожалению на вашем балансе недостаточно средств.");
                    }
                    else {
                        usdBalance -= ammountCurrency;
                        cnyBalance += ammountCurrency * RateUsdToCny;
                        Console.WriteLine($"\nУспешный обмен.\n");
                    }
                }
            }
        }
    }
}
