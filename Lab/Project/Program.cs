namespace Project;

    class Program
    {
        static void Main(string[] args)
        {
        
            Order order = new Order();
            Book book1 = new Book("Война и мир", 1200, 1, 10);
            Book book2 = new Book("Преступление и наказание", 900, 2);
            Toy toy1 = new Toy("Конструктор LEGO", 1500, 1);

            order.Add(book1);
            order.Add(book2);
            order.Add(toy1);
            
            bool hasToy = order.products.Any(p => p is Toy);
            if (!hasToy)
            {
                Toy newToy = new Toy("Мягкая игрушка", 500, 1);
                order.Add(newToy);
            }
            order.products.Sort();
            
            Console.WriteLine(order);
            
            Product mostExpensive = order.products.OrderByDescending(p => p.GetTotal()).First();
            Console.WriteLine($"\nСамый дорогой товар:\n{mostExpensive}");
        }
    }
