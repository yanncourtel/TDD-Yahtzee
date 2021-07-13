using FluentAssertions;
using Moq;
using Xunit;
using Yahtzee;

namespace Tests
{
    public class PlayerShould
    {
        [Fact]
        public void Be_Able_To_Roll_Dices()
        {
            // arrance
            var dices = new Dice[] { new Dice(1), new Dice(1), new Dice(1), new Dice(1), new Dice(1) };
            Roll expectedRoll = new Roll(dices);
            var mockDiceLauncher = new Mock<IDiceLauncher>();
            mockDiceLauncher.Setup(x => x.Generate())
                .Returns(expectedRoll);
            var player = new Player(mockDiceLauncher.Object);

            // act
            Roll roll = player.RollDice();

            // assert
            roll.Should().BeEquivalentTo(expectedRoll);

        }

        [Fact]
        public void Be_Able_To_Choose_Score()
        {
            Assert.True(false);
        } 
    }
}