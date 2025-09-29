using System;

namespace Lab2;

public enum State
{
    Winner;
    Looser;
    Playing;
    NotInGame;
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



}