using System;

namespace IJunior {
    internal class Program {
        static void Main(string[] args) {
            int imagesPerRow = 3;
            int totalImages = 52;

            int fullRows = totalImages / imagesPerRow;
            int restPictures = totalImages % imagesPerRow;

            Console.WriteLine($"Всего будет выведено {fullRows} заполненных рядов. Сверх нормы останется картинок: {restPictures}.");
        }
    }
}
