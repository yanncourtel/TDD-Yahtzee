namespace Yahtzee
{
    public class Player
    {
        private readonly IDiceLauncher diceLauncher;
        private ScoreGrid _scoreGrid;

        public Player(IDiceLauncher diceLauncher)
        {
            this.diceLauncher = diceLauncher;
            _scoreGrid = new ScoreGrid();
        }

        public int TotalScore => _scoreGrid.Total;

        public Roll RollDice()
        {
            return diceLauncher.Generate();
        }

        public void ChooseScore(Roll roll, Combination combination)
        {
            _scoreGrid.SaveScore(roll, combination);
        }
    }
}