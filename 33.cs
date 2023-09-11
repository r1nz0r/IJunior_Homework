using System;
using System.Collections.Generic;

namespace IJunior
{
    internal class Program
    {
        // У вас есть множество целых чисел.Каждое целое число - это сумма покупки.
        // Вам нужно обслуживать клиентов до тех пор, пока очередь не станет пуста.
        // После каждого обслуженного клиента деньги нужно добавлять на наш счёт и выводить его в консоль.
        // После обслуживания каждого клиента программа ожидает нажатия любой клавиши, после чего затирает консоль и по новой выводит всю информацию, только уже со следующим клиентом

        static void Main (string[] args)
        {
            Queue<int> customersQuerry = new Queue<int>(new int[] { 100, 50, 400, 300, 700, 80, 1500, 240, 340 });
            int balance = 0;

            while (customersQuerry.Count > 0)
            {
                Console.WriteLine($"Ваш баланс: {balance} у.е.\n");

                Console.WriteLine($"Новый клиент! На ваш счет поступило {customersQuerry.Peek()} у.е.");
                balance += customersQuerry.Dequeue();

                Console.WriteLine("Нажмите любую клавишу для вызова следующего клиент!");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("Клиенты закончились :(");
            Console.ReadKey();
        }
    }
}
