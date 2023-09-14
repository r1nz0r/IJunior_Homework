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
            double percentFactor = 100.0;
            return Convert.ToInt32((double)value / maxValue * percentFactor);
        }

        private static int GetValueFromPercent(int percent, int maxValue)
        {
            double valueFactor = 0.01;
            return Convert.ToInt32(maxValue * valueFactor * percent);
        }

        private static void DrawBar(int percent, ConsoleColor color, int positionX, int positionY, char symbol)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;

            int maxValue = 10;
            int value = GetValueFromPercent(percent, maxValue);

            var barBuilder = new StringBuilder();
            int firstIndex = 0;

            FillBar(symbol, firstIndex, value, barBuilder);

            string bar = barBuilder.ToString();

            Console.SetCursorPosition(positionX, positionY);
            Console.Write('[');
            Console.BackgroundColor = color;
            Console.Write(bar);
            Console.BackgroundColor = defaultColor;

            barBuilder.Clear();

            FillBar(symbol, value, maxValue, barBuilder);

            bar = barBuilder.ToString();
            Console.Write(bar + ']');
        }

        private static void FillBar(char symbol, int minIndex, int maxIndex, StringBuilder barBuilder)
        {
            for (int i = minIndex; i < maxIndex; i++)
            {
                barBuilder.Append(symbol);
            }
        }
    }
}
