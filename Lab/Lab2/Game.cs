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

    private List<(int catLoc, int mouseLoc, int distatce)> history;

    public Game(int size)
    {
        this.size = size;
        cat = new Player("Cat");
        mouse = new Player("Mouse");
        state = GameState.Start;
        history = new List<(int catLoc, int mouseLoc, int distatce)>();

    }

    private int GetDistance()
    {
        if (cat.State == State.NotInGame || mouse.State == State.NotInGame)
            return -1;
        int d = Math.Abs(cat.Position - mouse.Position);
        return Math.Min(d, size - d);
    }



}