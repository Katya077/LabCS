namespace Lab5;
class Program
{
    static void Main()
    {
        Salad salad = new Salad();
        bool running = true;

        try
        {
            string[] lines = File.ReadAllLines("ingredients.txt");

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 2)
                    throw new FormatException($"Ошибка формата: {line}");

                string type = parts[0];
                if (!double.TryParse(parts[1], out double weight))
                    throw new FormatException($"Ошибка веса: {parts[1]}");

                Ingredient ingredient = type switch
                {
                    "Tomato" => new Tomato(weight),
                    "Cucumber" => new Cucumber(weight),
                    "Carrot" => new Carrot(weight),
                    "Cabbage" => new Cabbage(weight),
                    "OliveOil" => new OliveOil(weight),
                    _ => throw new ArgumentException($"Неизвестный ингредиент: {type}")
                };

                salad.Add(ingredient);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при загрузке: {ex.Message}");
        }

        while (running)
        {
            Console.WriteLine("\n=== Меню Салата ===");
            Console.WriteLine("1. Показать все ингредиенты салата");
            Console.WriteLine("2. Посчитать общую калорийность");
            Console.WriteLine("3. Сортировать ингредиенты по калориям");
            Console.WriteLine("4. Найти ингредиенты по диапазону калорий");
            Console.WriteLine("5. Добавить новый ингредиент вручную");
            Console.WriteLine("6. Удалить ингредиент");
            Console.WriteLine("7. Изменить параметры ингредиента");
            Console.WriteLine("8. Выйти");
            Console.Write("Выберите пункт: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nИнгредиенты салата:");
                    int idx = 1;
                    foreach (var ingredient in salad.GetIngredients())
                        Console.WriteLine($"{idx++}. {ingredient}");
                    break;

                case "2":
                    Console.WriteLine($"\nОбщая калорийность: {salad.GetTotalCalories():0.00} ккал");
                    break;

                case "3":
                    salad.SortBy(i => i.GetCalories());
                    Console.WriteLine("\nИнгредиенты отсортированы по калориям:");
                    idx = 1;
                    foreach (var ingredient in salad.GetIngredients())
                        Console.WriteLine($"{idx++}. {ingredient}");
                    break;

                case "4":
                    Console.Write("Введите минимальные калории: ");
                    if (!double.TryParse(Console.ReadLine(), out double min))
                    {
                        Console.WriteLine("Неверный ввод");
                        break;
                    }

                    Console.Write("Введите максимальные калории: ");
                    if (!double.TryParse(Console.ReadLine(), out double max))
                    {
                        Console.WriteLine("Неверный ввод");
                        break;
                    }

                    var found = salad.FindByCalories(min, max).ToList();
                    if (found.Any())
                    {
                        Console.WriteLine("\nИнгредиенты в указанном диапазоне:");
                        foreach (var ingredient in found)
                            Console.WriteLine(ingredient);
                    }
                    else
                    {
                        Console.WriteLine("Ингредиенты не найдены.");
                    }
                    break;

                case "5":
                    Console.Write("Введите название ингредиента: ");
                    string name = Console.ReadLine();

                    Console.Write("Введите вес ингредиента в граммах: ");
                    if (!double.TryParse(Console.ReadLine(), out double weightNew))
                    {
                        Console.WriteLine("Неверный ввод веса");
                        break;
                    }

                    Console.Write("Введите калорийность на 100 г: ");
                    if (!double.TryParse(Console.ReadLine(), out double caloriesPer100))
                    {
                        Console.WriteLine("Неверный ввод калорийности");
                        break;
                    }

                    salad.Add(new CustomIngredient(name, weightNew, caloriesPer100));
                    Console.WriteLine($"Ингредиент {name} успешно добавлен!");
                    break;

                case "6":
                    Console.Write("Введите индекс ингредиента для удаления: ");
                    if (!int.TryParse(Console.ReadLine(), out int delIndex) || !salad.RemoveAt(delIndex))
                    {
                        Console.WriteLine("Неверный индекс");
                        break;
                    }
                    Console.WriteLine("Ингредиент удалён!");
                    break;

                case "7":
                    Console.Write("Введите индекс ингредиента для изменения: ");
                    if (!int.TryParse(Console.ReadLine(), out int updIndex))
                    {
                        Console.WriteLine("Неверный индекс");
                        break;
                    }

                    Console.Write("Введите новый вес в граммах: ");
                    if (!double.TryParse(Console.ReadLine(), out double newWeight))
                    {
                        Console.WriteLine("Неверный вес");
                        break;
                    }

                    Console.Write("Введите новую калорийность на 100 г: ");
                    if (!double.TryParse(Console.ReadLine(), out double newCalories))
                    {
                        Console.WriteLine("Неверная калорийность");
                        break;
                    }

                    if (salad.UpdateAt(updIndex, newWeight, newCalories))
                        Console.WriteLine("Ингредиент успешно обновлён!");
                    else
                        Console.WriteLine("Ошибка обновления. Проверьте индекс.");
                    break;

                case "8":
                    running = false;
                    Console.WriteLine("Выход из программы...");
                    break;

                default:
                    Console.WriteLine("Неверный пункт меню. Попробуйте снова.");
                    break;
            }
        }
    }
}
