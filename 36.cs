using System;
using System.Collections.Generic;

namespace IJunior
{
    internal class Program
    {
        // В функциях вы выполняли задание "Кадровый учёт".
        // Используя одну из изученных коллекций, вы смогли бы сильно себе упростить код выполненной программы,
        // ведь у нас данные, это ФИО и позиция.
        // Поиск в данном задании не нужен.
        // 1) добавить досье
        // 2) вывести все досье (в одну строку через “-” фио и должность)
        // 3) удалить досье
        // 4) выход

        private static void Main (string[] args)
        {
            string menuAddDossier = "1";
            string menuPrintDossier = "2";
            string menuDeleteDossier = "3";
            string menuExit = "4";

            Dictionary<string, string> dossiers = new Dictionary<string, string>();

            Console.WriteLine("Добро пожаловать в базу данных работников цеха №302!");
            string userInput = "";

            while (userInput != menuExit)
            {
                userInput = GetUserInput(("\nВам доступны следующие действия:" +
                                $"\n{menuAddDossier} - Добавить досье." +
                                $"\n{menuPrintDossier} - Вывести все имеющиеся досье." +
                                $"\n{menuDeleteDossier} - Удалить досье." +
                                $"\n{menuExit} - Выход." +
                                "\nВведите номер команды: "));

                Console.Clear();

                if (userInput == menuAddDossier)
                    AddDossier(dossiers);
                else if (userInput == menuPrintDossier)
                    PrintDossiers(dossiers);
                else if (userInput == menuDeleteDossier)
                    DeleteDossier(dossiers);
                else if (userInput == menuExit)
                    Console.WriteLine("Вы вышли из программы, всего доброго!");
                else
                    Console.WriteLine("Неверная команда!");
            }
        }

        private static void PrintDossiers (Dictionary<string, string> dossiers)
        {
            if (IsDossiersBaseEmpty(dossiers))
                return;

            int id = 1;

            foreach (var dossier in dossiers)
                Console.WriteLine($"{id++}) {dossier.Key} - {dossier.Value}");
        }

        private static void AddDossier (Dictionary<string, string> dossiers)
        {
            string fullName = GetUserInput("Введите ФИО нового сотрудника: ");

            if (dossiers.ContainsKey(fullName))
            {
                Console.WriteLine("Сотрудник с такими ФИО уже есть в базе!");
                return;
            }

            string jobTitle = GetUserInput("Введите должность нового сотрудника: ");

            dossiers.Add(fullName, jobTitle);
            Console.WriteLine($"Сотрудник {fullName} с должностью {jobTitle} успешно внесен в базу.");
        }

        private static string GetUserInput (string message)
        {
            Console.Write(message);
            string userInput = Console.ReadLine();

            return userInput;
        }

        private static void DeleteDossier (Dictionary<string, string> dossiers)
        {
            if (IsDossiersBaseEmpty(dossiers))
                return;

            PrintDossiers(dossiers);
            Console.WriteLine();

            string fullName = GetUserInput("Укажите полное ФИО досье, которое нужно удалить (с учетом капитализации слов): ");

            if (!dossiers.ContainsKey(fullName))
            {
                Console.WriteLine("Досье с такими ФИО не найдено! Проверьте корректность ввода.");
                return;
            }
            else
            {
                dossiers.Remove(fullName);
                Console.WriteLine($"Досье {fullName} успешно удалено.");
            }
        }

        private static bool IsDossiersBaseEmpty (Dictionary<string, string> dossiers)
        {
            if (dossiers.Count == 0)
            {
                Console.WriteLine("База данных пуста.");
                return true;
            }

            return false;
        }
    }
}
