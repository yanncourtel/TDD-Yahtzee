using FluentAssertions;

using Moq;

using Xunit;

using Yahtzee;

namespace Tests.Integration.PlayerFeature
{
    public class PlayerSaveScore
    {

        /*
         * 1) Save score with 5 dices of same values of 1 in Yahtzee
         * 2) Save score with 5 dices of 12345 in Large Straight
         * 3) Total score should be 90
         */

        [Fact]
        public void Player_Can_Save_Score_Each_Turn_And_Have_A_Total_Score()
        {
            var _diceLauncher = new Mock<IDiceLauncher>();
            var dices = new Dice[] { new Dice(1), new Dice(1), new Dice(1), new Dice(1), new Dice(1) };
            _diceLauncher.Setup(x => x.Generate())
                .Returns(new Roll(dices));
            Player player = new Player(_diceLauncher.Object);

            var roll = player.RollDice();

            player.ChooseScore(roll, Combination.Yahtzee);

            dices = new Dice[] { new Dice(1), new Dice(2), new Dice(3), new Dice(4), new Dice(5) };
            _diceLauncher.Setup(x => x.Generate())
                .Returns(new Roll(dices));
            var roll2 = player.RollDice();

            player.ChooseScore(roll2, Combination.LargeStraight);

            // Assert
            player.TotalScore.Should().Be(90);
        }
    }
}
