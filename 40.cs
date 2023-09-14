using System;
using System.Collections.Generic;

namespace IJunior
{
    // Есть колода с картами.
    // Игрок достает карты, пока не решит, что ему хватит карт (может быть как выбор пользователя, так и количество сколько карт надо взять). 
    // После выводиться вся информация о вытянутых картах.
    // Возможные классы: Карта, Колода, Игрок.

    public enum SubRace
    {
        Elf = 1,
        Dwarf,
        Human,
        Orc,
        Undead,
        None
    }

    class Program
    {
        private static void Main()
        {
            Game game = new Game();
            game.Start();
        }
    }

    class Game
    {
        private bool _isRunning = true;
        private Deck _deck;
        private Player _player;

        private enum Menu
        {
            TakeCard = 1,
            TakeCards,
            Stop,
            None
        }

        public void Start()
        {
            int numberOfCards = 30;
            _deck = new Deck(numberOfCards);
            _player = new Player();

            Menu menu;

            while (_isRunning)
            {
                Console.Clear();

                menu = SelectMenuItem();
                ProcessMenuItem(menu);

                if (_deck.IsEmpty())
                {
                    Console.Clear();
                    Console.WriteLine("Колода пуста. Брать больше нечего.");
                    _isRunning = false;
                }
            }

            _player.PrintCards();

            Console.ReadKey();
        }

        private void ProcessMenuItem(Menu menu)
        {
            switch (menu)
            {
                case Menu.TakeCard:
                    _player.AddCardInHand(_deck);
                    break;
                case Menu.TakeCards:
                    _player.AddCardInHand(_deck, GetIntFromUserInput("Введите желаемое число карт: "));
                    break;
                case Menu.Stop:
                    Stop(ref _isRunning);
                    break;
                default:
                    Console.WriteLine("Неверная команда, повторите попытку снова.");
                    break;
            }
        }

        private Menu SelectMenuItem()
        {
            Menu menu;
            Console.WriteLine("Вам доступны следующие действия:" +
                                $"\n{(int)Menu.TakeCard} - Взять одну карту с колоды." +
                                $"\n{(int)Menu.TakeCards} - Взять несколько кард с колоды." +
                                $"\n{(int)Menu.Stop} - Остановиться, вас устраивает количество взятых карт.");
            menu = (Menu)GetIntFromUserInput("\nВведите номер команды меню: ");
            return menu;
        }

        private void Stop(ref bool isRunning)
        {
            Console.Clear();
            Console.WriteLine("Вы решили остановиться.\n");
            isRunning = false;
        }

        private int GetIntFromUserInput(string message)
        {
            Console.Write(message);
            int number;

            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Clear();
                Console.WriteLine("Ошибка ввода, повторите попытку.");
            }

            return number;
        }
    }

    class Player
    {
        private readonly List<Card> _cards;

        public Player()
        {
            _cards = new List<Card>();
        }

        public void AddCardInHand(Deck deck, int numberOfCards = 1)
        {
            for (int i = 0; i < numberOfCards; ++i)
            {
                Card card = deck.TakeNextCard();

                if (card == null)
                {
                    Console.WriteLine("Невозможно взять еще карту.");
                    return;
                }

                _cards.Add(card);
            }
        }

        public void PrintCards()
        {
            if (IsEmpty())
            {
                Console.WriteLine("У вас нет карт.");
                return;
            }

            Console.WriteLine("У вас есть следующие карты:");

            for (int i = 0; i < _cards.Count; ++i)
                Console.WriteLine($"{i + 1}) Подвид - {_cards[i].SubRace}, Сила - {_cards[i].Power}");
        }

        public bool IsEmpty()
        {
            return _cards.Count == 0;
        }
    }

    class Card
    {
        private readonly int _minPower = 1;
        private readonly int _maxPower = 16;

        public Card(Random random)
        {
            SubRace = (SubRace)random.Next((int)SubRace.Elf, (int)SubRace.None);
            Power = random.Next(_minPower, _maxPower);
        }

        public SubRace SubRace { get; private set; }

        public int Power { get; private set; }
    }

    class Deck
    {
        private readonly Random _random = new Random();

        private readonly Stack<Card> _cards;

        public Deck(int numberOfCards)
        {
            _cards = new Stack<Card>();

            for (int i = 0; i < numberOfCards; ++i)
                _cards.Push(new Card(_random));
        }

        public Card TakeNextCard()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Колода пуста.");
                return null;
            }

            return _cards.Pop();
        }

        public bool IsEmpty()
        {
            return _cards.Count == 0;
        }
    }
}
