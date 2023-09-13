using System;

namespace IJunior
{
    class Program
    {
        // Создать класс игрока, с полями, содержащими информацию об игроке и методом, который выводит информацию на экран.
        // В классе обязательно должен быть конструктор

        private static void Main ()
        {
            Player player1 = new Player("пупа", 5);
            player1.ShowInfo();

            Player player2 = new Player("лупа", 10);
            player2.ShowInfo();

            Console.ReadKey();
        }
    }

    class Player
    {
        private static int _ids;

        private string _name;
        private int _id;
        private int _health;

        static Player ()
        {
            _ids = 0;
        }

        public Player (string name, int health)
        {
            _name = name;
            _health = health;
            _id = ++_ids;
        }

        public void ShowInfo ()
        {
            Console.WriteLine($"Имя - {_name}, Здоровье - {_health}, ID - {_id}");
        }
    }
}
