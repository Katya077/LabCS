namespace Lab5;

public class Salad
{
    private readonly List<Ingredient> _ingredients = new();

    public void Add(Ingredient ingredient)
    {
        _ingredients.Add(ingredient);
    }
    public IEnumerable<Ingredient> GetIngredients() => _ingredients;

    public double GetTotalCalories()
    {
        return _ingredients.Sum(i => i.GetCalories());
    }
}