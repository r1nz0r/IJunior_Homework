using System;
using System.Collections.Generic;

namespace IJunior
{
    // У вас есть программа, которая помогает пользователю составить план поезда.
    // Есть 4 основных шага в создании плана:
    // -Создать направление - создает направление для поезда (к примеру Бийск - Барнаул)
    // -Продать билеты - вы получаете рандомное кол-во пассажиров, которые купили билеты на это направление
    // -Сформировать поезд - вы создаете поезд и добавляете ему столько вагонов (вагоны могут быть разные по вместительности), сколько хватит для перевозки всех пассажиров.
    // -Отправить поезд - вы отправляете поезд, после чего можете снова создать направление.
    // В верхней части программы должна выводиться полная информация о текущем рейсе или его отсутствии.

    class Program
    {
        private static void Main ()
        {
            RailwayStation railwayStation = new RailwayStation();
            railwayStation.Work();

            Console.ReadKey();
        }
    }

    class RailwayStation
    {
        private Random _random;
        private Dictionary<string, Queue<Train>> _routes;
        private int _minPassengersCount = 10;
        private int _maxPassengersCount = 300;

        public RailwayStation ()
        {
            _random = new Random();
            _routes = new Dictionary<string, Queue<Train>>();
        }

        public void Work ()
        {
            string commandExit = "exit";
            string commandSell = "sell";
            string commandSend = "send";
            string commandMakeRoute = "make route";

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Введите команду из списка для выполнения:");
                Console.WriteLine($"{commandMakeRoute} - создать направление для поезда;");
                Console.WriteLine($"{commandSell} - продать билеты на поезд;");
                Console.WriteLine($"{commandSend} - сформировать поезд и отправить его в путь;");
                Console.WriteLine($"{commandExit} - выйти из программы.");

                string userInput = Console.ReadLine();
                Console.Clear();

                if (userInput == commandMakeRoute)
                {
                    MakeRoute();
                }
                else if (userInput == commandSell)
                {
                    SellTickets();
                }
                else if (userInput == commandSend)
                {
                    SendTrain();
                }
                else if (userInput == commandExit)
                {
                    isRunning = false;
                    Console.WriteLine("Всего доброго!");
                }
                else
                {
                    Console.WriteLine("Неизвестная команда.");
                }
            }
        }

        private string GetUserInput (string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        private void MakeRoute ()
        {
            string route = GetUserInput("Укажите направление следования поезда (напр. Бийск - Барнаул): ");

            if (_routes.ContainsKey(route.ToLower()) == false)
                _routes.Add(route.ToLower(), new Queue<Train>());
            else
                Console.WriteLine("Такое направление уже есть!");
        }

        private void SellTickets ()
        {
            if (TryShowAllRoutes() == false)
                return;

            string route = GetUserInput("Укажите направление для продажи билетов: ");
            Console.WriteLine();

            if (_routes.ContainsKey(route))
            {
                int passengersCount = _random.Next(_minPassengersCount, _maxPassengersCount);

                Train train = new Train(_random);
                train.SetPassengersCount(passengersCount);
                _routes[route].Enqueue(train);

                Console.WriteLine($"На поезд, следующий по маршруту \"{route}\" продано {passengersCount} билетов.");
            }
            else
            {
                Console.WriteLine("Невозможно продать билет на этот маршрут.");
            }
        }

        private void SendTrain ()
        {
            if (TryShowAllRoutes() == false)
                return;

            string route = GetUserInput("Укажите направление следования поезда (напр. Бийск - Барнаул): ");
            Console.WriteLine();

            if (TryGetTrain(route, out Train train))
            {
                train.Make();
                Console.WriteLine($"Поезд следующий по маршруту \"{route}\" и состоящий из {train.GetCarriagesCount} вагонов отправлен в путь.\n");
            }
            else
            {
                Console.WriteLine("Невозможно отправить поезд.");
            }
        }

        private bool TryShowAllRoutes ()
        {
            if (_routes.Count > 0)
            {
                Console.WriteLine("Доступны следующие направления следования поездов:");

                foreach (var route in _routes.Keys)
                    Console.WriteLine(route);

                return true;
            }

            Console.WriteLine("Доступных направлений нет.");
            return false;
        }

        private bool TryGetTrain (string route, out Train train)
        {
            if (_routes.ContainsKey(route.ToLower()))
            {
                if (_routes[route].Count > 0)
                {
                    train = _routes[route].Dequeue();
                    return true;
                }
                else
                {
                    Console.WriteLine("По данному направлению нет поездов");
                }
            }
            else
            {
                Console.WriteLine("Такого направления нет.");
            }

            train = null;
            return false;
        }
    }

    class Train
    {
        private List<Carriage> _carriages;
        private Random _random;
        private int _passengersCount;

        public Train (Random random)
        {
            _random = random;
            _carriages = new List<Carriage>();
        }

        public void SetPassengersCount (int passengersCount)
        {
            _passengersCount = passengersCount;
        }

        public void Make ()
        {
            int totalCapacity = 0;
            int minCarriageCapacity = 20;
            int maxCarriageCapacity = 80;

            while (totalCapacity < _passengersCount)
            {
                int capacity = _random.Next(minCarriageCapacity, maxCarriageCapacity + 1);
                _carriages.Add(new Carriage(capacity));
                totalCapacity += capacity;
            }
        }

        public int GetCarriagesCount => _carriages.Count;
    }

    class Carriage
    {
        public Carriage (int capacity)
        {
            Capacity = capacity;
        }

        public int Capacity { get; private set; }
    }
}
