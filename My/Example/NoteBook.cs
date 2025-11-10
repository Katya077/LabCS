namespace Example
{
    /// <summary>
    /// Класс "Тетрадь" — наследуется от Item.  
    /// Добавляет поле "Количество страниц".
    /// </summary>
    public class NoteBook : Item
    {
        // 🔹 Приватное поле для хранения количества страниц
        private int _pages;

        /// <summary>
        /// Свойство для чтения количества страниц.
        /// Проверяет, чтобы количество страниц было больше 0.
        /// </summary>
        public int Pages
        {
            get => _pages;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Количество страниц должно быть больше 0.");
                _pages = value;
            }
        }

        /// <summary>
        /// Конструктор тетради.
        /// Передаём вес (в граммах) и количество страниц.
        /// Вызывается конструктор базового класса Item для установки веса.
        /// </summary>
        public NoteBook(int weight, int pages) : base(weight)
        {
            Pages = pages;
        }

        /// <summary>
        /// Метод ToString() — возвращает строку с описанием тетради.
        /// Использует ToString() из базового класса, чтобы не дублировать код.
        /// </summary>
        public override string ToString()
        {
            return $"Тетрадь — {base.ToString()}, Страниц: {Pages}";
        }
    }
}