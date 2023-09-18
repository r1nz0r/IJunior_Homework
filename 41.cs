using System;
using System.Collections.Generic;

namespace IJunior
{
    // Создать хранилище книг.
    // Каждая книга имеет название, автора и год выпуска (можно добавить еще параметры).
    // В хранилище можно добавить книгу, убрать книгу, показать все книги и показать книги по указанному параметру (по названию, по автору, по году выпуска).
    // Про указанный параметр, к примеру нужен конкретный автор, выбирается показ по авторам, запрашивается у пользователя автор и показываются все книги с этим автором.

    class Program
    {        
        private static void Main()
        {
            Library library = new Library();
            library.Work();
        }
    }

    class Book
    {
        public enum Parameter
        {
            Author,
            Title,
            ReleaseYear,
            TotalPages,
            None
        }

        public Book(string author, string title, int releaseYear, int totalPages)
        {
            Author = author;
            Title = title;
            ReleaseYear = releaseYear;
            TotalPages = totalPages;
        }

        public string Author { get; private set; }
        public string Title { get; private set; }
        public int ReleaseYear { get; private set; }
        public int TotalPages { get; private set; }

        public void PrintInfo()
        {
            Console.Write($"Автор - {Author}, Название - {Title}, Дата выхода - {ReleaseYear}, Всего страниц - {TotalPages}");
        }
    }

    class Library
    {
        private enum Menu
        {
            Add = 1,
            Delete,
            ShowAll,
            ShowByAttribute,
            Exit,
            None
        }

        private readonly List<Book> _books;

        public Library()
        {
            _books = new List<Book>();
        }

        public void Work()
        {
            Menu menuCommand;
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Вам доступны следующие операции с библиотекой:\n" +
                    $"\n{(int)Menu.Add} - Добавить книгу в библиотеку." +
                    $"\n{(int)Menu.Delete} - Удалить книгу из библиотеки." +
                    $"\n{(int)Menu.ShowAll} - Показать все имеющиеся книги." +
                    $"\n{(int)Menu.ShowByAttribute} - Найти книги по указанному параметру." +
                    $"\n{(int)Menu.Exit} - Выйти из программы.");
                menuCommand = (Menu)GetIntFromUserInput("\nВведите номер команды меню: ");

                Console.Clear();

                switch (menuCommand)
                {
                    case Menu.Add:
                        Add();
                        break;
                    case Menu.Delete:
                        Delete();
                        break;
                    case Menu.ShowAll:
                        Show();
                        break;
                    case Menu.ShowByAttribute:
                        ShowByAttribute();
                        break;
                    case Menu.Exit:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Неверная команда, повторите попытку снова.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private void Add()
        {
            string author = GetUserInput("Укажите ФИО автора: ");
            string title = GetUserInput("Укажите название книги: ");
            int releaseYear = GetIntFromUserInput("Укажите год выпуска книги: ");
            int totalPages = GetIntFromUserInput("Укажите количество страниц: ");

            _books.Add(new Book(author, title, releaseYear, totalPages));
        }

        private void Delete()
        {
            if (IsEmpty())
                return;

            Show();

            int indexToDelete = GetIntFromUserInput("Введите номер книги, которую хотите убрать с полки: ") - 1;

            if (indexToDelete < 0 || indexToDelete >= _books.Count)
            {
                Console.WriteLine("Вы ввели некорректный номер книги. Операция отменена.");
            }
            else
            {
                _books.RemoveAt(indexToDelete);
                Console.WriteLine("Книга успешно удалена.");
            }
        }

        private string GetUserInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        private int GetIntFromUserInput(string message)
        {
            int number;

            while ((int.TryParse(GetUserInput(message), out number)) == false)
            {
                Console.Clear();
                Console.WriteLine("Ошибка ввода, повторите попытку.");
            }

            return number;
        }

        private void Show()
        {
            if (IsEmpty())
            {
                return;
            }
            else
            {
                for (int i = 0; i < _books.Count; ++i)
                {
                    Console.Write($"{i + 1}) ");
                    _books[i].PrintInfo();
                }
            }
        }

        private Book.Parameter GetBookParameter()
        {
            Book.Parameter bookParameter;

            Console.WriteLine("Выберите один из параметров:" +
                $"\n{(int)Book.Parameter.Author} - Поиск по автору." +
                $"\n{(int)Book.Parameter.Title} - Поиск по названию." +
                $"\n{(int)Book.Parameter.ReleaseYear} - Поиск по дате выхода.");

            bookParameter = (Book.Parameter)GetIntFromUserInput("\nУкажите способ поиска (номер): ");
            Console.Clear();

            return bookParameter;
        }

        private bool IsEmpty()
        {
            if (_books.Count == 0)
            {
                Console.WriteLine("Библиотека пуста.");
                return true;
            }

            return false;
        }

        private void ShowByAttribute()
        {
            if (IsEmpty())
                return;

            Book.Parameter parameter = GetBookParameter();

            string message;

            switch (parameter)
            {
                case Book.Parameter.Author:
                    message = "Укажите автора книг: ";
                    break;
                case Book.Parameter.Title:
                    message = "Введите название книги: ";
                    break;
                case Book.Parameter.ReleaseYear:
                    message = "Введите год выпуска книги: ";
                    break;
                default:
                    Console.WriteLine("Неверный параметр.");
                    return;
            }

            string userInput = GetUserInput(message);
            bool isBookFound = false;

            foreach (var book in _books)
            {
                string bookAttribute;

                switch (parameter)
                {
                    case Book.Parameter.Author:
                        bookAttribute = book.Author;
                        break;
                    case Book.Parameter.Title:
                        bookAttribute = book.Title;
                        break;
                    case Book.Parameter.ReleaseYear:
                        bookAttribute = book.ReleaseYear.ToString();
                        break;
                    default:
                        Console.WriteLine("Неверный параметр.");
                        return;
                }

                if (bookAttribute.ToLower() == userInput.ToLower())
                {
                    isBookFound = true;
                    book.PrintInfo();
                }
            }

            if (isBookFound == false)
                Console.WriteLine("Таких книг в библиотеке нет.");
        }
    }
}
