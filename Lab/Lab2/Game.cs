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

    
}