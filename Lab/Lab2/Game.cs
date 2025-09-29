using System;
using System.Collections.Generic;

namespace Lab2;

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

    public Game(int size)
    {
        this.size = size;
        cat = new Player("Cat");
        mouse = new Player("Mouse");
        state = GameState.Start;
        
        history = new List<(int catPos, int mousePos, int dictance)>();
    }

    private int GetDistance()
    {
        if (cat.State == State.NotInGame || mouse.State == State.NotInGame)
            return -1;
        
        int d = Math.Abs(cat.Position - mouse.Position);
        return Math.Min(d, size - d);
    }
    private void SaveHistory()
    {
        int dist =GetDistance();
        history.Add((cat.Position, mouse.Position, dist));
    }

    private bool IsCaught()
    {
        return cat.Position == mouse.Position;
    }
    private void PrintSummary()
    {
        Console.WriteLine($"\nDistance travelled: Mouse {mouse.DistanceTraveled}  Cat {cat.DistanceTraveled}");
        if (IsCaught())
        {
            Console.WriteLine($"Mouse caught at: {cat.Position}");
        }
        else
        {
            Console.WriteLine("Mouse evaded Cat");
        }   
    }
    
    public void Run()
    {
        Console.WriteLine("Cat and Mouse\n");
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

            SaveHistory();

            if (IsCaught())
            {
                state = GameState.End;
                break;
            }
        }
    }
}



