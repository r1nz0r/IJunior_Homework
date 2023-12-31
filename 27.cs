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

                Console.Clear();

                if (userInput == menuAddDossier)
                    AddDossier(ref fullNames, ref jobTitles);
                else if (userInput == menuPrintDossier)
                    PrintDossiers(fullNames, jobTitles);
                else if (userInput == menuDeleteDossier)
                    DeleteDossier(ref fullNames, ref jobTitles);
                else if (userInput == menuFindDossier)
                    FindDossiers(fullNames, jobTitles);
                else if (userInput == menuExit)
                    Console.WriteLine("Вы вышли из программы, всего доброго!");
                else
                    Console.WriteLine("Неверная команда!");
            }
        }

        private static void PrintDossiers(string[] fullNames, string[] jobTitles)
        {
            if (IsDataBaseEmpty(fullNames))
                return;

            for (int i = 0; i < fullNames.Length; ++i)
                Console.WriteLine($"{i + 1})  {fullNames[i]} - {jobTitles[i]}");
        }

        private static void AddElementToArray(ref string[] array, string newElement)
        {
            var tempArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; ++i)
                tempArray[i] = array[i];

            tempArray[tempArray.Length - 1] = newElement;
            array = tempArray;
        }

        private static void AddDossier(ref string[] fullNames, ref string[] jobTitles)
        {
            Console.Write("Введите ФИО нового сотрудника: ");
            string fullName = Console.ReadLine();

            AddElementToArray(ref fullNames, fullName);

            Console.Write("Введите должность нового сотрудника: ");
            string jobTitle = Console.ReadLine();

            AddElementToArray(ref jobTitles, jobTitle);

            Console.WriteLine($"Сотрудник {fullName} с должностью {jobTitle} успешно внесен в базу.");
        }

        private static void DeleteDossier(ref string[] fullNames, ref string[] jobTitles)
        {
            if (IsDataBaseEmpty(fullNames))
                return;

            PrintDossiers(fullNames, jobTitles);
            Console.WriteLine();

            Console.Write("Укажите номер досье, который нужно удалить: ");
            if (int.TryParse(Console.ReadLine(), out int dossierIndex) == false)
            {
                Console.WriteLine("Некорректный ввод!");
                return;
            }

            dossierIndex--;
            int lastDossierIndex = fullNames.Length - 1;

            if (dossierIndex <= lastDossierIndex && dossierIndex >= 0)
            {
                RemoveFromArray(ref fullNames, dossierIndex);
                RemoveFromArray(ref jobTitles, dossierIndex);
                Console.WriteLine($"Досье успешно удалено.");
            }
            else
            {
                Console.WriteLine("Досье с таким индексом не существует.");
            }
        }

        private static void RemoveFromArray(ref string[] array, int index)
        {
            for (int i = index; i < array.Length - 1; ++i)
            {
                string temp = array[i];
                array[i] = array[i + 1];
                array[i + 1] = temp;
            }

            int newLength = array.Length - 1;
            newLength = newLength > 0 ? newLength : 0;
            var tempArray = new string[newLength];

            for (int i = 0; i < tempArray.Length; ++i)
                tempArray[i] = array[i];

            array = tempArray;
        }

        private static void FindDossiers(string[] fullNames, string[] jobTitles)
        {
            if (IsDataBaseEmpty(fullNames))
                return;

            bool isFound = false;
            char separator = ' ';

            Console.Write("Введите фамилию сотрудника: ");
            string surName = Console.ReadLine();

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
        }

        private static bool IsDataBaseEmpty(string[] fullnames)
        {
            if (fullnames.Length == 0)
            {
                Console.WriteLine("База данных пуста.");
                return true;
            }

            return false;
        }
    }
}
