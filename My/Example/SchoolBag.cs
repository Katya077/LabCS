namespace Example
{
    /// <summary>
    /// Класс "Школьный рюкзак" — хранит коллекцию предметов (тетрадей и учебников).
    /// </summary>
    public class SchoolBag
    {
        /// <summary>
        /// Коллекция всех предметов в рюкзаке.  
        /// Тип — List<Item>, т.е. может содержать объекты любого класса-наследника Item.
        /// </summary>
        private List<Item> _items = new List<Item>();

        /// <summary>
        /// Метод Add() — добавляет новый предмет в рюкзак.
        /// </summary>
        public void Add(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Нельзя добавить пустой предмет.");
            
            _items.Add(item);
        }

        /// <summary>
        /// Свойство Weight — возвращает суммарный вес всех предметов в рюкзаке.
        /// </summary>
        public int Weight
        {
            get
            {
                return _items.Sum(i => i.Weight);
            }
        }

        /// <summary>
        /// Метод Sort() — сортирует содержимое рюкзака по весу (по возрастанию).
        /// </summary>
        public void Sort()
        {
            _items.Sort(); // работает, потому что Item реализует IComparable<Item>
        }

        /// <summary>
        /// Метод RemoveHeaviest() — удаляет самый тяжёлый предмет из рюкзака.
        /// </summary>
        public void RemoveHeaviest()
        {
            if (_items.Count == 0) return;

            var maxItem = _items.OrderByDescending(i => i.Weight).First(); // находим самый тяжёлый
            _items.Remove(maxItem);
        }

        /// <summary>
        /// Метод HasMathTextBook() — проверяет, есть ли в рюкзаке учебник по математике.
        /// </summary>
        public bool HasMathTextBook()
        {
            return _items.OfType<TextBook>() // берём только учебники
                         .Any(tb => tb.Subject.Equals("Математика", StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Метод ToString() — возвращает информацию обо всех предметах в рюкзаке.
        /// </summary>
        public override string ToString()
        {
            if (_items.Count == 0)
                return "Рюкзак пуст.";

            string result = "Содержимое рюкзака:\n";
            foreach (var item in _items)
                result += " - " + item + "\n";

            result += $"Общий вес: {Weight} г";
            return result;
        }
    }
}
