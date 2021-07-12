using FluentAssertions;
using Xunit;

namespace Tests
{
    public class CalculatorShould
    {
        [Fact] 
        public void Calculate_Given_11111_For_Ones_A_Score_5()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate(1, 1, 1, 1, 1, Combination.Ones);
            result.Should().Be(5);
        }
        
        [Fact] 
        public void Calculate_Given_11112_For_Ones_A_Score_4()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate(1, 1, 1, 1, 2, Combination.Ones);
            result.Should().Be(4);
        }
    }

    public enum Combination
    {
        Ones
    }

    public class Calculator
    {
        public int Calculate(int dice1, int dice2, int dice3, int dice4, int dice5, Combination combination)
        {
            return 5;
        }
    }
}