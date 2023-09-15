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

        private static void Main(string[] args)
        {
            string menuAddDossier = "1";
            string menuPrintDossier = "2";
            string menuDeleteDossier = "3";
            string menuExit = "4";

            List<string> fullNames = new List<string>();
            List<string> dossiers = new List<string>();

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
                    AddDossier(fullNames, dossiers);
                else if (userInput == menuPrintDossier)
                    PrintDossiers(fullNames, dossiers);
                else if (userInput == menuDeleteDossier)
                    DeleteDossier(fullNames, dossiers);
                else if (userInput == menuExit)
                    Console.WriteLine("Вы вышли из программы, всего доброго!");
                else
                    Console.WriteLine("Неверная команда!");
            }
        }

        private static void PrintDossiers(List<string> fullNames, List<string> dossiers)
        {
            if (IsDossiersBaseEmpty(dossiers))
                return;

            for (int i = 0; i < dossiers.Count; ++i)
            {
                Console.WriteLine($"{i + 1}) {fullNames[i]} - {dossiers[i]}");
            }
        }

        private static void AddDossier(List<string> fullNames, List<string> dossiers)
        {
            string fullName = GetUserInput("Введите ФИО нового сотрудника: ");
            string jobTitle = GetUserInput("Введите должность нового сотрудника: ");

            fullNames.Add(fullName);
            dossiers.Add(jobTitle);
            Console.WriteLine($"Сотрудник {fullName} с должностью {jobTitle} успешно внесен в базу.");
        }

        private static string GetUserInput(string message)
        {
            Console.Write(message);
            string userInput = Console.ReadLine();

            return userInput;
        }

        private static void DeleteDossier(List<string> fullNames, List<string> dossiers)
        {
            if (IsDossiersBaseEmpty(dossiers))
                return;

            PrintDossiers(fullNames, dossiers);
            Console.WriteLine();

            int index;

            while (int.TryParse(GetUserInput("Введите номер досье: "), out index) == false)
            {
                Console.WriteLine();
            }

            --index;

            if (index < 0 || index >= fullNames.Count)
            {
                Console.WriteLine("Неверный индекс досье.");
                return;
            }

            fullNames.RemoveAt(index);
            dossiers.RemoveAt(index);

            Console.WriteLine($"Досье успешно удалено.");
        }

        private static bool IsDossiersBaseEmpty(List<string> dossiers)
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
