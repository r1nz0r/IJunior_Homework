using System;
using System.IO;
namespace IJunior
{
    internal class Program
    {
        // Найти наибольший элемент матрицы A(10,10) и записать ноль в те ячейки, где он находятся.
        // Вывести наибольший элемент, исходную и полученную матрицу.
        // Массив под измененную версию не нужен.

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

            switch (pressedKey)
            {
                case ConsoleKey.W:
                    playerMoveX = 0;
                    playerMoveY = -1;
                    break;
                case ConsoleKey.S:
                    playerMoveX = 0;
                    playerMoveY = 1;
                    break;
                case ConsoleKey.A:
                    playerMoveX = -1;
                    playerMoveY = 0;
                    break;
                case ConsoleKey.D:
                    playerMoveX = 1;
                    playerMoveY = 0;
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
