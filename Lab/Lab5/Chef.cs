namespace Lab5;
public class Chef : Person
{
    public Chef(string name) : base(name) { }

    public override void ShowMenu(Salad salad)
    {
        Console.WriteLine("\nВы — шеф-повар");
        Console.WriteLine("1. Показать ингредиенты");
        Console.WriteLine("2. Добавить ингредиент");
        Console.WriteLine("0. Выйти");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                salad.ShowIngredients();
                break;

            case "2":
                AddIngredient(salad);
                break;
        }
    }

    private void AddIngredient(Salad salad)
    {
        Console.Write("Название ингредиента: ");
        string name = Console.ReadLine();

        Console.Write("Вес (г): ");
        if (!double.TryParse(Console.ReadLine(), out double weight))
        {
            Console.WriteLine("Ошибка ввода веса");
            return;
        }

        Console.Write("Ккал на 100 г: ");
        if (!double.TryParse(Console.ReadLine(), out double calories))
        {
            Console.WriteLine("Ошибка ввода калорий");
            return;
        }

        Console.WriteLine("Категория:");
        Console.WriteLine("V — Овощ");
        Console.WriteLine("D — Заправка");
        Console.Write("Введите букву: ");

        string category = Console.ReadLine()?.Trim().ToUpper();

        Ingredient ingredient;

        if (category == "V")
            ingredient = new Vegetable(name, weight, calories);
        else if (category == "D")
            ingredient = new Dressing(name, weight, calories);
        else
        {
            Console.WriteLine("Неверная категория");
            return;
        }

        salad.AddIngredient(ingredient);
        Console.WriteLine("Ингредиент добавлен");
    }
}