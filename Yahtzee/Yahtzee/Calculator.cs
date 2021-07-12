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
            var dicesValues = roll.Dices.Select(x => x.Value).ToArray();
            
            return combination switch
            {
                Combination.Ones => dicesValues.Where(x => x == 1).Sum(),
                Combination.Twos => dicesValues.Where(x => x == 2).Sum(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}