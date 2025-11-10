namespace Example
{
    /// <summary>
    /// Абстрактный базовый класс для всех предметов в рюкзаке.
    /// Содержит общее свойство "Вес" и поведение, которое характерно для всех вещей.
    /// </summary>
    public abstract class Item : IComparable<Item> // абстрактный класс и интерфейс для сравнения по весу
    {
        // 🔹 Приватное поле для хранения веса предмета
        private int _weight;

        /// <summary>
        /// Публичное свойство для доступа к весу предмета.
        /// Гарантирует, что вес всегда положительный.
        /// </summary>
        public int Weight
        {
            get => _weight; // возвращает текущее значение веса

            protected set // protected — изменять вес могут только наследники (например, NoteBook или TextBook)
            {
                if (value <= 0)
                    throw new ArgumentException("Вес должен быть положительным числом (>0).");
                _weight = value;
            }
        }

        /// <summary>
        /// Конструктор базового класса.  
        /// При создании любого предмета нужно указать его вес.
        /// </summary>
        protected Item(int weight)
        {
            Weight = weight;
        }

        /// <summary>
        /// Реализация метода сравнения предметов по весу.  
        /// Используется при сортировке коллекций (Sort()).
        /// </summary>
        public int CompareTo(Item other)
        {
            if (other == null) return 1; // если другой предмет отсутствует, текущий "больше"
            return this.Weight.CompareTo(other.Weight); // сравниваем веса
        }

        /// <summary>
        /// Метод ToString() возвращает строковое описание предмета.  
        /// Переопределяется в наследниках, чтобы добавить их уникальные поля.
        /// </summary>
        public override string ToString()
        {
            return $"Вес: {Weight} г";
        }
    }
}