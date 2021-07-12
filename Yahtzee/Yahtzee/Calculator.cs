using System;
using System.Linq;

namespace Yahtzee
{
    public class Calculator
    {
        public int Calculate(int[] dices, Combination combination)
        {
            if (dices == null)
            {
                throw new InvalidDiceException();
            }
            return combination switch
            {
                Combination.Ones => dices.Where(x => x == 1).Sum(),
                Combination.Twos => dices.Where(x => x == 2).Sum(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public int Calculate(Roll roll, Combination combination)
        {
            var dicesValues = roll.Dices.Select(x => x.Value).ToArray();
            return Calculate(dicesValues, combination);
        }
    }
}