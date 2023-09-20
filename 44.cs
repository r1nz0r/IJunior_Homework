using System;
using System.Collections.Generic;

namespace IJunior
{
    // Создать 5 бойцов, пользователь выбирает 2 бойцов и они сражаются друг с другом до смерти.У каждого бойца могут быть свои статы.
    // Каждый игрок должен иметь особую способность для атаки, которая свойственна только его классу!
    // Если можно выбрать одинаковых бойцов, то это не должна быть одна и та же ссылка на одного бойца, чтобы он не атаковал сам себя.
    // Пример, что может быть уникальное у бойцов. Кто-то каждый 3 удар наносит удвоенный урон, другой имеет 30% увернуться от полученного урона,
    // кто-то при получении урона немного себя лечит. Будут новые поля у наследников. У кого-то может быть мана и это только его особенность.

    class Program
    {
        private static void Main ()
        {
            bool isBattleFinished = false;

            while (isBattleFinished == false)
            {
                Battlefield field = new Battlefield();

                if (field.TryChooceFighters())
                {
                    Console.Write("Для начала битвы нажмите любую клавишу...");
                    Console.ReadKey();
                    Console.Clear();

                    field.Battle();                    
                }

                isBattleFinished = field.GetBattleResult();
            }

            Console.ReadKey();
        }
    }

    abstract class Fighter
    {
        public Fighter (string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }

        public virtual void ShowStats ()
        {
            Console.WriteLine($"Имя - {Name}; Жизни - {Health}; Урон - {Damage}");
        }

        public virtual void Attack (Fighter target) => target.TakeDamage(Damage);

        protected virtual void TakeDamage (int damage)
        {
            Health -= damage;
        }
    }

    class Warrior : Fighter
    {
        private Random _random;
        private int _requiredNumForDoubleAttack = 5;
        private int _randomMaxNumber = 12;

        public Warrior (string name, int health, int damage, Random random) : base(name, health, damage)
        {
            _random = random;
        }

        public override void Attack (Fighter target)
        {
            base.Attack(target);
            int currentNum = _random.Next(0, _randomMaxNumber);

            if (_requiredNumForDoubleAttack >= currentNum)
            {
                Console.WriteLine($"Удача улыбнулась {Name}, он проводит дополнительную атаку!");
                base.Attack(target);
            }
        }
    }

    class Elf : Fighter
    {
        private Random _random;
        private int _evasionChancePercent = 30;
        private int _randomMaxPercent = 100;

        public Elf (string name, int health, int damage, Random random) : base(name, health, damage)
        {
            _random = random;
        }

        protected override void TakeDamage (int damage)
        {
            int rolledChance = _random.Next(0, _randomMaxPercent);

            if (rolledChance > _evasionChancePercent)
                base.TakeDamage(damage);
            else
                Console.WriteLine("Вы используете эльфийскую ловкость и уклоняетесь от атаки.");
        }
    }

    class Knight : Fighter
    {
        private double _maxPercent = 100.0;
        private double _maxDamageReducePercent = 70.0;
        private double _damageReducePercent;

        public Knight (string name, int health, int damage, double damageReducePercent) : base(name, health, damage)
        {
            DamageReducePercent = damageReducePercent;
        }

        public double DamageReducePercent
        {
            get
            {
                return _damageReducePercent;
            }
            private set
            {
                if (value < 0)
                    _damageReducePercent = 0;
                else if (value >= _maxDamageReducePercent)
                    _damageReducePercent = _maxDamageReducePercent;
                else
                    _damageReducePercent = value;
            }
        }

        protected override void TakeDamage (int damage)
        {
            int reducedDamage = (int)(damage * (_maxPercent - _damageReducePercent) / _maxPercent);           

            Console.WriteLine($"Тяжелые рыцарьские доспехи снижают полученный урон на {_damageReducePercent}%");
            base.TakeDamage(reducedDamage);
        }
    }

