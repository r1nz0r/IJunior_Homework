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

        private static void Main(string[] args)
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
                Console.Write("\nВам доступны следующие действия:" +
                                $"\n{menuAddDossier} - Добавить досье." +
                                $"\n{menuPrintDossier} - Вывести все имеющиеся досье." +
                                $"\n{menuDeleteDossier} - Удалить досье." +
                                $"\n{menuFindDossier} - Поиск по фамилии." +
                                $"\n{menuExit} - Выход." +
                                "\nВведите номер команды: ");
                userInput = Console.ReadLine();

                Console.WriteLine();

                if (userInput == menuAddDossier)
                    AddDossier(ref fullNames, ref jobTitles);
                else if (userInput == menuPrintDossier)
                    PrintDossiers(fullNames, jobTitles);
                else if (userInput == menuDeleteDossier)
                    DeleteDossiers(ref fullNames, ref jobTitles, GetSurname());
                else if (userInput == menuFindDossier)
                    CanFindDossiers(fullNames, jobTitles, GetSurname());
                else if (userInput == menuExit)
                    Console.WriteLine("Вы вышли из программы, всего доброго!");
                else
                    Console.WriteLine("Неверная команда!");
            }
        }

        private static void PrintDossiers(string[] fullNames, string[] jobTitles)
        {
            if (fullNames.Length == 0)
            {
                Console.WriteLine("База данных пуста.");
                return;
            }

            for (int i = 0; i < fullNames.Length; ++i)
                Console.WriteLine($"{i + 1})  {fullNames[i]} - {jobTitles[i]}");
        }

        private static string[] ResizeArray(string[] array, int sizeChangeValue = 1)
        {
            int newSize = array.Length + sizeChangeValue;
            newSize = newSize > 0 ? newSize : 0;
            var tempArray = new string[newSize];
            int minLength = array.Length <= tempArray.Length ? array.Length : tempArray.Length;

            for (int i = 0; i < minLength; ++i)
                tempArray[i] = array[i];

            return tempArray;
        }

        private static void AddDossier(ref string[] fullNames, ref string[] jobTitles)
        {
            fullNames = ResizeArray(fullNames, 1);
            jobTitles = ResizeArray(jobTitles, 1);

            Console.Write("Введите ФИО нового сотрудника: ");
            string fullName = Console.ReadLine();

            fullNames[fullNames.Length - 1] = fullName;

            Console.Write("Введите должность нового сотрудника: ");
            string jobTitle = Console.ReadLine();

            jobTitles[jobTitles.Length - 1] = jobTitle;
            Console.WriteLine($"Сотрудник {fullName} с должностью {jobTitle} успешно внесен в базу.");
        }

        private static void DeleteDossiers(ref string[] fullNames, ref string[] jobTitles, string surName)
        {
            if (fullNames.Length == 0)
            {
                Console.WriteLine("База данных уже пуста!");
                return;
            }

            bool isDossierFound = CanFindDossiers(fullNames, jobTitles, surName);

            if (isDossierFound == false)
            {
                Console.WriteLine($"Не удалось удалить досье человека с фамилией {surName}.");
            }
            else
            {
                string commandDeleteAll = "all";
                Console.WriteLine($"Выберие номер досье, которое хотите удалить, или введите 'all'," +
                    $" чтобы удалить все досье с фамилией {surName}: ");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == commandDeleteAll)
                    DeleteEverySurnameDossier(ref fullNames, ref jobTitles, surName);
                else
                    DeleteDossier(ref fullNames, ref jobTitles, surName, userInput);
            }
        }

        private static void DeleteDossier(ref string[] fullNames, ref string[] jobTitles, string surName, string userInput)
        {
            if (int.TryParse(userInput, out int dossierIndex) == false)
            {
                Console.WriteLine("Некорректный ввод!");
                return;
            }

            dossierIndex--;
            int lastDossierIndex = fullNames.Length - 1;

            if (dossierIndex <= lastDossierIndex && dossierIndex >= 0)
            {
                if (fullNames[dossierIndex].Contains(surName))
                {
                    fullNames = RemoveFromArray(fullNames, dossierIndex);
                    jobTitles = RemoveFromArray(jobTitles, dossierIndex);
                    Console.WriteLine($"Досье {dossierIndex}) с фамилией {surName} удалено.");
                }
                else
                {
                    Console.WriteLine($"Введенный вами номер не соответствует досье с фамилией {surName}");
                }
            }
            else
            {
                Console.WriteLine("Досье с таким индексом не существует.");
            }
        }

        private static void DeleteEverySurnameDossier(ref string[] fullNames, ref string[] jobTitles, string surName)
        {
            int dossierIndex = GetDossierIndex(fullNames, surName);

            while (dossierIndex >= 0)
            {
                fullNames = RemoveFromArray(fullNames, dossierIndex);
                jobTitles = RemoveFromArray(jobTitles, dossierIndex);
                Console.WriteLine($"Досье {dossierIndex + 1}) с фамилией {surName} удалено.");

                dossierIndex = GetDossierIndex(fullNames, surName);
            }
        }

        private static string[] RemoveFromArray(string[] array, int index)
        {
            for (int i = index; i < array.Length - 1; ++i)
            {
                string temp = array[i];
                array[i] = array[i + 1];
                array[i + 1] = temp;
            }

            return ResizeArray(array, -1);
        }

        private static bool CanFindDossiers(string[] fullNames, string[] jobTitles, string surName)
        {
            bool isFound = false;
            char separator = ' ';

            for (int i = 0; i < fullNames.Length; i++)
            {
                if (surName == fullNames[i].Split(separator)[0])
                {
                    Console.WriteLine($"Досье найдено: {i + 1}) {fullNames[i]} - {jobTitles[i]}.");
                    isFound = true;
                }
            }

            if (isFound == false)
                Console.WriteLine($"Досье с фамилией {surName} не найдено.");

            return isFound;
        }

        private static int GetDossierIndex(string[] fullNames, string surName)
        {
            char separator = ' ';

            for (int i = 0; i < fullNames.Length; i++)
            {
                if (surName == fullNames[i].Split(separator)[0])
                {
                    return i;                   
                }
            }

            return -1;
        }

        private static string GetSurname()
        {
            Console.Write("Введите фамилию сотрудника: ");
            return Console.ReadLine();
        }
    }
}
