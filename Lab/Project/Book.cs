namespace Project;

public class Book : Product
{
    private string title;
    private int discount;

    public Book(string title, int price, int quantity, int discount = 0)
        : base(price, quantity)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Название не может быть пустым", nameof(title));

        if (discount < 0)
            throw new ArgumentOutOfRangeException(nameof(discount), "Скидка не может быть отрицательной");

        this.title = title;
        this.discount = discount;
    }

    public string Title => title;
    public int Discount => discount;

    public override decimal GetTotal()
    {
        return Price * Quantity * (1 - discount / 100m);
    }

    public override string ToString()
    {
        if (discount > 0)
            return $"{Title} — цена за единицу: {Price}, количество: {Quantity}, скидка: {discount}%, итог: {GetTotal()}";
        else
            return $"{Title} — цена за единицу: {Price}, количество: {Quantity}, итог: {GetTotal()}";
    }

}
