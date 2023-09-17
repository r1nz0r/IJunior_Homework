using System;
using System.IO;
namespace IJunior
{
    internal class Program
    {
        // Сделать игровую карту с помощью двумерного массива. Сделать функцию рисования карты.
        // Помимо этого, дать пользователю возможность перемещаться по карте и взаимодействовать с элементами (например пользователь не может пройти сквозь стену).
        // Все элементы являются обычными символами.

        static void Main (string[] args)
        {
            char playerSymbol = '@';
            char emptySymbol = ' ';
            char borderSymbol = '#';
            string mapFileName = @"E:\WORK\CS\Learn\map.txt";

            int playerMoveX = 1;
            int playerMoveY = 1;

            char[,] map = ReadMap(mapFileName, playerSymbol, out int playerPositionX, out int playerPositionY);
            map[playerPositionX, playerPositionY] = '@';

            Console.CursorVisible = false;
            ConsoleKey[] moveButtons = { ConsoleKey.W, ConsoleKey.A, ConsoleKey.S, ConsoleKey.D };

            int mapLeftCornerOffset = 0;
            int mapTopCornerOffset = 2;

            bool isPlaying = true;

            while (isPlaying)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"Используйте клавиши {string.Join(" ", moveButtons)} для перемещения," +
                    $" клавишу {ConsoleKey.Escape} для выхода из игры.");
                Console.SetCursorPosition(mapLeftCornerOffset, mapTopCornerOffset);
                PrintMap(map);

                HandleInput(ref playerMoveX, ref playerMoveY, ref isPlaying);
                Move(map, playerSymbol, emptySymbol, borderSymbol, ref playerPositionX, ref playerPositionY, playerMoveX, playerMoveY);
            }
        }

        private static void Move (char[,] map, char playerSymbol, char emptySymbol, char borderSymbol,
            ref int playerPositionX, ref int playerPositionY, int playerMoveX, int playerMoveY)
        {
            if (map[playerPositionX + playerMoveX, playerPositionY + playerMoveY] != borderSymbol)
            {
                map[playerPositionX, playerPositionY] = emptySymbol;

                playerPositionX += playerMoveX;
                playerPositionY += playerMoveY;

                map[playerPositionX, playerPositionY] = playerSymbol;
            }
        }

        private static void HandleInput (ref int playerMoveX, ref int playerMoveY, ref bool isPlaying)
        {
            ConsoleKey pressedKey = Console.ReadKey(true).Key;

            playerMoveX = 0;
            playerMoveY = 0;
            
            switch (pressedKey)
            {
                case ConsoleKey.W:
                    playerMoveY = -1;
                    break;
                case ConsoleKey.S:
                    playerMoveY = 1;
                    break;
                case ConsoleKey.A:
                    playerMoveX = -1;
                    break;
                case ConsoleKey.D:
                    playerMoveX = 1;
                    break;
                case ConsoleKey.Escape:
                    isPlaying = false;
                    break;
            }
        }

        private static char[,] ReadMap (string fileName, char playerSymbol, out int playerPositionX, out int playerPositionY)
        {
            string[] mapLines = File.ReadAllLines(fileName);

            playerPositionX = 0;
            playerPositionY = 0;

            char[,] map = new char[GetLineMaxLength(mapLines), mapLines.Length];

            for (int i = 0; i < map.GetLength(0); ++i)
            {
                for (int j = 0; j < map.GetLength(1); ++j)
                {
                    map[i, j] = mapLines[j][i];

                    if (map[i, j] == playerSymbol)
                    {
                        playerPositionX = i;
                        playerPositionY = j;
                    }
                }
            }

            return map;
        }

        private static int GetLineMaxLength (string[] lines)
        {
            int maxLength = int.MinValue;

            foreach (var line in lines)
                if (line.Length > maxLength)
                    maxLength = line.Length;

            return maxLength;
        }

        private static void PrintMap (char[,] map)
        {
            for (int i = 0; i < map.GetLength(1); ++i)
            {
                for (int j = 0; j < map.GetLength(0); ++j)
                {
                    Console.Write(map[j, i]);
                }

                Console.WriteLine();
            }
        }
    }
}
