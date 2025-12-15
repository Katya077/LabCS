namespace Lab5;

class Program
{
    static void Main()
    {
        Salad salad = new Salad(); // один салат
        Person person;

        while (true)
        {
            Console.WriteLine("\nВыберите роль:");
            Console.WriteLine("1. Повар");
            Console.WriteLine("2. Клиент");
            Console.WriteLine("0. Выход");

            string roleChoice = Console.ReadLine();

            if (roleChoice == "1")
                person = new Chef("Шеф");
            else if (roleChoice == "2")
                person = new Client("Клиент");
            else if (roleChoice == "0")
                break;
            else
            {
                Console.WriteLine("Неверный выбор");
                continue;
            }
            
            person.ShowMenu(salad);
        }
    }
}