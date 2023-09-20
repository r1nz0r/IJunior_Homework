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


            Console.ReadKey();
        }
    }

    class RailwayStation
    {
        private Random _random;

        private Queue<Train> _trains;

        public RailwayStation ()
        {
            _random = new Random();
            _trains = new Queue<Train>();
        }

        public void MakeRoute (string route)
        {
            _trains.Enqueue(new Train(_random, route));
        }

        public void SellTickets (int passengersCount)
        {
            _trains.Peek().SetPassengersCount(passengersCount);
        }  

        public void SendTrain ()
        {
            Train train = _trains.Dequeue();
            train.Make();

            Console.WriteLine($"Поезд, следующий по маршруту {train.Route}, отправлен в путь.");
        }
    }

    class Train
    {
        private List<Carriage> _carriages;
        private Random _random;
        private int _passengersCount;

        public Train (Random random, string route)
        {
            _random = random;
            _carriages = new List<Carriage>();
            Route = route;
        }

        public string Route { get; private set; }

        public void SetPassengersCount(int passengersCount)
        {
            _passengersCount = passengersCount;
        }

        public void Make()
        {
            int totalCapacity = 0;
            int minCarriageCapacity = 50;
            int maxCarriageCapacity = 200;

            while (totalCapacity < _passengersCount)
            {
                int capacity = _random.Next(minCarriageCapacity, maxCarriageCapacity + 1);
                _carriages.Add(new Carriage(capacity));
                totalCapacity += capacity;
            }
        }
    }

    class Carriage
    {
        public Carriage(int capacity)
        {
            Capacity = capacity;
        }

        public int Capacity { get; private set; }
    }
}
