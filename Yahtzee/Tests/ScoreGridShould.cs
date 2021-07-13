using FluentAssertions;
using Xunit;
using Yahtzee;

namespace Tests
{
    public class ScoreGridShould
    {
        [Theory]
        [InlineData(1, 1, 1, 1, 1, Combination.Ones, 5)]
        [InlineData(6, 6, 6, 6, 1, Combination.Square, 25)]
        public void Print_Score_Given_Roll_For_Combination_The_Expected_Score(int dice1, int dice2, int dice3,
            int dice4,
            int dice5, Combination combination, int expectedScore)
        {
            // arrange 
            var scoreGrid = new ScoreGrid();
            var dices = new Dice[]
                {new Dice(dice1), new Dice(dice2), new Dice(dice3), new Dice(dice4), new Dice(dice5)};
            var roll = new Roll(dices);

            // act
            var score = scoreGrid.PrintTemporaryScore(roll, combination);

            // assert
            score.Should().Be(expectedScore);
        }
    }

    public class ScoreGrid
    {

        public ScoreGrid()
        {
        }

        public int PrintTemporaryScore(Roll roll, Combination combination)
        {
            return Calculator.Calculate(roll,combination);
        }
    }
}