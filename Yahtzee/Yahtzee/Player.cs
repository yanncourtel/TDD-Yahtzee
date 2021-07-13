namespace Yahtzee
{
    public class Player
    {
        private readonly IDiceLauncher diceLauncher;

        public Player(IDiceLauncher diceLauncher)
        {
            this.diceLauncher = diceLauncher;
        }

        public int TotalScore { get; set; }

        public Roll RollDice()
        {
            return diceLauncher.Generate();
        }

        public void ChooseScore(Roll roll, Combination yahtzee)
        {
            throw new System.NotImplementedException();
        }
    }
}