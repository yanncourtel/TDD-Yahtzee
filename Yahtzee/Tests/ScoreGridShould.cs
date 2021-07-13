using FluentAssertions;
using Xunit;
using Yahtzee;

namespace Tests
{
    public class ScoreGridShould
    {
        [Fact]
        public void PrintScoreForOnes() {
            // arrange
            var scoreGrid = new ScoreGrid();
            Roll roll= new Roll(new []{new Dice(1), new Dice(1), new Dice(1), new Dice(1), new Dice(1)});
            
            // act
            var score = scoreGrid.PrintTemporaryScore(roll,Combination.Ones);

            // assert
            score.Should().Be(5);

        }
    }

    public class ScoreGrid
    {
        public object PrintTemporaryScore(Roll roll, Combination ones)
        {
            throw new System.NotImplementedException();
        }
    }
}