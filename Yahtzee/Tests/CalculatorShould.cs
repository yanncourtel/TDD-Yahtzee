using System;
using FluentAssertions;
using Xunit;
using Yahtzee;

namespace Tests
{
    public class CalculatorShould
    {
        [Theory]
        [InlineData(1, 1, 1, 1, 1, Combination.Ones, 5)]
        [InlineData(1, 1, 1, 1, 2, Combination.Ones, 4)]
        [InlineData(1, 1, 1, 1, 2, Combination.Twos, 2)]
        public void Calculate_Given_Dices_For_Combination_The_Expected_Score(int dice1, int dice2, int dice3, int dice4,
            int dice5, Combination combination, int expectedScore)
        {
            // arrange 
            var calculator = new Calculator();
            var dices = new int[] {dice1, dice2, dice3, dice4, dice5};

            // act
            var result = calculator.Calculate(dices, combination);

            // assert
            result.Should().Be(expectedScore);
        }

        [Fact]
        public void Calculate_With_Invalid_Combination_Throws_Exception()
        {
            // arrange 
            var calculator = new Calculator();
            var dices = new int[] {1, 1, 1, 1, 1};

            // act
            // assert
            calculator.Invoking(x => x.Calculate(dices, (Combination) 100))
                .Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Calculate_With_Null_Dices_Throws_Exception()
        {
            // arrange 
            var calculator = new Calculator();

            // act
            // assert
            calculator.Invoking(x => x.Calculate((int[]) null, Combination.Ones))
                .Should().Throw<InvalidDiceException>("Your dices are invalid");
        }

        [Theory]
        [InlineData(1, 1, 1, 1, 1, Combination.Ones, 5)]
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
