using System;

namespace IJunior
{
    internal class Program
    {
        // Написать функцию, которая запрашивает число у пользователя(с помощью метода Console.ReadLine())
        // и пытается сконвертировать его в тип int (с помощью int.TryParse())
        // Если конвертация не удалась у пользователя запрашивается число повторно до тех пор,
        // пока не будет введено верно.
        // После ввода, который удалось преобразовать в число, число возвращается.
        // P.S Задача решается с помощью циклов
        // P.S Также в TryParse используется модфикатор параметра out

        private static void Main(string[] args)
        {
            Console.WriteLine(GetNumberFromInput());
        }

        private static int GetNumberFromInput()
        {
            bool isCorrectInput = false;
            int number;

            do
            {
                Console.Write("Введите число: ");
                isCorrectInput = int.TryParse(Console.ReadLine(), out number);
            } while (isCorrectInput == false);

            return number;
        }
    }
}
