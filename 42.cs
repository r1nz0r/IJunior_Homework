using System;
using System.Collections.Generic;

namespace IJunior
{
    // Существует продавец, он имеет у себя список товаров, и при нужде, может вам его показать, также продавец может продать вам товар.После продажи товар переходит к вам, и вы можете также посмотреть свои вещи.
    // Возможные классы – игрок, продавец, товар.
    // Вы можете сделать так, как вы видите это.

    class Program
    {
        private static void Main()
        {
            string commandExit = "exit";
            string commandBuy = "buy";

            Player player = new Player("Erta");
            Salesman salesman = new Salesman(new[] {
                new Product("Кувшин"),
                new Product("Орех"),
                new Product("Меч") }
            );

            string userInput = "";

            while (userInput != commandExit)
            {
                salesman.TryShowProducts();
                Console.WriteLine();
                player.ShowInventory();
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

    class Player
    {
        private List<Product> _inventory;
        private string _name;

        public Player(string name)
        {
            _inventory = new List<Product>();
            _name = name;
        }

        public void BuyProduct(Salesman salesman)
        {
            Console.Clear();

            if (salesman.TryShowProducts() == false)
            {
                return;
            }

            Console.WriteLine("Укажите название товара, который вы хотите приобрести: ");
            string userInput = Console.ReadLine();

            Product product;
            bool isSuccess = salesman.TrySellProduct(userInput, out product);

            Console.Clear();

            if (isSuccess)
            {
                _inventory.Add(product);
                Console.WriteLine($"Поздравляем с приобретением {product.Name}!");
            }
            else
            {
                Console.WriteLine("Увы, такого товара нет.");
            }
        }

        public void ShowInventory()
        {
            if (_inventory.Count > 0)
            {
                Console.WriteLine($"Инвентарь игрока {_name}: ");

                foreach (var item in _inventory)
                    Console.WriteLine(item.Name);
            }
            else
            {
                Console.WriteLine($"Инвентарь игрока {_name} пуст.");
            }
        }
    }

    class Salesman
    {
        private List<Product> _products;

        public Salesman(Product[] goods)
        {
            _products = new List<Product>(goods);
        }

        public bool TryShowProducts()
        {
            if (_products.Count > 0)
            {
                Console.WriteLine("Список товаров на продажу:");

                foreach (var product in _products)
                    Console.WriteLine(product.Name);
                return true;
            }

            Console.WriteLine("Товары закончились.");
            return false;
        }

        public bool TrySellProduct(string productName, out Product product)
        {
            product = null;

            foreach (var item in _products)
            {
                if (item.Name.ToLower() == productName.ToLower())
                {
                    product = item;
                    _products.Remove(item);
                    return true;
                }
            }

            return false;
        }
    }

    class Product
    {
        public Product(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
