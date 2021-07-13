using System;
using System.Linq;

namespace Yahtzee
{
    public class Calculator
    {
        public int Calculate(Roll roll, Combination combination)
        {
            if (roll == null)
            {
                throw new ArgumentNullException();
            }
            var dicesValues = roll.GetDicesValues();
            
            return combination switch
            {
                Combination.Ones => dicesValues.Where(x => x == 1).Sum(),
                Combination.Twos => dicesValues.Where(x => x == 2).Sum(),
                Combination.Threes => dicesValues.Where(x => x == 3).Sum(),
                Combination.Fours => dicesValues.Where(x => x == 4).Sum(),
                Combination.Fives => dicesValues.Where(x => x == 5).Sum(),
                Combination.Sixes => dicesValues.Where(x => x == 6).Sum(),
                Combination.Chance => dicesValues.Sum(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}