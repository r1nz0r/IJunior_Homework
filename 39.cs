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

        enum Menu
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
            Database playersDataBase = new Database();

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
                        playersDataBase.Show();
                        break;
                    case Menu.AddPlayer:
                        playersDataBase.Add();
                        break;
                    case Menu.DeletePlayer:
                        if (!playersDataBase.IsEmpty())
                            playersDataBase.Remove(GetIntFromUserInput("Введите ID игрока: "));
                        break;
                    case Menu.BanPlayer:
                        if (!playersDataBase.IsEmpty())
                            playersDataBase.Ban(playersDataBase.TryGetPlayer(GetIntFromUserInput("Введите ID игрока: ")));
                        break;
                    case Menu.UnbanPlayer:
                        if (!playersDataBase.IsEmpty())
                            playersDataBase.Unban(playersDataBase.TryGetPlayer(GetIntFromUserInput("Введите ID игрока: ")));
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
        private static int s_ids;

        private string _name;
        private int _level;

        static Player () => s_ids = 0;

        public Player (string name, int level)
        {
            Name = name;
            Id = ++s_ids;
            Level = level;
        }

        public int Id { get; private set; }

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

        public void ShowInfo (Database database)
        {
            string banStatus = GetBanStatus(database) ? "забанен" : "блокировка отсутствует";
            Console.WriteLine($"Имя - {Name}, ID - {Id}, Уровень - {Level}, Статус блокировки - {banStatus}");
        }

        public bool GetBanStatus (Database database) => database.IsInBanList(this);

    }

    class Database
    {
        private readonly List<Player> _players;
        private readonly List<Player> _bannedPlayers;

        public Database ()
        {
            _players = new List<Player>();
            _bannedPlayers = new List<Player>();
        }

        public Database (List<Player> players) => _players = players;

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
            Player player = TryGetPlayer(id);

            if (player != null)
            {
                _players.Remove(player);
                Console.WriteLine($"Игрок с ID {id} успешно удален.");
            }
        }

        public void Ban (Player player)
        {
            if (player == null)
                return;

            if (_bannedPlayers.Contains(player) == false)
            {
                _bannedPlayers.Add(player);
                Console.WriteLine($"Игрок с ID {player.Id} успешно забанен.");
            }
            else
            {
                Console.WriteLine($"Игрок с ID {player.Id} уже находится в бан-листе.");
            }
        }

        public void Unban (Player player)
        {
            if (player == null)
                return;

            if (_bannedPlayers.Contains(player))
            {
                _bannedPlayers.Remove(player);
                Console.WriteLine($"Игрок с ID {player.Id} успешно разбанен.");
            }
            else
            {
                Console.WriteLine($"Игрок с ID {player.Id} не обнаружен в бан-листе.");
            }
        }

        public bool IsInBanList (Player player)
        {
            if (_bannedPlayers.Contains(player))
                return true;

            return false;
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
                    player.ShowInfo(this);
        }

        public Player TryGetPlayer (int id)
        {
            for (int i = 0; i < _players.Count; ++i)
            {
                if (_players[i].Id == id)
                    return _players[i];
            }

            Console.WriteLine($"Игрока с ID = {id} не существует.");
            return null;
        }

        private string GetUserInput (string message)
        {
            Console.Write(message);

            return Console.ReadLine();
        }

    }
}
