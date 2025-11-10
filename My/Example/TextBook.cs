namespace Example
{
    /// <summary>
    /// Класс "Учебник" — наследуется от Item.  
    /// Добавляет поле "Название предмета" (например, Математика, История).
    /// </summary>
    public class TextBook : Item
    {
        /// <summary>
        /// Свойство "Предмет" — название учебного предмета.
        /// </summary>
        public string Subject { get; private set; }

        /// <summary>
        /// Конструктор учебника.
        /// Принимает вес и название предмета.
        /// </summary>
        public TextBook(int weight, string subject) : base(weight)
        {
            // Проверяем корректность названия предмета
            if (string.IsNullOrWhiteSpace(subject))
                throw new ArgumentException("Название предмета не может быть пустым.");
            
            Subject = subject;
        }

        /// <summary>
        /// Метод ToString() возвращает строковое описание учебника.
        /// Использует ToString() из базового класса, чтобы не дублировать код.
        /// </summary>
        public override string ToString()
        {
            return $"Учебник ({Subject}) — {base.ToString()}";
        }
    }
}