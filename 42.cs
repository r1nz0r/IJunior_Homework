using System;
using System.Collections.Generic;

namespace IJunior
{
    // Существует продавец, он имеет у себя список товаров, и при нужде, может вам его показать, также продавец может продать вам товар.После продажи товар переходит к вам, и вы можете также посмотреть свои вещи.
    // Возможные классы – игрок, продавец, товар.
    // Вы можете сделать так, как вы видите это.

    class Program
    {
        private static void Main ()
        {
            string commandExit = "exit";
            string commandBuy = "buy";

            Player player = new Player("Erta", 300);
            Salesman salesman = new Salesman(new[] {
                new Product("Кувшин", 100),
                new Product("Орех", 30),
                new Product("Меч", 250) }
            );

            string userInput = "";

            while (userInput != commandExit)
            {
                salesman.TryShowProducts();
                Console.WriteLine();

                player.TryShowProducts();
                player.ShowBalance();
                Console.WriteLine();

                Console.WriteLine("Что вы хотите сделать?" +
                    $"\nКупить предмет (введите {commandBuy})." +
                    $"\nПокинуть лавку торговца (введите {commandExit})");
                userInput = Console.ReadLine();

                Console.Clear();

                if (userInput == commandBuy)
                    player.BuyProduct(salesman);
                else if (userInput == commandExit)
                    Console.WriteLine("Вы покинули лавку торговца. Удачной дороги!");
            }

            Console.ReadKey();
        }
    }

    abstract class Consumer
    {
        protected List<Product> _products;
        private int _money;

        public Consumer ()
        {
            _products = new List<Product>();
        }

        public Consumer (Product[] products)
        {
            _products = new List<Product>(products);
        }

        public int Money
        {
            get
            {
                return _money;
            }
            protected set
            {
                _money = value < 0 ? 0 : value;
            }
        }

        public abstract bool TryShowProducts ();
    }

    class Player : Consumer
    {
        private string _name;

        public Player (string name, int money)
        {
            _name = name;
            Money = money;
        }

        public void BuyProduct (Salesman salesman)
        {
            Console.Clear();

            if (salesman.TryShowProducts() == false)
            {
                return;
            }

            Console.WriteLine("Укажите название товара, который вы хотите приобрести: ");
            string userInput = Console.ReadLine();

            Product product;
            bool isSuccess = salesman.TrySellProduct(userInput, Money, out product);

            Console.Clear();

            if (isSuccess)
            {
                Money -= product.Price;
                _products.Add(product);
                Console.WriteLine($"Поздравляем с приобретением {product.Name}!");
            }
            else if (Money < product.Price)
            {
                Console.WriteLine("Увы, на вашем балансе надостаточно средств.");
            }
            else
            {
                Console.WriteLine("Увы, такого товара нет.");
            }
        }

        public override bool TryShowProducts ()
        {
            if (_products.Count > 0)
            {
                Console.WriteLine("Список предметов в инвентаре:");

                foreach (var product in _products)
                    Console.WriteLine($"{product.Name}");

                return true;
            }

            Console.WriteLine($"Инвентарь игрока {_name} пуст.");
            return false;
        }

        public void ShowBalance ()
        {
            Console.WriteLine($"Баланс игрока {_name}: {Money} у.е.");
        }
    }

    class Salesman : Consumer
    {
        public Salesman (Product[] goods) : base(goods) { }

        public bool TrySellProduct (string productName, int cashAmmount, out Product product)
        {
            product = null;

            foreach (var item in _products)
            {
                if (item.Name.ToLower() == productName.ToLower())
                {
                    product = item;

                    if (cashAmmount >= item.Price)
                    {
                        Money += item.Price;
                        _products.Remove(item);
                        return true;
                    }
                }
            }

            return false;
        }

        public override bool TryShowProducts ()
        {
            if (_products.Count > 0)
            {
                Console.WriteLine("Список товаров на продажу:");

                foreach (var product in _products)
                    Console.WriteLine($"{product.Name} по цене {product.Price} у.е.");

                return true;
            }

            Console.WriteLine("Товары закончились.");
            return false;
        }
    }

    class Product
    {
        public Product (string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }
        public int Price { get; private set; }
    }
}
