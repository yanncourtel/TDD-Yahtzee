using System.Linq;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class CalculatorShould
    {
        [Theory] 
        [InlineData(1,1,1,1,1,Combination.Ones,5)]
        [InlineData(1,1,1,1,2,Combination.Ones,4)]
        [InlineData(1,1,1,1,2,Combination.Twos,2)]
        public void Calculate_Given_Dices_For_Combination_The_Expected_Score(int dice1,int dice2,int dice3,int dice4,int dice5, Combination combination, int expectedScore)
        {
            // arrange 
            var calculator = new Calculator();
            var dices = new int[] { dice1,dice2,dice3,dice4,dice5};
            
            // act
            var result = calculator.Calculate(dices, combination);
            
            // assert
            result.Should().Be(expectedScore);
        }
    }

    public enum Combination
    {
        Ones,
        Twos
    }

    public class Calculator
    {
        public int Calculate(int[] dices, Combination combination)
        {
            return combination switch
            {
                Combination.Ones => dices.Where(x => x == 1).Sum(),
                Combination.Twos => dices.Where(x => x == 2).Sum(),
                _ => dices.Where(x => x == 1).Sum()
            };
        }
    }
}