using System;

namespace IJunior {
    internal class Program {
        public enum Currency {
            RUB,
            CNY,
            USD,
            None
        }
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

            string userInput = "";

            while (true) {
                Console.Write("Выберите операцию:" +
                    "\n1 - Рубли в юани" +
                    "\n2 - Юани в рубли" +
                    "\n3 - Рубли в доллары" +
                    "\n4 - Доллары в рубли" +
                    "\n5 - Юани в доллары" +
                    "\n6 - Доллары в юани" +
                    "\nexit - Выход");
                userInput = Console.ReadLine().ToLower();

                if (userInput == "exit") {
                    break;
                }
                else if (userInput == "1") {
                    Console.WriteLine($"Конвертация рублей в юани по курсу {RubToCny} юаней за рубль");
                    Console.Write("Сколько хотите обменять?: ");
                    int.TryParse(Console.ReadLine(), out int ammountCurrency);

                    Console.WriteLine($"Успешный обмен. Теперь у вас {rubBalance} рублей и {cnyBalance} юаней.");
                }
            }
        }
    }
}
