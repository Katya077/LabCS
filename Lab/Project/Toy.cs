namespace Project;

public class Toy : Product
{
    private string name;

    public Toy(string name, int price, int quantity)
        : base(price, quantity)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Название не может быть пустым", nameof(name));

        this.name = name;
    }

    public string Name => name;

    public override decimal GetTotal()
    {
        const decimal discount = 0.10m;
        return Price * Quantity * (1 - discount);
    }

    public override string ToString()
    {
        return $"{Name} — цена за единицу: {Price}, количество: {Quantity}, со скидкой 10%: {GetTotal()}";
    }

}