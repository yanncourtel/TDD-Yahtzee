using System.Linq;
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
            var dices = new int[] { 1,1,1,1,1};
            var result = calculator.Calculate(dices, Combination.Ones);
            result.Should().Be(5);
        }

        [Fact]
        public void Calculate_Given_11112_For_Ones_A_Score_4()
        {
            var calculator = new Calculator();
            var dices = new int[] { 1, 1, 1, 1, 2 };
            var result = calculator.Calculate(dices, Combination.Ones);
            result.Should().Be(4);
        }

        [Fact]
        public void Calculate_Given_11112_For_Twos_A_Score_2()
        {
            var calculator = new Calculator();
            var dices = new int[] { 1, 1, 1, 1, 2 };
            var result = calculator.Calculate(dices, Combination.Twos);
            result.Should().Be(2);
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
            return dices.Where(x => x == 1).Sum();
        }
    }
}