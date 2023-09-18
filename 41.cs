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
        private static void Main ()
        {

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

        public Book (string author, string title, int releaseYear, int totalPages)
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

        public void PrintInfo ()
        {
            Console.Write($"");
        }        
    }

    class Library
    {
        private List<Book> _books;

        public Library ()
        {
            _books = new List<Book>();
        }

        public void Show ()
        {
            if (_books.Count == 0)
            {
                Console.WriteLine("Библиотека пуста.");
            }
            else
            {
                for (int i = 0; i < _books.Count; ++i)
                {
                    Console.WriteLine($"{i + 1}) Автор - {_books[i].Author}, Название - {_books[i].Title}," +
                        $" Дата выхода - {_books[i].ReleaseYear}, Всего страниц - {_books[i].TotalPages}");
                }
            }
        }

        public void Add ()
        {            
            string author = GetUserInput("Укажите ФИО автора: ");
            string title = GetUserInput("Укажите название книги: ");
            int releaseYear = GetIntFromUserInput("Укажите год выпуска книги: ");
            int totalPages = GetIntFromUserInput("Укажите количество страниц: ");

            _books.Add(new Book(author, title, releaseYear, totalPages));
        }       
                 
        public void Delete ()
        {
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

        private string GetUserInput (string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        private int GetIntFromUserInput (string message)
        {
            int number;

            while ((int.TryParse(GetUserInput(message), out number)) == false)
            {
                Console.Clear();
                Console.WriteLine("Ошибка ввода, повторите попытку.");
            }

            return number;
        }

        public void Show(Book.Parameter parameter)
        {
            if (parameter == Book.Parameter.Author)
            {
                string author = GetUserInput("Введите ФИО автора: ");

                bool hasAuthor = false;

                foreach(var book in _books)
                {
                    if (book.Author.Equals(author))
                    {
                        hasAuthor = true;
                        Console.WriteLine();
                    }
                }

                if (hasAuthor == false)
                {

                }
            }
        }
    }
}
