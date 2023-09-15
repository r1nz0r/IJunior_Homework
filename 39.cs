using System;
using System.Collections.Generic;

namespace IJunior
{
    class Program
    {
        // Реализовать базу данных игроков и методы для работы с ней.
        // У игрока может быть уникальный номер, ник, уровень, флаг – забанен ли он(флаг - bool).
        // Реализовать возможность добавления игрока, бана игрока по уникальный номеру, разбана игрока по уникальный номеру и удаление игрока.
        // Создание самой БД не требуется, задание выполняется инструментами, которые вы уже изучили в рамках курса.
        // Но нужен класс, который содержит игроков и её можно назвать "База данных".

        private static void Main()
        {
            Database playersDatabase = new Database();
            playersDatabase.Work();
        }
    }

    class Player
    {
        private static int s_ids;

        private string _name;
        private int _level;
        private bool _isBanned;

        static Player() => s_ids = 0;

        public Player(string name, int level)
        {
            Name = name;
            Id = ++s_ids;
            Level = level;
        }

        public int Id { get; private set; }

        public string Name
        {
            get => _name;
            private set => _name = value == "" ? "DefaultName" : value;
        }

        public int Level
        {
            get => _level;
            set => _level = value > 0 ? value : 0;
        }

        public void Ban()
        {
            if (_isBanned == false)
            {
                _isBanned = true;
                Console.WriteLine($"Игрок с ID {Id} успешно забанен.");
            }
            else
            {
                Console.WriteLine($"Игрок с ID {Id} уже находится в бан-листе.");
            }
        }

        public void Unban()
        {
            if (_isBanned)
            {
                _isBanned = false;
                Console.WriteLine($"Игрок с ID {Id} успешно разбанен.");
            }
            else
            {
                Console.WriteLine($"Игрок с ID {Id} не находится в бан-листе.");
            }
        }

        public void ShowInfo()
        {
            string banStatus = _isBanned ? "забанен" : "блокировка отсутствует";
            Console.WriteLine($"Имя - {Name}, ID - {Id}, Уровень - {Level}, Статус блокировки - {banStatus}");
        }
    }

    class Database
    {
        public enum Menu
        {
            ShowAllPlayers = 1,
            AddPlayer,
            DeletePlayer,
            BanPlayer,
            UnbanPlayer,
            Exit,
            None
        }

        private readonly List<Player> _players;

        public Database()
        {
            _players = new List<Player>();
        }

        public Database(List<Player> players) => _players = players;

        public bool IsEmpty()
        {
            if (_players.Count == 0)
            {
                Console.WriteLine("База игроков пуста.");
                return true;
            }

            return false;
        }

        public void Work()
        {
            Menu menuCommand = Menu.None;
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Вам доступны следующие операции с базой игроков:" +
                    $"\n{(int)Menu.ShowAllPlayers} - Показать всех игроков." +
                    $"\n{(int)Menu.AddPlayer} - Добавить игрока в базу." +
                    $"\n{(int)Menu.DeletePlayer} - Удалить игрока из базы." +
                    $"\n{(int)Menu.BanPlayer} - Забанить игрока по ID." +
                    $"\n{(int)Menu.UnbanPlayer} - Разбанить игрока по ID." +
                    $"\n{(int)Menu.Exit} - Выйти из программы.");
                menuCommand = (Menu)GetIntFromUserInput("\nВведите номер команды меню: ");

                Console.Clear();

                switch (menuCommand)
                {
                    case Menu.ShowAllPlayers:
                        Show();
                        break;
                    case Menu.AddPlayer:
                        Add();
                        break;
                    case Menu.DeletePlayer:
                        Remove();
                        break;
                    case Menu.BanPlayer:
                        Ban();
                        break;
                    case Menu.UnbanPlayer:
                        Unban();
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

        private void Remove()
        {
            if (TryGetPlayer(out Player player))
            {
                _players.Remove(player);
                Console.WriteLine($"Игрок с ID {player.Id} успешно удален.");
            }
        }

        private void Add()
        {
            string name = GetUserInput("Введите имя игрока: ");
            int level;

            while (int.TryParse(GetUserInput("Введите уровень игрока: "), out level) == false)
            {
                Console.Clear();
                Console.WriteLine("Ошибка ввода, повторите попытку.");
            }

            _players.Add(new Player(name, level));
        }

        private void Show()
        {
            if (_players.Count == 0)
                Console.WriteLine("База игроков пуста.");
            else
                foreach (var player in _players)
                    player.ShowInfo();
        }

        private bool TryGetPlayer(out Player player)
        {
            player = null;

            if (IsEmpty())
                return false;

            int id = GetIdFromUserInput();

            for (int i = 0; i < _players.Count; ++i)
            {
                if (_players[i].Id == id)
                {
                    player = _players[i];
                    return true;
                }
            }

            Console.WriteLine($"Игрока с ID = {id} не существует.");

            return false;
        }

        private int GetIdFromUserInput()
        {
            Console.Write("Введите ID игрока: ");
            int number;

            while (int.TryParse(Console.ReadLine(), out number) == false)
            {
                Console.Clear();
                Console.WriteLine("Ошибка ввода, повторите попытку.");
            }

            return number;
        }

        private string GetUserInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        private int GetIntFromUserInput(string message)
        {
            Console.Write(message);
            int number;

            while (int.TryParse(Console.ReadLine(), out number) == false)
            {
                Console.Clear();
                Console.WriteLine("Ошибка ввода, повторите попытку.");
            }

            return number;
        }

        private void Ban()
        {
            if (TryGetPlayer(out Player player))
                player.Ban();
        }

        private void Unban()
        {
            if (TryGetPlayer(out Player player))
                player.Unban();
        }
    }
}
