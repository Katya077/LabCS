namespace Example
{
    class Program
    {
        static void Main()
        {
            // Создаём новый школьный рюкзак
            SchoolBag bag = new SchoolBag();

            // Добавляем тетради и учебники с фиксированными значениями
            bag.Add(new NoteBook(300, 96));
            bag.Add(new TextBook(1200, "Математика"));
            bag.Add(new TextBook(800, "История"));
            bag.Add(new NoteBook(250, 48));

            // Сортируем содержимое по весу
            bag.Sort();

            // Проверяем вес рюкзака
            if (bag.Weight > 3000) // если больше 3 кг — удаляем самый тяжёлый предмет
            {
                Console.WriteLine("Рюкзак слишком тяжёлый! Удаляем самый тяжёлый предмет...");
                bag.RemoveHeaviest();
            }

            // Проверяем, есть ли учебник по математике
            bool hasMath = bag.HasMathTextBook();
            Console.WriteLine(hasMath ? "В рюкзаке есть учебник по математике." : "Учебника по математике нет.");

            // Выводим содержимое рюкзака
            Console.WriteLine();
            Console.WriteLine(bag);
        }
    }
}