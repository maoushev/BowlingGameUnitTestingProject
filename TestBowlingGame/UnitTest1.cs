using BowlingGameConsole;
using FluentAssertions;

namespace TestBowlingGame;

public class UnitTest1
{
    [Fact]
    public void ScoreAtBeginningShouldBeZero()
    {
        var game = new Game();

        game.Score().Should().Be(0);
    }

    [Fact]
    public void ScoreAtFirstRollTest()
    {

        var game = new Game();
        game.Roll(8);

        game.Score().Should().Be(8);
    }
}