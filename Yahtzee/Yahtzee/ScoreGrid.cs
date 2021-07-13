using System.Collections.Generic;
using System.Linq;

namespace Yahtzee
{
    public class ScoreGrid
    {
        private readonly Dictionary<Combination,int> _scores;

        public ScoreGrid()
        {
            _scores = new Dictionary<Combination, int>();
        }

        public int Total => _scores.Sum(x => x.Value);

        public int PrintTemporaryScore(Roll roll, Combination combination)
        {
            return Calculator.Calculate(roll, combination);
        }

        public int GetScore(Combination combination)
        {
            return _scores.ContainsKey(combination) ? _scores[combination] : 0;
        }

        public void SaveScore(Roll roll, Combination combination)
        {
            _scores[combination] = PrintTemporaryScore(roll, combination);
            
        }
    }
}