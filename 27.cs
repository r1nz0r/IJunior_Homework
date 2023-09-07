using System;

namespace IJunior
{
    internal class Program
    {
        // Будет 2 массива: 1) фио 2) должность.
        // Описать функцию заполнения массивов досье, функцию форматированного вывода, функцию поиска по фамилии и функцию удаления досье.
        // Программа должна быть с меню, которое содержит пункты:
        // 1) добавить досье (функция расширяет уже имеющийся массив на 1 и дописывает туда новое значение.)
        // 2) вывести все досье (в одну строку через “-” фио и должность с порядковым номером в начале)
        // 3) удалить досье (массивы уменьшаются на один элемент.Нужны дополнительные проверки, чтобы не возникало ошибок)
        // 4) поиск по фамилии
        // 5) выход

        private static void Main (string[] args)
        {
            string menuAddDossier = "1";
            string menuPrintDossier = "2";
            string menuDeleteDossier = "3";
            string menuFindDossier = "4";
            string menuExit = "5";

            string[] fullNames = new string[0];
            string[] jobTitles = new string[0];

            Console.WriteLine("Добро пожаловать в базу данных работников цеха №302!");
            string userInput = "";

            while (userInput != menuExit)
            {
                ShowMenu(menuAddDossier, menuPrintDossier, menuDeleteDossier, menuFindDossier, menuExit);
                userInput = Console.ReadLine();

                Console.WriteLine();

                if (userInput == menuAddDossier)
                    AddDossier(ref fullNames, ref jobTitles);
                else if (userInput == menuPrintDossier)
                    PrintDossier(fullNames, jobTitles);
                else if (userInput == menuDeleteDossier)
                    DeleteDossier(ref fullNames, ref jobTitles, GetSurname());
                else if (userInput == menuFindDossier)
                    FindDossier(fullNames, jobTitles, GetSurname());
                else if (userInput == menuExit)
                    Console.WriteLine("Вы вышли из программы, всего доброго!");
                else
                    Console.WriteLine("Неверная команда!");
            }
        }

        private static void ShowMenu (string menuAddDossier,
            string menuPrintDossier,
            string menuDeleteDossier,
            string menuFindDossier,
            string menuExit)
        {
            Console.Write("\nВам доступны следующие действия:" +
                                $"\n{menuAddDossier} - Добавить досье." +
                                $"\n{menuPrintDossier} - Вывести все имеющиеся досье." +
                                $"\n{menuDeleteDossier} - Удалить досье." +
                                $"\n{menuFindDossier} - Поиск по фамилии." +
                                $"\n{menuExit} - Выход." +
                                "\nВведите номер команды: ");
        }

        private static void PrintDossier (string[] fullNames, string[] jobTitles)
        {
            if (fullNames.Length == 0)
            {
                Console.WriteLine("База данных пуста.");
                return;
            }

            for (int i = 0; i < fullNames.Length; ++i)
                Console.WriteLine(fullNames[i] + " - " + jobTitles[i]);
        }

        private static string[] ResizeArray (string[] array, int newSize)
        {
            if (newSize == 0)
                return new string[0];

            var tempArray = new string[newSize];
            int minLength = array.Length <= tempArray.Length ? array.Length : tempArray.Length;

            for (int i = 0; i < minLength; ++i)
                tempArray[i] = array[i];

            array = tempArray;
            return array;
        }

        private static void AddDossier (ref string[] fullNames, ref string[] jobTitles)
        {
            fullNames = ResizeArray(fullNames, fullNames.Length + 1);
            jobTitles = ResizeArray(jobTitles, jobTitles.Length + 1);

            Console.Write("Введите ФИО нового сотрудника: ");
            string fullName = Console.ReadLine();

            fullNames[fullNames.Length - 1] = fullName;

            Console.Write("Введите должность нового сотрудника: ");
            string jobTitle = Console.ReadLine();

            jobTitles[jobTitles.Length - 1] = jobTitle;
            Console.WriteLine($"Сотрудник {fullName} с должностью {jobTitle} успешно внесен в базу.");
        }

        private static void DeleteDossier (ref string[] fullNames, ref string[] jobTitles, string surName)
        {
            if (fullNames.Length == 0)
            {
                Console.WriteLine("База данных уже пуста!");
                return;
            }

            int dossierIndex = FindDossier(fullNames, jobTitles, surName);

            if (dossierIndex < 0)
            {
                Console.WriteLine($"Не удалось удалить досье человека с фамилией {surName}.");
            }
            else
            {
                fullNames = RemoveFromArray(fullNames, dossierIndex);
                jobTitles = RemoveFromArray(jobTitles, dossierIndex);

                Console.WriteLine($"Досье с фамилией {surName} удалено.");
            }
        }

        private static string[] RemoveFromArray (string[] array, int index)
        {
            for (int i = index; i < array.Length - 1; ++i)
            {
                var temp = array[i];
                array[i] = array[i + 1];
                array[i + 1] = temp;
            }

            return ResizeArray(array, array.Length - 1);
        }

        private static int FindDossier (string[] fullNames, string[] jobTitles, string surName)
        {
            for (int i = 0; i < fullNames.Length; i++)
            {
                if (surName == fullNames[i].Split(' ')[0])
                {
                    Console.WriteLine($"Досье найдено: {fullNames[i]} - {jobTitles[i]}.");
                    return i;
                }
            }

            Console.WriteLine($"Досье с фамилией {surName} не найдено.");
            return -1;
        }

        private static string GetSurname ()
        {
            Console.Write("Введите фамилию сотрудника: ");
            return Console.ReadLine();
        }

    }
}
