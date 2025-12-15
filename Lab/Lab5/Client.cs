namespace Lab5;
public class Client : Person
{
    public Client(string name) : base(name) { }

    public override void ShowMenu(Salad salad)
    {
        Console.WriteLine("\nВы — клиент");
        Console.WriteLine("1. Посмотреть состав салата");
        Console.WriteLine("2. Посчитать калорийность");
        Console.WriteLine("0. Выйти");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                salad.ShowIngredients();
                break;

            case "2":
                Console.WriteLine($"Калорийность: {salad.GetTotalCalories():0.00} ккал");
                break;
        }
    }
}