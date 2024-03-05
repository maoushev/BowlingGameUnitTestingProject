namespace BowlingGameConsole;

public class Game
{
    public ICollection<Frame> Frames { get; set; }

    public Game()
    {
        Frames = new List<Frame>();
        Frame frame = new Frame();

        for (int i = 0; i < 10; i++)
        {
            frame.NextFrame = new Frame();
            Frames.Add(frame);
            frame = frame.NextFrame;
        }

    }
    public void Roll(int score)
    {
        if (score < 0 || score > 10)
            throw new ArgumentException();
        if (Frames.All(f => f.IsCompleted))
            throw new Exception("Game is Completed!");

        var frame = Frames.First(f => f.IsCompleted == false);
        frame.AddRolls(score);
    }

    public int Score()
    {
        return Frames.Select(f => f.Score()).Sum();
    }
}

public class Frame
{
    public ICollection<Roll> Rolls { get; set; }
    public Frame? NextFrame { get; set; } = null;
    public bool IsCompleted => Rolls.Count == 2 || Rolls.FirstOrDefault()?.Pins == 10;

    public Frame()
    {
        Rolls = new List<Roll>();
        NextFrame = null;
    }

    public Frame(Frame f) : this()
    {
        NextFrame = f;
    }
    public int Score()
    {
        throw new NotImplementedException();
    }

    public void AddRolls(int score)
    {
        Rolls = Rolls.Append(new Roll(score)).ToArray();
    }

}

public record Roll(
    int Pins
    );

public class TenthFrame : Frame
{
    public Roll? Roll { get; set; }
}