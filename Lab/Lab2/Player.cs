namespace Lab2
{
    public enum State
    {
        Playing,
        NotInGame,
        Winner,
        Loser
    }

    public class Player
    {
        public string Name { get; }
        public int Position { get; private set; }
        public State CurrentState { get; set; } = State.NotInGame;
        public int DistanceTraveled { get; private set; }

        public Player(string name)
        {
            Name = name;
            Position = -1;

        }

        public void SetPosition(int pos)
        {
            Position = pos;
            CurrentState = State.Playing;
        }

        public void Move(int steps, int size)
        {
            if (CurrentState != State.Playing) return;
            int oldPosition = Position;

            Position = (Position + steps) % size;
            if (Position < 0) Position += size;
            if(Position == 0) Position = size;
            DistanceTraveled += Math.Abs(steps);
        }
    }
}