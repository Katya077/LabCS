
namespace Lab2
{

    public enum GameState
    {
        Start,
        End
    }

    public class Game
    {
        private Player cat;
        private Player mouse;
        private int size;
        private GameState state;

        private List<(int catPos, int mousePos, int distance)> history;

        private string inputFile;
        private string outputFile;

        public Game(string inputFile, string outputFile)
        {
            this.inputFile = inputFile;
            this.outputFile = outputFile;
            cat = new Player("Cat");
            mouse = new Player("Mouse");
            state = GameState.Start;

            history = new List<(int catPos, int mousePos, int dictance)>();
        }

// наследование в классах(абстракты классов)
        private int GetDistance()
        {
            if (cat.CurrentState == State.NotInGame || mouse.CurrentState == State.NotInGame)
                return 0;

            int d = Math.Abs(cat.Position - mouse.Position);
            return Math.Min(d, size - d); 
        }

        private void SaveHistory()
        {
            int dist = GetDistance();
            history.Add((cat.Position, mouse.Position, dist));
        }

        private bool IsCaught()
        {
            return cat.CurrentState == State.Playing || mouse.CurrentState == State.Playing && cat.Position == mouse.Position;
        }

        public void Run()
        {
            string[] commands = File.ReadAllLines(inputFile);
            if (commands.Length == 0) return;
            size = int.Parse(commands[0]);
            for (int i = 1; i < commands.Length && state != GameState.End; i++)
            {

                string input = commands[i].Trim().ToUpper();

                if (string.IsNullOrWhiteSpace(input)) continue;

                if (input == "Q")
                {
                    state = GameState.End;
                    break;
                }

                if (input == "P")
                {
                    SaveHistory();
                    if (IsCaught()) state = GameState.End;
                    continue;
                }

                string[] parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length < 2) continue;

                char command = parts[0][0];
                if (!int.TryParse(parts[1], out int steps))
                    continue;

                switch (command)
                {
                    case 'M':
                        if (mouse.CurrentState == State.NotInGame)
                            mouse.SetPosition(steps);
                        else
                            mouse.Move(steps, size);
                        break;

                    case 'C':
                        if (cat.CurrentState == State.NotInGame)
                            cat.SetPosition(steps);
                        else
                            cat.Move(steps, size);
                        break;
                }

                if (IsCaught())
                {
                    state = GameState.End;
                    mouse.CurrentState = State.Looser;
                    cat.CurrentState = State.Winner;
                }
            }

            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                PrintTable(writer);
                PrintSummary(writer);
            }
        }

        private void PrintTable(StreamWriter writer)
        {
            writer.WriteLine("Кот и мышка");
            writer.WriteLine("\nКот Мышка Расстояние");
            writer.WriteLine("----------------------");

            foreach (var entry in history)
            {
                string catPos = entry.catPos == -1 ? "??" : entry.catPos.ToString();
                string mousePos = entry.mousePos == -1 ? "??" : entry.mousePos.ToString();
                string dist = (entry.catPos == -1 || entry.mousePos == -1) ? "" : entry.distance.ToString();
                writer.WriteLine($"{catPos,3}\t{mousePos,6}\t{dist,9}");
            }

            writer.WriteLine("------------------");
        }

        private void PrintSummary(StreamWriter writer)
        {
            writer.WriteLine();
            Console.WriteLine("\nПройденная дистанция: Мышка   Кот ");
            writer.WriteLine($"{mouse.DistanceTraveled,24}{cat.DistanceTraveled,7}");
            writer.WriteLine();

            if (cat.CurrentState == State.Winner)
            {
                writer.WriteLine($"Мышка поймана на клетке: {cat.Position}");
            }
            else
                Console.WriteLine("Мышка не поймана котом");
        }
    }
}