    class Klirik : Fighter
    {
        private int _mana;
        private int _healSpellManaCost = 20;
        private int _healAmmount;
        private int _maxHealth;
        public Klirik (string name, int health, int damage, int mana, int healAmmount) : base(name, health, damage)
        {
            _maxHealth = Health;
            _mana = mana;
            _healAmmount = healAmmount;
        }

        public override void Attack (Fighter target)
        {
            base.Attack(target);

            if (_mana > _healSpellManaCost)
            {
                Heal();
            }
        }

        private void Heal ()
        {
            _mana -= _healSpellManaCost;
            Health += _healAmmount;

            if (Health > _maxHealth)
                Health = _maxHealth;

            Console.WriteLine($"Используя священную магию {Name} излечивается после атаки на {_healAmmount} hp");
        }
    }

    class Berserk : Fighter
    {
        private int _roundsToTrippleAttack = 3;
        private int _roundsCounter = 0;

        public Berserk (string name, int health, int damage) : base(name, health, damage) { }

        public override void Attack (Fighter target)
        {
            base.Attack(target);

            if (++_roundsCounter == _roundsToTrippleAttack)
            {
                Console.WriteLine($"Ярость берсерка позволяет провести еще две атаки");
                base.Attack(target);
                base.Attack(target);

                _roundsCounter = 0;
            }
        }
    }

    class Battlefield
    {
        private Random _random;

        private Fighter _firstFighter;
        private Fighter _secondFighter;
        private List<Fighter> _fighters = new List<Fighter>();

        public Battlefield ()
        {
            _random = new Random();

            _fighters.Add(new Warrior("Воин", 240, 20, _random));
            _fighters.Add(new Elf("Эльф", 160, 30, _random));
            _fighters.Add(new Knight("Рыцарь", 200, 25, 25));
            _fighters.Add(new Klirik("Клирик", 140, 40, 60, 20));
            _fighters.Add(new Berserk("Берсерк", 170, 30));
        }

        public bool TryChooceFighters ()
        {
            Console.WriteLine("Выберите первого бойца");
            _firstFighter = ChooseFighter();

            Console.Clear();

            Console.WriteLine("Выберите второго бойца");
            _secondFighter = ChooseFighter();

            if (_firstFighter == null || _secondFighter == null)
            {
                Console.WriteLine("Ошибка выбора бойца");
                return false;
            }
            else
            {
                Console.WriteLine("Бойцы выбраны");
                return true;
            }
        }

        private void ShowFighters ()
        {
            Console.WriteLine("Список доступный бойцов");

            for (int i = 0; i < _fighters.Count; i++)
            {
                Console.Write($"{i + 1}) ");
                _fighters[i].ShowStats();
            }
        }

        public void Battle ()
        {
            while (_firstFighter.Health > 0 && _secondFighter.Health > 0)
            {
                _firstFighter.ShowStats();
                _firstFighter.Attack(_secondFighter);

                _secondFighter.ShowStats();
                _secondFighter.Attack(_firstFighter);

                Console.ReadKey();
                Console.Clear();
            }
        }

        public bool GetBattleResult ()
        {
            bool isFinished = false;

            if (_firstFighter.Health <= 0 || _secondFighter.Health <= 0)
            {
                isFinished = true;

                if (_firstFighter.Health <= 0)
                    Console.WriteLine($"{_secondFighter.Name} победил!");
                else if (_secondFighter.Health <= 0)
                    Console.WriteLine($"{_firstFighter.Name} победил!");
                else
                    Console.WriteLine("Ничья, оба погибли");
            }

            return isFinished;
        }

        private Fighter ChooseFighter ()
        {
            ShowFighters();
            Console.Write("Введите номер бойца: ");
            bool isNumber = int.TryParse(Console.ReadLine(), out int inputID);

            Fighter fighter;

            if (isNumber)
            {
                if (inputID > 0 && inputID - 1 < _fighters.Count)
                {
                    fighter = _fighters[inputID - 1];
                    _fighters.Remove(fighter);
                    Console.WriteLine("Боец успешно выбран.");
                    return fighter;
                }
            }

            Console.WriteLine("Ошибка ввода данных.");
            return null;
        }
    }
}
