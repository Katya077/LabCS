
namespace Lab5;

    public class Salad
    {
        private readonly List<Ingredient> _ingredients = new();

        public void Add(Ingredient ingredient) => _ingredients.Add(ingredient);

        public IEnumerable<Ingredient> GetIngredients() => _ingredients;

        public double GetTotalCalories() => _ingredients.Sum(i => i.GetCalories());

        public void SortBy(Func<Ingredient, object> keySelector)
        {
            _ingredients.Sort((a, b) => Comparer<object>.Default.Compare(keySelector(a), keySelector(b)));
        }

        public IEnumerable<Ingredient> FindByCalories(double min, double max)
        {
            return _ingredients.Where(i => 
            {
                double cal = i.GetCalories();
                return cal >= min && cal <= max;
            });
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= _ingredients.Count) return false;
            _ingredients.RemoveAt(index);
            return true;
        }

        public bool UpdateAt(int index, double newWeight, double newCaloriesPer100)
        {
            if (index < 0 || index >= _ingredients.Count) return false;
            var ing = _ingredients[index];
            
            var updated = new CustomIngredient(ing.Name, newWeight, newCaloriesPer100);

            _ingredients[index] = updated;
            return true;
        }
    }

    public class CustomIngredient : Ingredient
    {
        public CustomIngredient(string name, double weight, double caloriesPer100)
            : base(name, weight, caloriesPer100) { }
    }
