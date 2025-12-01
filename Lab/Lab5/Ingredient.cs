namespace Lab5;

public abstract class Ingredient
{
    public string Name {get;}
    public double Weight {get;}
    public double Calories {get;}

    protected Ingredient(string name, double weight, double calories)
    {
        Name = name;
        Weight = weight;
        Calories = calories;
    }

    public double GetCalories()
    {
        return ( Weight / 100.0 ) * Calories;
    }

    public override string ToString()
    {
        return $"{Name} — {Weight} г — {GetCalories():0.00} ккал";
    }

}