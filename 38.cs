using System;
using System.Collections.Generic;

namespace IJunior
{
    class Program
    {
        // Создать класс игрока, у которого есть поля с его положением в x,y.
        // Создать класс отрисовщик, с методом, который отрисует игрока.
        // Попрактиковаться в работе со свойствами.

        private static void Main ()
        {
            List<Player> players = new List<Player>();
            players.Add(new Player(5, 15, '@'));
            players.Add(new Player(10, 10, '#'));
            players.Add(new Player(-5, 10, 'p'));

            Renderer renderer = new Renderer();
            renderer.Print(players);

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
        public void Print (List<Player> players)
        {
            foreach (var player in players)
            {
                if (player.PositionY < 0 || player.PositionX < 0)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine($"Невозможно отобразить игрока \'{player.Symbol}\', так как у него отрицательные координаты.");
                }
                else
                {
                    Console.SetCursorPosition(player.PositionX, player.PositionY);
                    Console.WriteLine(player.Symbol);
                }                
            }
        }
    }
}
