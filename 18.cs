using System;

namespace IJunior
{
    internal class Program
    {
        // Легенда: Вы – теневой маг(можете быть вообще хоть кем) и у вас в арсенале есть несколько заклинаний, которые вы можете использовать против Босса.
        // Вы должны уничтожить босса и только после этого будет вам покой.
        // Формально: перед вами босс, у которого есть определенное кол-во жизней и определенный ответный урон.
        // У вас есть 4 заклинания для нанесения урона боссу.Программа завершается только после смерти босса или смерти пользователя.
        // Пример заклинаний:
        // Рашамон – призывает теневого духа для нанесения атаки (Отнимает 100 хп игроку)
        // Хуганзакура(Может быть выполнен только после призыва теневого духа), наносит 100 ед.урона
        // Межпространственный разлом – позволяет скрыться в разломе и восстановить 250 хп.Урон босса по вам не проходит
        // Заклинания должны иметь схожий характер, то есть иметь как одиночное действие, так и какие-то условия выполнения(пример - Хуганзакура).
        // Одно заклинание влияет на другое, тоже нужно для практики.Босс должен иметь возможность убить пользователя, возможна и ничья.

        static void Main(string[] args)
        {
            Random random = new Random();

            int sunStrikeSpellId = 1;
            int iceBiteSpellId = 2;
            int romashonSpellId = 3;
            int hugandzakuraSpellId = 4;
            int elvesStealthSpellId = 5;
            int emptySpellId = 6;

            string sunStrikeSpellName = "Луч солнца";
            string iceBiteSpellName = "Ледянящий укус";
            string romashonSpellName = "Ромашон";
            string hugandzakuraSpellName = "Хугандзакура";
            string elvesStealthSpellName = "Скрытность эльфов";
            string emptySpellName = "Неизвестное заклинание";

            int playerHealth = 500;
            int bossHealth = 1500;

            int sunStrikeDamage = 200;
            int iceBiteDamage = 200;
            int romashonDamage = 100;
            int hugandzakuraDamage = 300;
            int elvesStealthHeal = 250;

            int bossDamage = 75;

            bool isElvesStealthActive = false;
            bool isRomashonActive = false;

            while (playerHealth >= 0 && bossHealth >= 0)
            {
                Console.WriteLine($"\n\nЗдоровье игрока - {playerHealth};");
                Console.WriteLine($"Здоровье босса - {bossHealth}");

                int spellNumber = random.Next(sunStrikeSpellId, emptySpellId + 1);

                if (spellNumber == sunStrikeSpellId)
                {
                    bossHealth -= sunStrikeDamage;
                    Console.WriteLine($"Игрок использует заклинание \"{sunStrikeSpellName}\", нанося {sunStrikeDamage} единиц урона боссу.");
                }
                else if (spellNumber == iceBiteSpellId)
                {
                    bossHealth -= iceBiteDamage;
                    Console.WriteLine($"Игрок использует заклинание \"{iceBiteSpellName}\", нанося {iceBiteDamage} единиц урона боссу.");
                }
                else if (spellNumber == romashonSpellId)
                {
                    if (isRomashonActive)
                    {
                        Console.WriteLine($"Нельзя повторно использовать заклинание {romashonSpellName}");
                    }
                    else
                    {
                        playerHealth -= romashonDamage;
                        isRomashonActive = true;
                        Console.WriteLine($"Игрок активирует способность \"{romashonSpellName}\", принеся в жертву свои {romashonDamage} единиц здоровья.");
                    }
                }
                else if (isRomashonActive && spellNumber == hugandzakuraSpellId)
                {
                    bossHealth -= hugandzakuraDamage;
                    isRomashonActive = false;
                    Console.WriteLine($"Игрок использует заклинание \"{hugandzakuraSpellName}\", нанося {hugandzakuraDamage} единиц урона боссу.");
                }
                else if (spellNumber == elvesStealthSpellId && isElvesStealthActive == false)
                {
                    if (isElvesStealthActive)
                    {
                        Console.WriteLine($"Нельзя повторно использовать заклинание {elvesStealthSpellName}");
                    }
                    else
                    {
                        playerHealth += elvesStealthHeal;
                        isElvesStealthActive = true;
                        Console.WriteLine($"Игрок использует заклинание \"{elvesStealthSpellName}\", уходя в тень и излечивая себя на {elvesStealthHeal} единиц здоровья.");
                    }
                }
                else
                {
                    Console.WriteLine(emptySpellName + ". Вы пропускаете ход.");
                }

                if (isElvesStealthActive == false)
                {
                    playerHealth -= bossDamage;
                    Console.WriteLine($"Босс атакует игрока, нанося ему {bossDamage} единиц урона.");
                }
                else
                {
                    isElvesStealthActive = false;
                    Console.WriteLine($"Босс промахивается по игроку, так как активно заклинание \"{elvesStealthSpellName}\"");
                }
            }

            Console.WriteLine();

            if (playerHealth <= 0 && bossHealth > 0)
                Console.WriteLine("Увы, вы убиты...");
            else if (bossHealth <= 0 && playerHealth > 0)
                Console.WriteLine("Ура, босс повержен!");
            else
                Console.WriteLine("Вы пали смертью храбрых, при этом забрав с собой босса.");
        }
    }
}
