using System;

namespace Lab2;

public enum State
{
    Winner,
    Looser,
    Playing,
    NotInGame,
}

public class Player
{
public string Name { get; set; }
public int Position { get; set; }
public string State { get; set; }
public int DistanceTraveled { get; set; }

public Player(string name)
{
    Name = name;
    State = "NotInGame";
    Position = 0;
    DistanceTraveled = 0;
}

public void SetPosition(int pos)
{
    Position = pos;
    State = State.Playing;
}

public void Move(int steps, int size)
{
    if (State == State.NotInGame) return;
     Position = (Position + steps) % size;
     if(Position < 0) Position += size;
     DistanceTraveled += Math.Abs(steps);
}
}