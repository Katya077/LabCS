namespace Lab5;
public class Salad
{
    private readonly List<Ingredient> ingredients = new();

    public void AddIngredient(Ingredient ingredient)
    {
        ingredients.Add(ingredient);
    }

    public void ShowIngredients()
    {
        if (!ingredients.Any())
        {
            Console.WriteLine("Салат пуст.");
            return;
        }

        int i = 1;
        foreach (var ing in ingredients)
            Console.WriteLine($"{i++}. {ing}");
    }

    public double GetTotalCalories()
    {
        return ingredients.Sum(i => i.GetCalories());
    }
}