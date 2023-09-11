using System;
using System.Collections.Generic;

namespace IJunior
{
    internal class Program
    {
        // Есть два массива строк.Надо их объединить в одну коллекцию, исключив повторения, не используя Linq.
        // Пример: { "1", "2", "1"} + {"3", "2"} => {"1", "2", "3"}

        static void Main (string[] args)
        {
            string[] strings1 = new string[] { "1", "2", "1" };
            string[] strings2 = new string[] { "3", "2", };

            List<string> unitedStrings = new List<string>();
            AddUniqueStrings(unitedStrings, strings1);
            AddUniqueStrings(unitedStrings, strings2);
        }

        static void AddUniqueStrings (List<string> stringList, string[] stringArray)
        {
            foreach (var item in stringArray)
            {
                if (!stringList.Contains(item))
                    stringList.Add(item);
            }
        }
    }
}
