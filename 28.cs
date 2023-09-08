using System;
using System.Text;

namespace IJunior
{
    internal class Program
    {
        // Разработайте функцию, которая рисует некий бар (Healthbar, Manabar) в определённой позиции.
        // Она также принимает некий закрашенный процент.

        private static void Main(string[] args)
        {
            int manaPercent = 40, maxMana = 20;
            int manaBarPoistionX = 0, manaBarPositionY = 0;
            int ragePercent = 80, maxRage = 50;
            int rageBarPoistionX = 0, rageBarPositionY = 1;

            char symbolForBar = '_';

            DrawBar(manaPercent, maxMana, ConsoleColor.Blue, manaBarPoistionX, manaBarPositionY, symbolForBar);
            DrawBar(ragePercent, maxRage, ConsoleColor.Red, rageBarPoistionX, rageBarPositionY, symbolForBar);
            Console.ReadKey();
        }

        static void DrawBar(int percent, int maxValue, ConsoleColor color, int positionX, int positionY, char symbol)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;

            int percentFactor = 100;
            int value = maxValue * percent / percentFactor;

            var barBuilder = new StringBuilder();

            for (int i = 0; i < value; i++)
            {
                barBuilder.Append(symbol);
            }

            string bar = barBuilder.ToString();

            Console.SetCursorPosition(positionX, positionY);
            Console.Write('[');
            Console.BackgroundColor = color;
            Console.Write(bar);
            Console.BackgroundColor = defaultColor;

            barBuilder.Clear();

            for (int i = value; i < maxValue; i++)
                barBuilder.Append(symbol);

            bar = barBuilder.ToString();
            Console.Write(bar + ']');
        }
    }
}
