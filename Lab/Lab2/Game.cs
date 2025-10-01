namespace Lab2;

public enum GameState
{
    Start,
    End,
    Stop
}

public class Game
{
    private Player cat;
    private Player mouse;
    private int size;
    private GameState state;

    private List<(int catPos, int mousePos, int distance)> history;

    public Game(int size)
    {
        this.size = size;
        cat = new Player("Cat");
        mouse = new Player("Mouse");
        state = GameState.Start;
        
        history = new List<(int catPos, int mousePos, int dictance)>();
    }
// наследование в классах(абстракты классов)
    private int GetDistance()
    {
        //Game Game1 =  new Game(size);
        
        if (state != GameState.Stop)
        {
            if (cat.State == State.NotInGame || mouse.State == State.NotInGame)
                return -1;
            
            int d = Math.Abs(cat.Position - mouse.Position);
            return Math.Min(d, size - d);
        }

        return -1;
    }
    private void SaveHistory()
    {
        int dist = GetDistance();
        history.Add((cat.Position, mouse.Position, dist));
    }

    private bool IsCaught()
    {
        return cat.Position == mouse.Position;
    }
    private void PrintSummary()
    {
        Console.WriteLine($"\nПройденная дистанция: Мышка {mouse.DistanceTraveled}  Кот {cat.DistanceTraveled}");
        if (IsCaught())
        {
            Console.WriteLine($"Мышка поймана на: {cat.Position}");
        }
        else
        {
            Console.WriteLine("Мышка не поймана котом");
        }   
    }

    private bool PrintPositions(int s)
    {
        Console.WriteLine($"Текущая позиция кота: {cat.Position}");
        Console.WriteLine($"Текущая позиция мыши: {mouse.Position}");
        return s>0 ? true:false;
    }

    public void Run()
    {
        Console.WriteLine("Кот и мышка\n");
        Console.WriteLine("Введите команду (M x / C x)");
        Console.WriteLine("При завершении нажмите Q");
        Console.WriteLine("Начальная позиция кота: ");
        cat.SetPosition(int.Parse(Console.ReadLine()));
        
        Console.WriteLine("Начальная позиция мыши: ");
        mouse.SetPosition(int.Parse(Console.ReadLine()));
        SaveHistory();

        while (state != GameState.End)
        {
            Console.WriteLine("Команда: ");
            string input = Console.ReadLine()?.Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(input)) continue;

            if (input == "Q")
            {
                state = GameState.End;
                break;
            }
            if (input == "S")
            {
                state = GameState.Stop;
                Console.WriteLine("Игра на паузе. Нажмите 'R' для продолжения.");
                while (state == GameState.Stop)
                {
                    string resumeInput = Console.ReadLine()?.Trim().ToUpper();
                    if (resumeInput == "R")
                    {
                        state = GameState.Start;
                        Console.WriteLine("Игра продолжается.");
                    }
                }
                continue; 
            }

            string[] parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2 || !int.TryParse(parts[1], out int steps))
            {
                Console.WriteLine("Пожалуйста, введите корректную команду и число шагов.");
                continue;
            }

            char command = parts[0][0];

            switch (command)
            {
                case 'M':
                    mouse.Move(steps, size);
                    break;
                case 'C':
                    cat.Move(steps, size);
                    break;
            }

            if (!PrintPositions(GetDistance()))
            {
                
                PrintPositions(GetDistance());

                SaveHistory();

                if (IsCaught())
                {
                    state = GameState.End;
                    break;
                }
            }

            PrintSummary();
        }
        Console.WriteLine("Игра завершена");
    }
}



