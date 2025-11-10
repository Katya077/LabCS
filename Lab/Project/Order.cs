namespace Project;
using System.Text;

public class Order
{
    public List<Product> products = new List<Product>();

    public void Add(Product product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product), "Нельзя добавить пустой предмет");
            
        products.Add(product);
    }

    public decimal Total => products.Sum(p => p.GetTotal());

    public override string ToString()
    {
        if (products.Count == 0)
            return "Заказ пуст.";

        var info = new StringBuilder();
        info.AppendLine("Состав заказа:");

        foreach (var product in products)
        {
            info.AppendLine($"- {product}"); 
        }

        info.AppendLine($"Общая стоимость: {Total}");

        return info.ToString();
    }

}