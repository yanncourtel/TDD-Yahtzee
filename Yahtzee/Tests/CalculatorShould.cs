using System;
using FluentAssertions;
using Xunit;
using Yahtzee;

namespace Tests
{
    public class CalculatorShould
    {
        [Fact]
        public void Calculate_With_Invalid_Combination_Throws_Exception()
        {
            // arrange 
            var calculator = new Calculator();
            var dices = new Dice[] { new Dice(1), new Dice(1), new Dice(1), new Dice(1), new Dice(1) };
            var roll = new Roll(dices);

            // act
            // assert
            calculator.Invoking(x => x.Calculate(roll, (Combination) 100))
                .Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Calculate_With_Null_Roll_Throws_Exception()
        {
            // arrange 
            var calculator = new Calculator();

            // act
            // assert
            calculator.Invoking(x => x.Calculate(null, Combination.Ones))
                .Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(1, 1, 1, 1, 1, Combination.Ones, 5)]
        [InlineData(1, 1, 1, 1, 2, Combination.Ones, 4)]
        [InlineData(1, 1, 1, 1, 2, Combination.Twos, 2)]
        [InlineData(1, 1, 1, 1, 3, Combination.Threes, 3)]
        [InlineData(1, 1, 1, 1, 4, Combination.Fours, 4)]
        [InlineData(1, 1, 1, 1, 5, Combination.Fives, 5)]
        [InlineData(1, 1, 1, 1, 6, Combination.Sixes, 6)]
        [InlineData(1, 1, 1, 1, 6, Combination.Chance, 10)]
        [InlineData(1, 2, 3, 4, 5, Combination.LargeStraight, 40)]
        [InlineData(1, 2, 3, 4, 6, Combination.LargeStraight, 0)]
        [InlineData(2, 6, 3, 4, 5, Combination.LargeStraight, 40)]
        [InlineData(2, 6, 3, 4, 5, Combination.SmallStraight, 30)]
        public void Calculate_Given_Roll_For_Combination_The_Expected_Score(int dice1, int dice2, int dice3, int dice4,
            int dice5, Combination combination, int expectedScore)
        {
            // arrange 
            var calculator = new Calculator();
            var dices = new Dice[] {new Dice(dice1), new Dice(dice2), new Dice(dice3), new Dice(dice4), new Dice(dice5)};
            var roll = new Roll(dices);

            // act
            var result = calculator.Calculate(roll, combination);

            // assert
            result.Should().Be(expectedScore);
        }
      
    }
}
