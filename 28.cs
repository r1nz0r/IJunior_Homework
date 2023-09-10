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
            int mana = 5;
            int maxMana = 20;
            int manaBarPoistionX = 0;
            int manaBarPositionY = 0;
            int rage = 40;
            int maxRage = 50;
            int rageBarPoistionX = 0;
            int rageBarPositionY = 1;        

            int manaPercent = GetPercentFromValue(mana, maxMana);
            int ragePercent = GetPercentFromValue(rage, maxRage);

            char symbolForBar = '_';

            DrawBar(manaPercent, ConsoleColor.Blue, manaBarPoistionX, manaBarPositionY, symbolForBar);
            DrawBar(ragePercent, ConsoleColor.Red, rageBarPoistionX, rageBarPositionY, symbolForBar);
            Console.ReadKey();
        }

        private static int GetPercentFromValue(int value, int maxValue)
        {
            double percentFactor = 100;          
            return Convert.ToInt32((double)value / maxValue * percentFactor);
        }

        private static void DrawBar(int percent, ConsoleColor color, int positionX, int positionY, char symbol)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            int value = percent / 10;
            int maxValue = 10;

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
