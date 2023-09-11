using System;
using System.Collections.Generic;

namespace IJunior
{
    internal class Program
    {
        // Создать программу, которая принимает от пользователя слово и выводит его значение.
        // Если такого слова нет, то следует вывести соответствующее сообщение.

        static void Main (string[] args)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            dictionary.Add(
                "ручка",
                "1. Часть предмета, за к-рую его держат или берутся рукой." +
                "\n2. Часть мебели, служащая опорой для рук, подлокотник." +
                "\n3. Письменная принадлежность удлинённый держатель для пера, стержня.");
            dictionary.Add(
                "карандаш",
                "1. Тонкая палочка графита или сухой краски в деревянной оболочке, употребляемая для письма, рисования, черчения." +
                "\n2. Рисунок, изображение, сделанные карандашом.");
            dictionary.Add(
                "тележка",
                "1. Уменьш. к телега; небольшая телега." +
                "\nПовозка с сиденьием и с козлами для возницы." +
                "\nРучная или механическая повозка для перевозки грузов." +
                "\nПодвижная часть некоторых машин, технических устройств.");

            Console.WriteLine("Введите интересующее вас слово или :");
            string userInput = Console.ReadLine().ToLower();

            if (dictionary.ContainsKey(userInput))
                Console.WriteLine(dictionary[userInput]);
            else
                Console.WriteLine("Нет такого слова в словаре.");

            Console.ReadKey();
        }
    }
}
