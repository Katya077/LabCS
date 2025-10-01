
namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Введите размер поля: ");
            int size;
            while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                Console.WriteLine("Пожалуйста, введите положительное целое число для размера поля.");
            }
            Game game = new Game(size);
            game.Run();
        }
    }
}
