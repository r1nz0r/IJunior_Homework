using System;

namespace IJunior {
    internal class Program {
        static void Main(string[] args) {
            Console.Write("Введите кол-во золота: ");
            int.TryParse(Console.ReadLine(), out int goldAmmount);

            int crystalPrice = 70;            
            Console.Write($"Вы можете купить кристаллы по цене {crystalPrice} золота за кристалл. Сколько хотите купить? ");
            int.TryParse(Console.ReadLine(), out int crystalsAmmount);        
            goldAmmount -= crystalsAmmount * crystalPrice;

            Console.WriteLine($"Вы успешно приобрели {crystalsAmmount} кристаллов и у вас осталось {goldAmmount} золота");
        }
    }
}
