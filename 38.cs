using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IJunior
{
    class Program
    {
        // Создать класс игрока, у которого есть поля с его положением в x,y.
        // Создать класс отрисовщик, с методом, который отрисует игрока.
        // Попрактиковаться в работе со свойствами.

        private static void Main ()
        {
            Player[] players = new Player[] { new Player(5, 15, '@'), new Player(10, 10, '#'), new Player(-5, 10, 'p') };

            Renderer renderer = new Renderer(players);
            renderer.Print();

            Console.ReadKey();
        }
    }

    class Player
    {
        public Player (int positionX, int positionY, char symbol)
        {
            PositionX = positionX;
            PositionY = positionY;
            Symbol = symbol;
        }

        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public char Symbol { get; private set; }
    }

    class Renderer
    {
        private List<Player> _players = new List<Player>();

        public Renderer (Player[] players) => _players.AddRange(players);

        public void Print ()
        {
            foreach (var player in _players)
            {
                if (player.PositionY < 0 || player.PositionX < 0)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine($"Невозможно отобразить игрока \'{player.Symbol}\', так как у него отрицательные координаты.");
                    return;
                }

                Console.SetCursorPosition(player.PositionX, player.PositionY);
                Console.WriteLine(player.Symbol);
            }
        }
    }
}
