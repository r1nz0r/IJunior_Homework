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

        enum MenuCommand
        {
            ShowAllPlayers = 1,
            AddPlayer,
            DeletePlayer,
            BanPlayer,
            UnbanPlayer,
            Exit,
            None
        }

        private static void Main ()
        {
            PlayersDataBase playersDataBase = new PlayersDataBase();

            MenuCommand menuCommand = MenuCommand.None;
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Вам доступны следующие операции с базой игроков:" +
                    $"\n{(int)MenuCommand.ShowAllPlayers} - Показать всех игроков." +
                    $"\n{(int)MenuCommand.AddPlayer} - Добавить игрока в базу." +
                    $"\n{(int)MenuCommand.DeletePlayer} - Удалить игрока из базы." +
                    $"\n{(int)MenuCommand.BanPlayer} - Забанить игрока по ID." +
                    $"\n{(int)MenuCommand.UnbanPlayer} - Разбанить игрока по ID." +
                    $"\n{(int)MenuCommand.Exit} - Выйти из программы.");

                menuCommand = (MenuCommand)GetIntFromUserInput("\nВведите номер команды меню: ");

                Console.Clear();

                switch (menuCommand)
                {
                    case MenuCommand.ShowAllPlayers:
                        playersDataBase.Show();
                        break;
                    case MenuCommand.AddPlayer:
                        playersDataBase.Add();
                        break;
                    case MenuCommand.DeletePlayer:
                        if (!playersDataBase.IsEmpty())
                            playersDataBase.Remove(GetIntFromUserInput("Введите ID игрока: "));
                        break;
                    case MenuCommand.BanPlayer:
                        if (!playersDataBase.IsEmpty())
                            playersDataBase.Ban(GetIntFromUserInput("Введите ID игрока: "));
                        break;
                    case MenuCommand.UnbanPlayer:
                        if (!playersDataBase.IsEmpty())
                            playersDataBase.Unban(GetIntFromUserInput("Введите ID игрока: "));
                        break;
                    case MenuCommand.Exit:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Неверная команда, повторите попытку снова.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private static int GetIntFromUserInput (string message)
        {
            Console.Write(message);
            int number;

            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Clear();
                Console.WriteLine("Ошибка ввода, повторите попытку.");
            }

            return number;
        }
    }

    class Player
    {
        private static int _ids;

        private string _name;
        private int _level;

        static Player () => _ids = 0;

        public Player (string name, int level)
        {
            Name = name;
            Id = ++_ids;
            Level = level;
            IsBanned = false;
        }

        public int Id { get; private set; }

        public bool IsBanned { get; set; }

        public string Name
        {
            get => _name;
            private set => _name = value ?? "DefaultName";
        }

        public int Level
        {
            get => _level;
            set => _level = value > 0 ? value : 0;
        }

        public void ShowInfo ()
        {
            string banStatus = IsBanned ? "забанен" : "блокировка отсутствует";
            Console.WriteLine($"Имя - {Name}, ID - {Id}, Уровень - {Level}, Статус блокировки - {banStatus}");
        }
    }

    class PlayersDataBase
    {
        private readonly List<Player> _players;

        public PlayersDataBase () => _players = new List<Player>();

        public PlayersDataBase (List<Player> players) => _players = players;

        private string GetUserInput (string message)
        {
            Console.Write(message);

            return Console.ReadLine();
        }

        private bool TryGetIndex (int id, out int index)
        {
            index = -1;

            for (int i = 0; i < _players.Count; ++i)
            {
                if (_players[i].Id == id)
                    index = i;
            }

            if (index < 0)
            {
                Console.WriteLine($"Игрока с ID = {id} не существует.");
                return false;
            }

            return true;
        }

        public bool IsEmpty ()
        {
            if (_players.Count == 0)
            {
                Console.WriteLine("База игроков пуста.");
                return true;
            }

            return false;
        }

        public void Remove (int id)
        {
            if (TryGetIndex(id, out int index))
            {
                _players.RemoveAt(index);
                Console.WriteLine($"Игрок с ID {id} успешно удален.");
            }
        }

        public void Ban (int id)
        {
            if (TryGetIndex(id, out int index))
            {
                _players[index].IsBanned = true;
                Console.WriteLine($"Игрок с ID {id} успешно забанен.");
            }
        }

        public void Unban (int id)
        {
            if (TryGetIndex(id, out int index))
            {
                _players[index].IsBanned = false;
                Console.WriteLine($"Игрок с ID {id} успешно разбанен.");
            }
        }

        public void Add ()
        {
            string name = GetUserInput("Введите имя игрока: ");
            int level;

            while (!int.TryParse(GetUserInput("Введите уровень игрока: "), out level))
            {
                Console.Clear();
                Console.WriteLine("Ошибка ввода, повторите попытку.");
            }

            _players.Add(new Player(name, level));
        }

        public void Show ()
        {
            if (_players.Count == 0)
                Console.WriteLine("База игроков пуста.");
            else
                foreach (var player in _players)
                    player.ShowInfo();
        }
    }
}
