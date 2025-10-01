
namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            
           string inputFile = "1.ChaseData.txt";
           string outputFile = "PursuitLog.txt";

           if (!File.Exists(inputFile))
           {
               Console.WriteLine("Входной файл не найден");
               return;
           }
           
           string[] lines = File.ReadAllLines(inputFile);
           if (lines.Length == 0)
           {
               Console.WriteLine("Входной файл пуст.");
               return; 
           }
           int size;
           if (!int.TryParse(lines[0], out size) || size <= 0)
           {
               Console.WriteLine("Некорректный размер игрового поля в файле.");
               return; 
           }
           Game game = new Game(inputFile, outputFile);
           game.Run();
           Console.WriteLine("Результат игры записан в " + outputFile);
        }
    }
}
