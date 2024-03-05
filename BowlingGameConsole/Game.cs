namespace BowlingGameConsole;

public class Game
{
    public ICollection<Frame> Frames { get; set; } = new List<Frame>();

    public Game()
    {

    }
    public void Roll(int score)
    {
        if (score < 0 || score > 10)
            throw new ArgumentException();
        if (Frames.All(f => f.IsCompleted) && Frames.Count() == 10)
            throw new Exception("Game is Completed!");
        if (!Frames.Any(f => f.IsCompleted))
        {
            Frames.Add(new Frame());
        }

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
    public ICollection<Roll> Rolls { get; set; } = new List<Roll>();
    public Frame NextFrame { get; set; } = new Frame();
    public bool IsCompleted => Rolls.Count == 2 || Rolls.FirstOrDefault()?.Pins == 10;

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